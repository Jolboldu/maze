using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
      float forward  = Input.GetAxis("Vertical") * speed;
      float sideways  = Input.GetAxis("Horizontal") * speed;
      
      forward *= Time.deltaTime;
      sideways *= Time.deltaTime;
      
      transform.Translate(sideways, 0, forward);

      if(Input.GetKeyDown("escape"))
      {
        Cursor.lockState = CursorLockMode.None;   

      }   
    }
}
