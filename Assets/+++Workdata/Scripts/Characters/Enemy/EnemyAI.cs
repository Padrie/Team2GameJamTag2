using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrol")]
    public Transform playerTarget;
    public float waitTimeAtCheckpoint;
    public List<Transform> waypoints = new List<Transform>();
    [Header("Chase")]
    public float chasePlayerDelay;

    NavMeshAgent agent;
    bool patrol = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrol());
    }

    private void Update()
    {
        if (playerTarget != null)
        {
            patrol = false;
            Chase();
        }
        else
        {
            patrol = true;
        }
    }

    IEnumerator Patrol()
    {
        int index = 0;
        while (patrol)
        {
            if (waypoints.Count == 0) yield break;

            Transform currentWaypoint = waypoints[index];
            agent.SetDestination(currentWaypoint.position);

            while (Vector3.Distance(transform.position, currentWaypoint.position) > 1)
            {
                yield return null;
            }

            yield return new WaitForSeconds(waitTimeAtCheckpoint);

            index = (index + 1) % waypoints.Count;
        }
    }

    IEnumerator FoundPlayer()
    {
        yield return new WaitForSeconds(chasePlayerDelay);
    }

    public void Chase()
    {

    }
}
