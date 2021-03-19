using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Libro : MonoBehaviour
{
    public Text texto;
    public Parrafo parrafo;

    void Start()
    {
        Actualizar();
    }

    public void Actualizar()
    {
        texto.text = parrafo.parrafo.ToString();
    }
    
      
    
}
