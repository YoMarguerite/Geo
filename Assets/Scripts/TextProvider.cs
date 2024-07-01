using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextProvider : MonoBehaviour
{
    public string provider;
    public TextMeshProUGUI text;
    
    public void LateUpdate()
    {
        int value = PlayerPrefs.GetInt(provider);
        text.text = value.ToString();
    }
}
