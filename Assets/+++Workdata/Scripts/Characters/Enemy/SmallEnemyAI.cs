
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemyAI : MonoBehaviour
{
    [SerializeField] GameObject head;

    [Header("Patrol")]
    public Transform playerTarget;
    public float waitTimeAtCheckpoint;
    public List<Transform> waypoints = new List<Transform>();

    [Header("Chase")]
    public float chasePlayerDelay;

    NavMeshAgent agent;
    bool patrol = true;
    bool search = false;
    bool chase = false;

    int index = 0;

    public static event Action OnPlayerDied;
    public static event Action OnEnemyDied;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrol());
        StartCoroutine(Test());
    }

    private void Update()
    {
        if (playerTarget != null)
        {
            patrol = false;
            chase = true;
            Chase();
        }
        else
        {
            patrol = true;
            chase = false;
        }
    }

    IEnumerator Test()
    {
        while (true)
        {
            if (search)
            {
                print("Yurrrr");
            }

            yield return null;
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            print("AAAA");

            if (!patrol || waypoints.Count == 0)
            {
                yield return null;
                continue;
            }

            Transform currentWaypoint = waypoints[index];
            agent.SetDestination(currentWaypoint.position);

            while (patrol && Vector3.Distance(transform.position, currentWaypoint.position) > 1f)
            {
                yield return null;
            }

            if (patrol)
                yield return new WaitForSeconds(waitTimeAtCheckpoint);

            index = (index + 1) % waypoints.Count;

            yield return null;
        }
    }

    public void Chase()
    {
        if (chase)
            agent.SetDestination(playerTarget.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerDied?.Invoke();
        }        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            OnEnemyDied?.Invoke();
            Destroy(gameObject);
        }
    }
}
