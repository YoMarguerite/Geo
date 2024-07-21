using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text text;
    public bool setNow = false;

    public void Update()
    {
        if (setNow)
        {
            int actual = PlayerPrefs.GetInt("actualfish");
            int fish = PlayerPrefs.GetInt("fish");
            int total = actual + fish;
            text.text = "You have won " + actual + " fish this game.\n" +
                "So now you have " + total + " fish !";
            setNow = false;
        }
    }
}
