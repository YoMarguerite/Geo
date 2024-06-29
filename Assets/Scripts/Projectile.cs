using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 cible;
    Vector3 direction;
    public float speed;
    public float distToDie;
    public Animator anim;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        cible = GameManager.Instance.transform.position;
        direction = (cible - transform.position).normalized;
    }

    void Update()
    {
        var step =  speed * Time.deltaTime;
        Vector3 nextPos = transform.position + direction * step;
        rigidBody.MovePosition(nextPos);
        if(Vector3.Distance(transform.position, cible) > distToDie){
            anim.SetBool("appear", true);
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
}
