using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing : MonoBehaviour
{
    Animator boxingController;
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxingController = GetComponent<Animator>();

    }
    void Update()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < 7)
        {
            boxingController.SetBool("Boxing", true);
        }
        else
            boxingController.SetBool("Boxing", false);

    }
}
