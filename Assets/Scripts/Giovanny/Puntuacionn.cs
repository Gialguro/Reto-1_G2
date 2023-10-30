using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    private int puntos = 0;
    public Text textoPuntuacion;

    public AudioSource coinSource;
    public AudioClip coinClip;

    private void Start()
    {
        
        puntos = 0;
        ActualizarTextoPuntuacion();
    }

    
    private void OnTransformChildrenChanged()
    {
        puntos++;
        ActualizarTextoPuntuacion();
    }

    
    private void ActualizarTextoPuntuacion()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuaci�n: " + puntos;
            coinSource.PlayOneShot(coinClip);
        }
    }
}