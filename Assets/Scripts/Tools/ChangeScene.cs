using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeFish(int fish)
    {
        if (fish == -1)
        {
            fish = PlayerPrefs.GetInt("actualfish");
        }
        int value = PlayerPrefs.GetInt("fish");
        PlayerPrefs.SetInt("fish", value + fish);
        PlayerPrefs.SetInt("actualfish", 0);
    }

    public void Change(string scene){
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
