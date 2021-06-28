using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    [SerializeField] GameObject clickHereArrows;

    private void Start()
    {
        SetCostButtonText();
        clickHereArrows.SetActive(true);
    }

    private void SetCostButtonText()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetCrystalCost().ToString();
    }

    private void OnMouseDown()
    {
        if (clickHereArrows.activeInHierarchy) { clickHereArrows.SetActive(false); }

        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons){
            button.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetDefenderToSpawn(defenderPrefab);
    }
}
