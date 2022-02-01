using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    public GameObject ghost;
    public Animator anim;

    bool isChasing;
    // Start is called before the first frame update
    void Start()
    {
        isChasing = false;
        anim = GetComponent<Animator>();
        anim.speed = 0.3f;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xDifference = player.transform.position.x - ghost.transform.position.x;
        float yDifference = player.transform.position.x - ghost.transform.position.x;
        
        if (xDifference < 10 && xDifference > -10 && yDifference < 10 && yDifference > -10)
        {
            isChasing = true; 
        }
        if((xDifference > 25 || xDifference < -25) && (yDifference > 25 || yDifference < -25))
        {
            isChasing = false;
        }

        if (isChasing)
        {
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            agent.SetDestination(point);
        }
        

    }
}
