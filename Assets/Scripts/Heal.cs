using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public int value;
    public string provider = "heal";
    public Text text;

    bool collide = true;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        value = value + PlayerPrefs.GetInt(provider, 0);
        text.text = "+ " + value;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (collide)
        {
            Life player = col.gameObject.GetComponent<Life>();
            if (player != null)
            {
                player.Heal(value);

                Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
                text.transform.position = position;

                animator.SetTrigger("explode");
                collide = false;
            }
        }
    }
}
