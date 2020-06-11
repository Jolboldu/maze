using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public float damage = 20.0f;
    public float range = 1000.0f;
    public ParticleSystem flash;

    public Camera cam;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
          // StartCoroutine("Shoot");
          Shoot();
        }
    }

    void Shoot()
    {
      RaycastHit hit;
      flash.Play();

      if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
      {
        
        Enemy enemy = hit.transform.GetComponent<Enemy>();
        if(enemy != null)
        {
          enemy.TakeDamage(damage);
        }

        Debug.Log(hit.transform.name);
        // Debug.Log(hit.collider.tag);

      }
    }
}
