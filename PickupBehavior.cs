using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public static int radishCount;
    public static int carrotCount;
    public static int gingerCount;

    public AudioClip pickupSFX;
    public string playerTag;
  

    // Start is called before the first frame update
    void Start()
    {
        //pickupCount++;
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            Destroy(gameObject);
            //Debug.Log("Picked up");
            //AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);  
        }
    }

    private void OnDestroy()
    {
        if (gameObject.CompareTag("Radish")) {
            radishCount++;
            Debug.Log(radishCount);
        }
        if (gameObject.CompareTag("Carrot")) {
            carrotCount++;
        }
        if (gameObject.CompareTag("Ginger")) {
            gingerCount++;
        }
    }
}