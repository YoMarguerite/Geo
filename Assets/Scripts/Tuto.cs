using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    Animator animator;
    Coroutine coroutine;
    public Transform cible;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetPosition();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                animator.SetBool("appear", false);
                coroutine = null;
            }
        }
        else
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(Appear());
            }
        }
    }

    IEnumerator Appear()
    {
        yield return new WaitForSecondsRealtime(2);
        SetPosition();
    }

    private void SetPosition()
    {
        Vector3 pos = -cible.position;
        transform.position = pos.normalized * 4;
        animator.SetBool("appear", true);
    }
}
