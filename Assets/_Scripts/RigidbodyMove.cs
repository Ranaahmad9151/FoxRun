using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float m_Speed = 5f;
    public float m_Speed_Y = 5f;


    public Rigidbody2D link1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + new Vector3(m_Speed, 0,0) * Time.deltaTime);
        //link1.MovePosition(link1.gameObject.transform.position + new Vector3(0, m_Speed_Y, 0) * Time.deltaTime);
    }
}
