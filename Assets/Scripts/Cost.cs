using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    [SerializeField]
    string CostName;

    [SerializeField]
    AudioClip Upgrade;

    [SerializeField]
    AudioClip Cancel;

    [SerializeField]
    AudioSource Source;

    public void Buy()
    {
        int actualValue = PlayerPrefs.GetInt(CostName, 1);
        int actualCost = PlayerPrefs.GetInt("cost" + CostName, 1);
        int actualMoney = PlayerPrefs.GetInt("fish");

        Source.clip = Cancel;

        if (actualMoney >= actualCost)
        {
            PlayerPrefs.SetInt("fish", actualMoney- actualCost);
            PlayerPrefs.SetInt(CostName, ++actualValue);
            PlayerPrefs.SetInt("cost" + CostName, actualCost * 2);
            PlayerPrefs.Save();
            Source.clip = Upgrade;
        }
        Source.Play();
    }
}
