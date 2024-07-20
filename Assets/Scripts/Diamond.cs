using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    Vector3 cible;
    Vector3 direction;
    public float speed;
    public float distToDie;

    public int value;
    public string provider = "diamond";
    bool collide = true;

    Rigidbody2D rigidBody;
    Animator animator;

    void Start()
    {
        value = value + PlayerPrefs.GetInt("value" + provider, 0);

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        cible = GameManager.Instance.transform.position;
        direction = (cible - transform.position).normalized;
        direction = new Vector3(
            Random.Range(direction.x-(direction.x/2), direction.x+(direction.x/2)), 
            Random.Range(direction.y-(direction.y/2), direction.y+(direction.y/2))).normalized;
        rigidBody.velocity = direction;
    }

    void Update()
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
                int actual = PlayerPrefs.GetInt(provider);
                PlayerPrefs.SetInt(provider, actual + value);
                PlayerPrefs.Save();
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
        Destroy(this.gameObject);
    }
}
