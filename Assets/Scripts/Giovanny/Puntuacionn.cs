using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    private int puntos = 0;
    public Text textoPuntuacion; 

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
            textoPuntuacion.text = "Puntuación: " + puntos;
        }
    }
}