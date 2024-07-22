using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShockwave : MonoBehaviour
{
    void Start()
    {
        float value = PlayerPrefs.GetInt("shockwave");
        transform.localScale = new Vector3(1 + (value / 10), 1 + (value / 10), 1);
    }
}
