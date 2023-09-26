using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIshAttack : MonoBehaviour
{
    public SpriteRenderer fish;
    // Start is called before the first frame update
    void Start()
    {
        fish = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            fish.flipX = true;
            print("Is Fish Rotate Collide Enter ");
            StartCoroutine(FlipOff());
        }
    }
    public IEnumerator FlipOff()
    {
        yield return new WaitForSeconds(0.3f);
        fish.flipX = false;
    }
}
