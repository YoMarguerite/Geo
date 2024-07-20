using System.Collections;
using UnityEngine;

public class Life : MonoBehaviour
{
    int life;
    public int lifeMax;
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        lifeMax = lifeMax + PlayerPrefs.GetInt("lifemax", 0);
        life = lifeMax;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();
    }

    public void Heal(int value)
    {
        life += value;
        life = life > lifeMax ? lifeMax : life;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();
    }

    public void Damage(int value)
    {
        life -= value;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();
        if(life < 1){
            anim.SetBool("appear", true);
            Time.timeScale = 0;
        }
    }
}
