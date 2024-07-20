using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject toGenerate;
    public float wait;
    void Start()
    {
        StartCoroutine(Generation(wait));
    }

    IEnumerator Generation(float timeToWait)
    {
        while(true){
            yield return new WaitForSeconds(timeToWait);
            Instantiate(toGenerate, transform.position, Quaternion.identity);
        }
    }
}
