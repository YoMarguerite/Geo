using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject toClone;
    public float wait;
    void Start()
    {
        StartCoroutine(Generation(wait));
    }

    IEnumerator Generation(float timeToWait)
    {
        while(true){
            yield return new WaitForSeconds(timeToWait);
            GameObject clone = Instantiate(toClone, transform.position, Quaternion.identity);
            CircularMovement move = clone.GetComponent<CircularMovement>();
            move.speed = -Random.Range(move.speed - (move.speed / 2), move.speed + (move.speed / 2));
        }
    }
}
