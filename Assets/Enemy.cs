using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 100.0f;
    private NavMeshAgent agent;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    
    }

    // Update is called once per frame
    void Update()
    {
      agent.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
       {
          player.TakeDamage(50.0f);
       }
    }

    public void TakeDamage(float amount)
    {
      Debug.Log(health);
      health-= amount;
      if(health <= 0)
      {
        Destroy(gameObject);
      }
    }
}
