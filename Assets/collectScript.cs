using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectScript : MonoBehaviour
{
    public float randomX;
    public float randomZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Moving");
            randomX = Random.Range(-4f, 4f);
            randomZ = Random.Range(-4f, 5f);
            this.transform.position = new Vector3(randomX, 0f, randomZ);
        }
    }
}
