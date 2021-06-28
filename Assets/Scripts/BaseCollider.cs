using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCollider : MonoBehaviour
{
    [SerializeField] float health = 5f;
    [SerializeField] GameObject lifeText;
    [SerializeField] GameObject loseCanvas;
    Text textComponent;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;

        if(Mathf.RoundToInt(health) <= 0)
        {
            HandleLoseCondition();
        }

        Destroy(collision.gameObject);
    }

    private void HandleLoseCondition()
    {
        Time.timeScale = 0;
        loseCanvas.SetActive(true);
        
                
    }

    private void Start()
    {
        health += PlayerPrefsController.GetDifficulty() * health;
        textComponent = lifeText.GetComponent<Text>();
        loseCanvas.SetActive(false);

    }

    private void Update()
    {
        textComponent.text = Mathf.RoundToInt(health).ToString();
    }


}
