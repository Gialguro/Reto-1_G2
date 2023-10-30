using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingPoints: MonoBehaviour
{
    GameObject player;
    private NavMeshAgent nav;
    [SerializeField] bool playerNear;
    [SerializeField] float speedChase;

    [SerializeField] float patrolSpeed;
    [SerializeField] float patrolTimer;
    [SerializeField] float patrolWaitingTime;
    public Transform[] wayPoints;
    int wayPointsIndex;
    [SerializeField] int jugadorAtrapado;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear)
        {
            nav.destination = player.transform.position;
            nav.speed = speedChase;
        }
        else
        {
            Patrolling();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNear = false;
        }
    }

    public void Patrolling()
    {
        nav.speed = patrolSpeed;
        nav.stoppingDistance = jugadorAtrapado;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer > patrolWaitingTime)
            {
                wayPointsIndex = (wayPointsIndex + 1) % wayPoints.Length;
                patrolTimer = 0;
            }

            nav.destination = wayPoints[wayPointsIndex].position;
        }
    }

}