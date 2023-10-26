using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 20f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Obtén la dirección del movimiento en el espacio mundial
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Aplica el movimiento en la dirección mundial
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Gira el objeto para que mire en la dirección del movimiento
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
