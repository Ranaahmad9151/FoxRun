/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    private Vector3 startPosition;
    public Collider2D[] collider2DArray;
    *//*Vector2 point = transform.position;
    Vector2 size = transform.localScale;
    float angle = 0;*//*

    //public Vector2 Point { get => point; set => point = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        *//*if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(startPosition + " " + Input.mousePosition);
            collider2DArray = Physics2D.OverlapAreaAll(startPosition, Input.mousePosition);
            Debug.Log(collider2DArray.Length);
            foreach (Collider2D collider2D in collider2DArray)
            {
                Debug.Log(collider2D.name);
            }
        }*//*
        if (transform.name=="Circle")
        {
            startPosition = Input.mousePosition;
        }

        if (transform.name == "Circle")
        {
            Debug.Log(startPosition + " " + Input.mousePosition);
            collider2DArray = Physics2D.OverlapAreaAll(startPosition, Input.mousePosition );
            Debug.Log(collider2DArray.Length);
            foreach (Collider2D collider2D in collider2DArray)
            {
                Debug.Log(collider2D.name);
            }
        }

    }
    
}
*/