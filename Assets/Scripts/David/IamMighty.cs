using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IamMighty : MonoBehaviour
{
    GameObject playerTag;

    private void Start()
    {
        playerTag = GameObject.FindWithTag("Player");
    }
    IEnumerator Destructor()
    {
        yield return new WaitForSeconds(3);


    }
}
