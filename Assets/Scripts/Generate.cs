using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject toGenerate;
    public Animator toGive;
    public float wait;
    void Start()
    {
        StartCoroutine(Generation(wait));
    }

    IEnumerator Generation(float timeToWait)
    {
        while(true){
            yield return new WaitForSeconds(timeToWait);
            GameObject projectile = Instantiate(toGenerate, transform.position, Quaternion.identity);
            Projectile p = projectile.GetComponent<Projectile>();
            if(p != null){
                p.anim = toGive;
            }
        }
    }
}
