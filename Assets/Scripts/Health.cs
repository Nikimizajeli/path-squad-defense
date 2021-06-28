using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int crystalsReward = 20;
    CrystalsDisplay crystalsDisplay;

    int currentHealth;
    void Start()
    {
        currentHealth = startingHealth;
        crystalsDisplay = FindObjectOfType<CrystalsDisplay>();
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (!GetComponent<Trophy>())
            {
                GetComponent<Animator>().SetTrigger("deathTrigger");
                PlayDeathVFX();
            }
            else
            {
                HandleDeath();
            }
            

        }
    }

    private void HandleDeath()
    {
        Destroy(gameObject);
        
        crystalsDisplay.AddCrystals(crystalsReward);
    }

    private void PlayDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        
        
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 1);
        

    }


}
