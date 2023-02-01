using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOnOff : MonoBehaviour
{
    public GameObject[] water;
    public float timer, interval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            for (int i = 0; i < water.Length; i++)
            {
                int randomValue = Random.Range(0, 3);
                if (randomValue == 0)
                {
                    water[i].SetActive(false);
                }
                else water[i].SetActive(true);
            }
            timer = 0;
        }
    }


}
