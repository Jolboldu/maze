using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public PlayerController player;
    public int trampolineCounter = 1;
    public int jumpForce = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
       {
         if(trampolineCounter > 0)
         {
            player.Jump(jumpForce);
            trampolineCounter--;
         }
       }
    }
}
