using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int crystalCost = 50;

    public int GetCrystalCost()
    {
        return crystalCost;
    }
}
