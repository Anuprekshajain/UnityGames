using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Monster : MonoBehaviour {
  
    // Use this for initialization
    void Start()
    { 

    // Navigate to Castle
    GameObject castle = GameObject.Find("Castle");
        if (castle)
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
    }
    void OnTriggerEnter(Collider co)
    {
        // If castle then deal Damage
        if (co.name == "Castle")
        {
            co.GetComponentInChildren<Health>().decrease();
            Destroy(gameObject);
         
        
        }
    }
    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
       
    }
   
}
