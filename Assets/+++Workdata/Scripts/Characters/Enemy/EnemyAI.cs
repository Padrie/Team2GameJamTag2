using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTarget;
    public float waitTimeAtCheckpoint;
    public List<Transform> waypoints = new List<Transform>();

    bool patrol = true;

    private void Start()
    {
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
        while (patrol)
        {
            yield return new WaitForSeconds(waitTimeAtCheckpoint);
        }
    }

    public void Chase()
    {

    }
}
