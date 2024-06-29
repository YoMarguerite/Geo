using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject Instance;
    public float speed;
    public Camera myCamera;

    Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if(myCamera == null){
            myCamera = Camera.main;
        }
        Instance = this.gameObject;
    }

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = myCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,5));
            var step =  speed * Time.deltaTime;
            rigidBody.MovePosition(Vector3.MoveTowards(transform.position, touchPos, step));
        }
    }
}
