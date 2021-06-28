using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satyr : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {

            if (otherObject.GetComponent<Knight>())
            {
                GetComponent<Animator>().SetTrigger("jumpTrigger");
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }

        }
    }

}
