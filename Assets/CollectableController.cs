using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public GameObject cherryItem;
    public int collectiblesToActivateCherry = 15;

    private List<GameObject> collectibles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Obtén todos los objetos colectables como hijos del objeto padre
        foreach (Transform child in transform)
        {
            collectibles.Add(child.gameObject);
        }

        // Asegúrate de que el item Cherry esté desactivado al principio
        cherryItem.SetActive(false);
    }

    // Llamado cuando un objeto colectable es destruido
    public void CollectibleDestroyed()
    {
        // Reduce el contador de colectables restantes
        collectiblesToActivateCherry--;

        // Si se destruyeron suficientes colectables, activa el item Cherry
        if (collectiblesToActivateCherry <= 0)
        {
            cherryItem.SetActive(true);
        }
    }

    // Llamado cuando un objeto colectable hace trigger con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destruye el objeto colectable y llama a CollectibleDestroyed
            Destroy(gameObject);
            CollectibleDestroyed();
        }
    }
}
