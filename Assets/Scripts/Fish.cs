using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public int value;
    public string provider = "fish";
    public Text text;

    bool collide = true;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        value = value + PlayerPrefs.GetInt("value" + provider, 0);
        text.text = "+ " + value;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (collide)
        {
            Life player = col.gameObject.GetComponent<Life>();
            if (player != null)
            {
                int actual = PlayerPrefs.GetInt(provider);
                PlayerPrefs.SetInt(provider, actual + value);
                PlayerPrefs.Save();

                Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
                text.transform.position = position;

                animator.SetTrigger("explode");
                collide = false;
            }
        }
    }
}
