using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buscador : MonoBehaviour
{
    private bool activar;
    public bool atacar;
    public int dificultad;
    private float tiempoBase;
    public float tiempo;
    private float random;

    public Mecanicas cuarto;
    public ControlEventos controlEventos;
    public Puerta puerta;
    public Animator body;
    void Start()
    {
        Dificultad();
    }

    void Update()
    {
        if (activar == true)
        {
            if (atacar == true)
            {
                if (tiempo <= 0)
                {
                    Irse();
                }
                else
                {
                    tiempo -= 0.002f;
                }
            }
        }
    }

    public void Activar()
    {
        activar = true;
    }
    public void Desactivar()
    {
        activar = false;
    }
    public void Reiniciar()
    {
        body.SetBool("Atacar", false);
        Dificultad();
        atacar = false;
        Activar();
    }
    private void Dificultad()
    {
        //Evitar errores humanos
        if (dificultad <= 0 || dificultad >= 6)
        {
            dificultad = 0;
        }

        //Elegir dificultad
        if (dificultad == 0)
        {
            tiempoBase = 4;
            random = 2;
        }
        if (dificultad == 1)
        {

        }
        if (dificultad == 2)
        {

        }
        tiempo = tiempoBase;
    }

    public void Atacar()
    {
        tiempo = tiempoBase + Random.Range(0, random);
        if (cuarto.abierto == true)
        {

            body.SetBool("Atacar", true);
            cuarto.Morir();
            activar = false;
        }
        else
        {
            puerta.Golpear(4);
            atacar = true;
        }
    }

    private void Irse()
    {
        controlEventos.llamar = true;
        atacar = false;
    }
}
