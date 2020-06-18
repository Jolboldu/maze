using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float health = 100.0f;

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
      if(transform.position.z < -42.0f)
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
      }
    }

    public void TakeDamage(float amount)
    {
      health-= amount;
      if(health <= 0)
      {
        Application.Quit();
        // Destroy(gameObject);
      }
    } 
}
