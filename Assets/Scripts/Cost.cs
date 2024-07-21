using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    [SerializeField]
    string CostName;

    public void Buy()
    {
        int actualValue = PlayerPrefs.GetInt(CostName, 1);
        int actualCost = PlayerPrefs.GetInt("cost" + CostName, 1);
        int actualMoney = PlayerPrefs.GetInt("fish");

        if(actualMoney >= actualCost)
        {
            PlayerPrefs.SetInt("fish", actualMoney- actualCost);
            PlayerPrefs.SetInt(CostName, ++actualValue);
            PlayerPrefs.SetInt("cost" + CostName, actualCost * 2);
            PlayerPrefs.Save();
        }
    }
}
