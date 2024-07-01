using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    Vector3 cible;
    Vector3 direction;
    public float speed;
    public float distToDie;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        cible = GameManager.Instance.transform.position;
        direction = (cible - transform.position).normalized;
        direction = new Vector3(
            Random.Range(direction.x-(direction.x/2), direction.x+(direction.x/2)), 
            Random.Range(direction.y-(direction.y/2), direction.y+(direction.y/2))).normalized;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        Vector3 nextPos = transform.position + direction * step;
        rigidBody.MovePosition(nextPos);
        if(Vector3.Distance(transform.position, cible) > distToDie){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Projectile pr = col.gameObject.GetComponent<Projectile>();
        print(pr);
        if(pr == null){
            Destroy(this.gameObject);

        }
    }
}
