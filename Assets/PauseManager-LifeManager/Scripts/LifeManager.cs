using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager: MonoBehaviour
{
    public static int lifes = 3;
    public GameObject canvasLoose;
    public AudioSource looseSource;
    public AudioClip looseClip;

    public AudioSource hitSource;
    public AudioClip hitClip;

    public AudioSource inGameMusic;

    private void Start()
    {
        canvasLoose.SetActive(false);
    }
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    lifes--;
        //}

        if (lifes >= 3)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (lifes == 2)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (lifes == 1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }
        else if (lifes == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (lifes == 0) 
            {
                inGameMusic.Stop();
                lifes = 3;
                looseSource.PlayOneShot(looseClip);
                Time.timeScale = 0;
                canvasLoose.SetActive(true);
            }   
        }
    }

    public IEnumerator vidaJugador()
    {
        lifes--;
        hitSource.PlayOneShot(hitClip);
        yield return new WaitForSeconds(3);
    }
}