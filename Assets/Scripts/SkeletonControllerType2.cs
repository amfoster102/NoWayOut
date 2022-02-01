using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonControllerType2 : MonoBehaviour
{

    public Vector3 velocity;
    bool walkingUp;
    public float speed = 0.2f;
    public LayerMask solids;
    private SpriteRenderer rend;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 35f, 0f);
        walkingUp = false;
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkable(transform.position + velocity * Time.deltaTime * speed))
        {
            if (walkingUp)
            {
                anim.Play("SkeletonUp");
            }
            else
            {
                anim.Play("SkeletonDown");
            }
            transform.position = transform.position + velocity * Time.deltaTime * speed;
        }

        else
        {
            if (walkingUp)
            {
                walkingUp = false;
                velocity = new Vector3(0f, -35.0f, 0f);
            }
            else
            {
                walkingUp = true;
                velocity = new Vector3(0f, 35.0f, 0f);
            }
        }
            
    }


    private bool isWalkable(Vector3 target)
    {
        if (Physics2D.OverlapCircle(target, 1f, solids) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
