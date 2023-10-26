using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetoEntrePosiciones : MonoBehaviour
{
    public Transform objetoMovido;
    public float tiempoEntreMovimientos = 2.0f; // Intervalo de tiempo entre movimientos aleatorios

    private Vector3 startPosition;
    private bool enMovimiento = false;

    void Start()
    {
        startPosition = objetoMovido.position;
        InvokeRepeating("MoverObjetoAleatoriamente", 0, tiempoEntreMovimientos);
    }

    void MoverObjetoAleatoriamente()
    {
        if (!enMovimiento)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-10f, 10f), // Cambia los valores según tu escena
                Random.Range(-10f, 10f), // Cambia los valores según tu escena
                Random.Range(-10f, 10f)  // Cambia los valores según tu escena
            );

            StartCoroutine(MoverHaciaPosicionAleatoria(randomPosition));
        }
    }

    IEnumerator MoverHaciaPosicionAleatoria(Vector3 targetPosition)
    {
        enMovimiento = true;
        float duration = 2.0f; // Duración del movimiento en segundos
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            objetoMovido.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        startPosition = objetoMovido.position;
        enMovimiento = false;
    }
}