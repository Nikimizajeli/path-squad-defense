using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    GameObject currentTarget;




    void Update()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Attacker>() && !otherObject.GetComponent<Satyr>())
        {
            currentTarget = otherObject;
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
    }

    private void StrikeTarget(int damage)
    {
        if (!currentTarget) { return; }
        currentTarget.GetComponent<Health>().DealDamage(damage);
    }
}
