﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMaestro : MonoBehaviour
{
    [Header("Objetos")]
    public GameObject ganar;
    public GameObject perder;
    public Mecanicas player;
    public ControlEventos controlEventos;
    public Sobreviviente sobreviviente;
    public Buscador buscador;
    public Puerta puerta;
    public Text puntaje;
    public GameObject libros;

    [Header("Opciones")]
    private bool activar;
    public int puntosNecesarios;

    private void Start()
    {
        Activar();
    }
    private void Activar()
    {
        activar = true;
        player.Activar();
        controlEventos.Activar();
        sobreviviente.Activar();
        buscador.Activar();
        puerta.Activar();
    }
    private void Deactivar()
    {
        activar = false;
        player.Desactivar();
        controlEventos.Desactivar();
        sobreviviente.Desactivar();
        buscador.Desactivar();
    }
    public void Reiniciar()
    {
        puntaje.text = "0";
        player.Reiniciar();
        controlEventos.Reiniciar();
        sobreviviente.Reiniciar();
        buscador.Reiniciar();
        ganar.gameObject.SetActive(false);
        perder.gameObject.SetActive(false);
        Activar();
        libros.gameObject.SetActive(false);
    }
    public void Ganar(int sobrevivientes)
    {
        if (activar == true)
        {
            puntaje.text = sobrevivientes.ToString();
            if (sobrevivientes >= puntosNecesarios)
            {
                ganar.gameObject.SetActive(true);
                controlEventos.Desactivar();
                Deactivar();
            }
        }
    }

    public void Perder()
    {
        if (activar == true)
        {
            perder.gameObject.SetActive(true);
            controlEventos.Desactivar();
            Deactivar();
        }
    }



}
