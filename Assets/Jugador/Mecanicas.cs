using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mecanicas : MonoBehaviour
{
    public int sobreviSalvados;
    private bool activar;
    public bool abierto;
    public bool muerto;
    private bool ganar;
    public ControlEventos controlEventos;
    public Sobreviviente sobreviviente;
    public Buscador buscador;
    public Animator puerta;
    public ControlMaestro controlMaestro;
    public GameObject pausar;
    public GameObject pausar1;
    public GameObject pausar2;
    public SpriteRenderer fondo;
    public SpriteRenderer imagen1;
    public SpriteRenderer imagen2;
    
    private void Update()
    {
        if (Input.GetKey("s"))
        {
            if (abierto == false)
            {
              //  Abrir();
            }
        }
        else
        {
            if (abierto == true)
            {
            //    Cerrar();
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
        sobreviSalvados = 0;
        muerto = false;
        ganar = false;
        abierto = false;
        puerta.SetBool("Abrir", false);
        Activar();
    }

    public void Abrir()
    {
        if (activar == true)
        {
            if (muerto == false)
            {
                if (abierto == false)
                {
                    fondo.sprite = imagen2.sprite;
                    puerta.SetBool("Abrir", true);
                    abierto = true;
                    if (buscador.atacar == true)
                    {
                        buscador.Atacar();
                    }
                    if (sobreviviente.rogar == true)
                    {
                        sobreviviente.Rogar();
                    }
                    controlEventos.Activar();
                    pausar.SetActive(false);
                    pausar1.SetActive(true);
                    pausar2.SetActive(false);
                }
            }
        }
    }

    public void Cerrar()
    {
        if (activar == true)
        {
            if (muerto == false)
            {
                if (abierto == true)
                {
                    fondo.sprite = imagen1.sprite;
                    puerta.SetBool("Abrir", false);
                    abierto = false;
                    pausar.SetActive(true);
                }
            }
        }
    }

    public void Salvar()
    {
        sobreviSalvados += 1;
        controlMaestro.Ganar(sobreviSalvados);
    }
    public void Morir()
    {
        if (activar == true)
        {
            if (ganar == false)
            {
                muerto = true;
                controlMaestro.Perder();
            }
        }
    }
    public void Ganar()
    {
        if (activar == true)
        {
            if (muerto == false)
            {
                ganar = true;
                Desactivar();
            }
        }
    }
  
}
