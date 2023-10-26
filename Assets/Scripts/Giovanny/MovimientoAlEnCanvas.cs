using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MovimientoAleatorioEnCanvas : MonoBehaviour
{
    public RectTransform objetoAMover; // Objeto que se moverá dentro del Canvas
    public float velocidadMovimiento = 50.0f; // Velocidad de movimiento

    private RectTransform canvasRect;
    private Vector2 canvasSize;
    private Vector2 canvasHalfSize;
    private Vector3 targetPosition;
    private Vector3 initialPosition;

    void Start()
    {
        canvasRect = GetComponent<RectTransform>();
        canvasSize = canvasRect.sizeDelta;
        canvasHalfSize = canvasSize * 0.5f;

        // Iniciar posición y objetivo aleatorio dentro del Canvas
        initialPosition = GetRandomPositionInsideCanvas();
        objetoAMover.anchoredPosition = initialPosition;
        targetPosition = GetRandomPositionInsideCanvas();
    }

    void Update()
    {
        // Mover hacia el objetivo
        objetoAMover.anchoredPosition = Vector3.MoveTowards(objetoAMover.anchoredPosition, targetPosition, velocidadMovimiento * Time.deltaTime);

        // Verificar si el objeto ha alcanzado el objetivo
        if (Vector3.Distance(objetoAMover.anchoredPosition, targetPosition) < 0.1f)
        {
            // Cambiar el objetivo al llegar a los límites
            targetPosition = GetRandomPositionInsideCanvas();
        }
    }

    Vector3 GetRandomPositionInsideCanvas()
    {
        float x = Random.Range(-canvasHalfSize.x, canvasHalfSize.x);
        float y = Random.Range(-canvasHalfSize.y, canvasHalfSize.y);
        return new Vector3(x, y, 0);
    }
}
