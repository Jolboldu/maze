using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    int index = 0;

    public float speed = 10.0f;
    public float health = 100.0f;
    
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;

    public Vector3 jump;
    public float jumpForce = 1.0f;
    public bool isGrounded;
    Rigidbody rb;
    LineRenderer lineRenderer;

    public MaterialController wall;

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
      // LineRenderer lineRenderer = GetComponent<LineRenderer>();
      // lineRenderer.SetPosition(index, transform.position);
        
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
