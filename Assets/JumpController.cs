using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

    bool jumping = false;
    RaycastHit hit;
    Animator anim;

    Vector3 jumpOrigin;
    float velocityX;
    float velocityY;
    float gravity = 9.81f;
    float jumpTime = 0.0f;
    public float totalJumpTime = 2.0f;

    public Transform target;

    BoxCollider[] zones;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        zones = GetComponents<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, 2.0f))
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            print(hit.collider.gameObject.name);
        }
        else
        {
            if (!jumping)
            {
                Jump();
            }
        }
        jumpTime += Time.deltaTime;
        if(jumping)
        {
            Vector3 pos;
            pos.z = jumpOrigin.z + velocityX * jumpTime;
            pos.y = jumpOrigin.y + velocityY * jumpTime - (0.5f * gravity * Mathf.Pow(jumpTime , 2));
            pos.x = jumpOrigin.x;
            transform.position = pos;
            if(jumpTime > totalJumpTime - 0.05f)
            {
                jumping = false;
                anim.SetTrigger("land");
            }
        }

        

    }

    void Jump()
    {
        anim.SetTrigger("jump");


  }

    void Launch()
    {
        jumping = true;
        jumpOrigin = transform.position;

        jumpTime = 0.0f;

        landLoc[] landlocs = target.GetComponentsInChildren<landLoc>();

        foreach (landLoc l in landlocs)
        {
            Vector3 targetPos;
        }
        velocityX = (target.position.z - jumpOrigin.z) / totalJumpTime;

        velocityY = (target.position.y - jumpOrigin.y + (0.5f * gravity * Mathf.Pow(totalJumpTime, 2))) / totalJumpTime;
        print(velocityX + "  x" );
        if(velocityX > 5)
        {
            velocityX = 5;
        }
        

    }

}
