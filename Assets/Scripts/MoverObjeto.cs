using System.Collections;
using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public Transform punto1; 
    public Transform punto2; 
    public float velocidad = 1.0f; 
    public float tiempoDeEspera = 2.0f; 

    private void Start()
    {
        StartCoroutine(MoverYEsperar());
    }

    IEnumerator MoverYEsperar()
    {
        while (true)
        {
            float tiempoInicio = Time.time;
            float distanciaTotal = Vector3.Distance(transform.position, punto2.position);

            
            while (Vector3.Distance(transform.position, punto2.position) > 0.01f)
            {
                float tiempoPasado = Time.time - tiempoInicio;
                float t = tiempoPasado * velocidad / distanciaTotal;
                transform.position = Vector3.Lerp(punto1.position, punto2.position, t);
                yield return null;
            }

            
            yield return new WaitForSeconds(tiempoDeEspera);

            
            tiempoInicio = Time.time;
            distanciaTotal = Vector3.Distance(transform.position, punto1.position);
            while (Vector3.Distance(transform.position, punto1.position) > 0.01f)
            {
                float tiempoPasado = Time.time - tiempoInicio;
                float t = tiempoPasado * velocidad / distanciaTotal;
                transform.position = Vector3.Lerp(punto2.position, punto1.position, t);
                yield return null;
            }

            
            yield return new WaitForSeconds(tiempoDeEspera);
        }
    }
}
