using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 cible;
    Vector3 direction;
    bool collide = true;
    public float speed;
    public float distToDie;
    Rigidbody2D rigidBody;
    Animator animator;
    public GameObject shockwave;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        cible = GameManager.Instance.transform.position;
        direction = (cible - transform.position).normalized;
        rigidBody.velocity = direction * speed;

        float rad = Mathf.Atan2(direction.y, direction.x);
        float angle = rad * (180/Mathf.PI);
        Quaternion rotation = Quaternion.Euler(new Vector3(0,0,angle));
        transform.rotation = rotation;
    }

    void LateUpdate()
    {
        if(Vector3.Distance(transform.position, cible) > distToDie){
            
            Destroy(this.gameObject);
        }
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
            }
        }
    }

    public void StartExplode()
    {
        collide = false;
    }

    public void EndExplode()
    {
        Destroy(gameObject);
    }
}
