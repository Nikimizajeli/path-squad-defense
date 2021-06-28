using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    CrystalsDisplay crystalsDisplay;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";


    private void Start()
    {
        crystalsDisplay = FindObjectOfType<CrystalsDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        
        SpawnDefender(GetSquareClicked());
    }

    public void SetDefenderToSpawn(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 pos)
    {
        float newX = Mathf.RoundToInt(pos.x);
        float newY = Mathf.RoundToInt(pos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPosition)
    {
        if (crystalsDisplay.GetCurrentCrystals() >= defender.GetCrystalCost())
        {
            crystalsDisplay.SpendCrystals(defender.GetCrystalCost());
            Defender newDefender = Instantiate(defender, spawnPosition, Quaternion.identity);
            newDefender.transform.parent = defenderParent.transform;
        }
        
    }
}
