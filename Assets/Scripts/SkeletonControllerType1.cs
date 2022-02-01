using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonControllerType1 : MonoBehaviour
{

    public Vector3 velocity;
    int direction;
    public float speed = 0.02f;
    public LayerMask solids;
    private SpriteRenderer rend;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 1f, 0f);
        direction = 0;
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkable(transform.position + velocity * Time.deltaTime * speed))
        {
            if(direction == 0)
            {
                anim.Play("SkeletonUp");
            }
            else if(direction == 1)
            {
                anim.Play("SkeletonRight");
            }
            else if(direction == 2)
            {
                anim.Play("SkeletonDown");
            }
            else
            {
                anim.Play("SkeletonLeft");
            }
            transform.position = transform.position + velocity * Time.deltaTime * speed;
        }
        else
        {
            if(direction < 3)
            {
                direction++;
            }
            else
            {
                direction = 0;
            }
            if (direction == 0)
            {
                velocity = new Vector3(0f, 0.6f, 0f);
            }
            else if (direction == 1)
            {
                velocity = new Vector3(0.6f, 0f, 0f);
            }
            else if (direction == 2)
            {
                velocity = new Vector3(0f, -0.6f, 0f);
            }
            else
            {
                velocity = new Vector3(-0.6f, 0f, 0f);
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
