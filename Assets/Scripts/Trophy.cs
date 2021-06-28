using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] GameObject crystalsVFX;
    [SerializeField] int crystalsPerCycle = 15;
    CrystalsDisplay crystalsDisplay;

    private void PlayCrystalsVFX()
    {
        GameObject newCrystalsVFXobject = Instantiate(crystalsVFX, transform.position, transform.rotation);
        Destroy(newCrystalsVFXobject, 1);
    }

    private void Start()
    {
        crystalsDisplay = FindObjectOfType<CrystalsDisplay>();
    }
    
    private void GenerateCrystals()
    {
        crystalsDisplay.AddCrystals(crystalsPerCycle);
    }
}
