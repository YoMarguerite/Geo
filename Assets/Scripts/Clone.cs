using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public float wait;
    void Start()
    {
        StartCoroutine(Generation(wait));
    }

    IEnumerator Generation(float timeToWait)
    {
        while(true){
            yield return new WaitForSeconds(timeToWait);
            GameObject clone = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            CircularMovement move = clone.GetComponent<CircularMovement>();
            move.speed = -Random.Range(move.speed - (move.speed / 2), move.speed + (move.speed / 2));
        }
    }
}
