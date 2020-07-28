using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static bool isPaused = false;
    public GameObject textObject;
    private bool isSolved = false;

    // Start is called before the first frame update
    void Start()
    {
        if(textObject)
        {
          textObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown("r"))
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
      }

      if(Input.GetKeyDown("escape"))
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

      if(Input.GetKeyDown("n"))
      {
        if(isSolved)
        {
          int newIndex = SceneManager.GetActiveScene().buildIndex + 1;
          PlayerPrefs.SetInt(newIndex.ToString(), newIndex);
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );        
        }
      }

    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
       {
        isSolved = true;
        textObject.SetActive(true);
       }
    }

    void Resume()
    {
      Time.timeScale = 1f;
      isPaused = false;
      // SceneManager.UnloadSceneAsync(0);
    }

    void Pause(){
      Time.timeScale = 0.0f;
      isPaused = true;
      // SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
