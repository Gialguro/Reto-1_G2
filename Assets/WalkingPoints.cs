using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPoints : MonoBehaviour
{
    [SerializeField] Transform[] puntosCamino;
    int indiceActual = 0;
    int direccion = 1;

    private void Update()
    {

        if (puntosCamino != null && puntosCamino.Length > 0)
        {
            transform.position = puntosCamino[indiceActual].position;

            indiceActual += direccion;

            if (indiceActual >= puntosCamino.Length || indiceActual < 0)
            {
                direccion *= -1;

                if (indiceActual >= puntosCamino.Length)
                {
                    indiceActual = 0;
                }
            }
        }
    }
}
