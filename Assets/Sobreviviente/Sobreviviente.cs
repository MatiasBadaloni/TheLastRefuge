using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobreviviente : MonoBehaviour
{
    private bool activar;
    public bool rogar;
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
            if (rogar == true)
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
        Dificultad();
        rogar = false;
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

    public void Rogar()
    {
        tiempo = tiempoBase + Random.Range(0, random);
        if (cuarto.abierto == true)
        {
            cuarto.Salvar();
            StartCoroutine(Animacion());
            Irse();
        }
        else
        {
            puerta.Golpear(2);
            rogar = true;
        }
    }

    private void Irse()
    {
        controlEventos.llamar = true;
        rogar = false;
    }
    IEnumerator Animacion()
    {
        body.SetBool("Go", true);
        yield return new WaitForSeconds(0.8f);
        body.SetBool("Go", false);
        yield return null;
    }
}
