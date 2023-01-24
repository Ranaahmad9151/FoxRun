using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBricks : MonoBehaviour
{
    [SerializeField]
    GameObject mettalBricks;
    public GameObject[] spwanPoints;
    public bool isBricks=true;
    // Start is called before the first frame update
    void Start()
    {
        //demage.SetActive(true);
        isBricks = true;
        mettalBricks.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.name == "Player")
        {
            demage.SetActive(false);
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name== "Player"&& isBricks)
        {
            isBricks = false;
            StartCoroutine(SpwanObjects());
        }
        
            
    }
    
    IEnumerator SpwanObjects()
    {
        int randPoint = Random.Range(0, spwanPoints.Length);
            GameObject Bricks = Instantiate(mettalBricks, spwanPoints[randPoint].transform.position, Quaternion.identity);
            Bricks.GetComponent<Rigidbody2D>().velocity = new Vector2(Bricks.GetComponent<Rigidbody2D>().velocity.x, -5f);
            yield return new WaitForSeconds(3);
            isBricks = true;
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        demage.SetActive(true);
    }*/
}
