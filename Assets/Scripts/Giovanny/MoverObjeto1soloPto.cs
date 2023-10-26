using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoverObjeto1soloPunto : MonoBehaviour
{
    public Transform punto1;
    public float velocidad = 1.0f;
    public GameObject objetoTexto; 

    private bool isMoving = false;

    private void Start()
    {
        
        if (objetoTexto != null)
        {
            Button button = objetoTexto.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnTextClick());
            }
            
        }
        
    }

    private void OnTextClick()
    {
        if (!isMoving)
        {
            StartCoroutine(MoverHaciaPunto1());
        }
    }

    IEnumerator MoverHaciaPunto1()
    {
        isMoving = true;

        float tiempoInicio = Time.time;
        float distanciaTotal = Vector3.Distance(transform.position, punto1.position);

        while (Vector3.Distance(transform.position, punto1.position) > 0.01f)
        {
            float tiempoPasado = Time.time - tiempoInicio;
            float t = tiempoPasado * velocidad / distanciaTotal;
            transform.position = Vector3.Lerp(transform.position, punto1.position, t);
            yield return null;
        }

        isMoving = false;
    }
}
