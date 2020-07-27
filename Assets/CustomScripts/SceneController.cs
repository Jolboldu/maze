using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown("n"))
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
      }

      if(Input.GetKeyDown("p"))
      {

        if(isPaused)
        {
          Resume();
        }
        else
        {
          Pause();
        }
      }
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
       {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
       }
    }

    void Resume()
    {
      Time.timeScale = 1f;
      isPaused = false;
      SceneManager.UnloadSceneAsync(0);
    }

    void Pause(){
      Time.timeScale = 0.0f;
      isPaused = true;
      SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
