using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarEjeZ : MonoBehaviour
{
    public float velocidadRotacion = 90.0f; 

    void Update()
    {
        
        Transform transform = GetComponent<Transform>();
        
        float rotacionZ = velocidadRotacion * Time.deltaTime;

        transform.Rotate(new Vector3(0, 0, rotacionZ));
    }
}
