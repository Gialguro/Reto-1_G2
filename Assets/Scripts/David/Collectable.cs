using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectableController collectibleManager;

    // Llamado cuando un objeto colectable hace trigger con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destruye el objeto colectable
            Destroy(gameObject);

            // Si hay un CollectibleManager, notifica la destrucción
            if (collectibleManager != null)
            {
                collectibleManager.CollectibleDestroyed();
            }
        }
    }
}
