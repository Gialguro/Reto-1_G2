using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class EnemyLoose : MonoBehaviour
{
    [SerializeField] LifeManager lifeManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lifeManager.StartCoroutine("vidaJugador");
        }
    }

}
