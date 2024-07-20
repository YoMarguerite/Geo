using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile ops = collision.gameObject.GetComponent<Projectile>();
        if (ops != null)
        {
            Animator anim = ops.GetComponent<Animator>();
            anim.SetTrigger("explode");
        }
    }
}
