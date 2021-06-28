using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalsDisplay : MonoBehaviour
{
    [SerializeField] int startingCrystals = 200;
    int currentCrystals;
    Text crystalText;

    private void Start()
    {
        crystalText = GetComponent<Text>();
        currentCrystals = startingCrystals;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        crystalText.text = currentCrystals.ToString();
    }

    public void AddCrystals(int crystalsAmount)
    {
        currentCrystals += crystalsAmount;
        UpdateDisplay();
    }

    public void SpendCrystals(int crystalsAmount)
    {
        currentCrystals -= crystalsAmount;
        UpdateDisplay();
    }

    public int GetCurrentCrystals()
    {
        return currentCrystals;
    }

}
