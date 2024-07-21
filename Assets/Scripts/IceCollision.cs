using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollision : MonoBehaviour
{
    Animator animator;
    public GameObject shockwave;
    bool collide = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (collide)
        {
            Life player = col.gameObject.GetComponent<Life>();
            if (player != null)
            {
                player.Damage(1);
                Instantiate(shockwave, col.GetContact(0).point, Quaternion.identity);
                animator.SetTrigger("explode");
                collide = false;
            }
        }
    }
}
