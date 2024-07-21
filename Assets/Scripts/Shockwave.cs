using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IceCollision ops = collision.gameObject.GetComponent<IceCollision>();
        if (ops != null)
        {
            Animator anim = ops.GetComponent<Animator>();
            anim.SetTrigger("explode");
        }
    }
}
