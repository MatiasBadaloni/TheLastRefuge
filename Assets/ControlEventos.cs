using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlEventos : MonoBehaviour
{
    private bool activar;
    public bool llamar;
    public Sobreviviente sobreviviente;
    public Buscador buscador;
    public int dificultad;
    public float tiempo;
    private float tiempoBase;
    private float random;

    private int sobrePosibi1;
    private int sobrePosibi2;
    private int buscaPosibi1;
    private int buscaPosibi2;
    private int ambasPosibi1;
    private int ambasPosibi2;
    private int randomPosibi;

    public Text indicador;

    void Start()
    {
        Dificultad();
    }

    void Update()
    {
        indicador.text = tiempo.ToString();
        if (activar == true)
        {
            if (llamar == true)
            {
                if (tiempo <= 0)
                {
                    Llamar();
                }
                else
                {
                    tiempo -= 0.002f;
                }
            }
        }
    }

    public void Pausar()
    {
        activar = false;
    }

    public void Activar()
    {
        activar = true;
    }
    public void Desactivar()
    {
        activar = false;
        llamar = false;
    }
    public void Reiniciar()
    {
        llamar = true;
        Dificultad();
        Activar();
    }
    private void Dificultad()
    {
        if (dificultad == 1 || dificultad == 0)
        {
            tiempoBase = 2.5f;
            random = 1;


            sobrePosibi1 = 0;
            sobrePosibi2 = 3;

            buscaPosibi1 = 4;
            buscaPosibi2 = 5;

            randomPosibi = 5;
        }
    }

    private void Llamar()
    {
        int randomPosibi2;
        llamar = false;
        tiempo = tiempoBase + Random.Range(0, random);

        randomPosibi2 = Random.Range(0, randomPosibi);
        //Debug.Log(randomPosibi2);
        if (sobrePosibi1 <= randomPosibi2 && sobrePosibi2 >= randomPosibi2)
        {
            //Debug.Log("Sobreviviente");
            LlamarSobreviviente();
        }
        if (buscaPosibi1 <= randomPosibi2 && buscaPosibi2 >= randomPosibi2)
        {
            //Debug.Log("Buscador");
            LlamarBuscador();
        }
    }
    private void LlamarSobreviviente()
    {
        sobreviviente.Rogar();
    }

    private void LlamarBuscador()
    {
        buscador.Atacar();
    }

    private void LlamarAmbos()
    {

    }

}
