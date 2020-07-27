using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public float speed = 30.0f;
    public float health = 100.0f;
    

    private Vector3 jump;
    public float jumpForce = 1.0f;
    private bool isGrounded;
    Rigidbody rb;

    public GameObject myTextgameObject;

    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;   
      rb = GetComponent<Rigidbody>();
      jump = new Vector3(0.0f, 2.0f, 0.0f); 
    }


    // Update is called once per frame
    void Update()
    {
        
      if(isGrounded)
      {
        float forward  = Input.GetAxis("Vertical") * speed;
        float sideways  = Input.GetAxis("Horizontal") * speed;

        forward *= Time.deltaTime;
        sideways *= Time.deltaTime;
        
        transform.Translate(sideways, 0, forward);
      }
      

      if(Input.GetKeyDown("escape"))
      {
        Cursor.lockState = CursorLockMode.None;
      }

      if(Input.GetKeyDown("e"))
      {
        if(myTextgameObject)
        {
            Destroy(myTextgameObject);
        }
      }


    }
    
    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Ground")
       {
          isGrounded = true;
       }
    }


    public void TakeDamage(float amount)
    {
      health-= amount;
      if(health <= 0)
      {
        Application.Quit();
        Destroy(gameObject);
      }
    } 

    public void Jump(float amount)
    {
        isGrounded = false;
        rb.AddForce(jump * amount * jumpForce, ForceMode.Impulse);
    } 
}
