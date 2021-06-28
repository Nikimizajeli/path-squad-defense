using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : MonoBehaviour
{
    AttackerSpawner[] spawners;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    private void ChangeLane()
    {
        int newLaneIndex = Random.Range(1, 5);
        transform.position = new Vector3(transform.position.x, newLaneIndex, transform.position.z);

        SetNewParentSpawner();

    }

    private void SetNewParentSpawner()
    {
        spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            if (Mathf.Abs(spawner.transform.position.y - transform.position.y) < Mathf.Epsilon)
            {
                transform.parent = spawner.transform;
            }
        }
    }
}
