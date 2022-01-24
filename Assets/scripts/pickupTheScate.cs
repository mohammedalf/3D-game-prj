using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupTheScate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Des;
    



    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = Des.position;
            this.transform.parent = GameObject.Find("dest").transform;
        }

        if (Input.GetKey(KeyCode.L))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
