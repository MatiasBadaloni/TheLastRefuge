using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public AudioSource sound;
    public GameObject alarma;
    public void Golpear(int golpes)
    {
        StartCoroutine(Reproducir(golpes));
    }
    public void Activar()
    {
        sound.volume = 1;
    }

    public void Desactivar()
    {
        sound.volume = 0;
    }

    IEnumerator Reproducir(int golpess)
    {
        yield return new WaitForSeconds(1.2f);
        for (int f = golpess; f >= 1; f -= 1)
        {
            alarma.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            sound.Play();
            alarma.SetActive(false);
            yield return null;
        }
    }
}
