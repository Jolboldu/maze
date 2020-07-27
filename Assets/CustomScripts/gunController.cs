using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunController : MonoBehaviour
{
    public float damage = 20.0f;
    public float range = 1000.0f;
    public int ammunition = 8;
    
    private AudioSource sound;
    public GameObject myTextgameObject;
    private Text ourComponent;
    public Camera cam;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        ourComponent = myTextgameObject.GetComponent<Text>();
        ourComponent.text = ammunition.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
          // StartCoroutine("Shoot");
          if(ammunition > 0)
          {
            Shoot();
            sound.Play();
            ammunition--;
            ourComponent.text = ammunition.ToString();

          }
        }
    }

    void Shoot()
    {
      RaycastHit hit;
      // flash.Play();

      if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
      {
        
        Enemy enemy = hit.transform.GetComponent<Enemy>();
        if(enemy != null)
        { if (ammunition > 0)
          {
            enemy.TakeDamage(damage);
          }
        }

      }
    }
}
