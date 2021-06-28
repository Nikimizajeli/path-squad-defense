using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] int damage = 50;
    [SerializeField] bool pierce = false;
    
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            if (!pierce)
            {
                Destroy(gameObject);
            }
        }
    }

}
