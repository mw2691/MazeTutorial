using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Goal goalObject;

    void Start()
    {
        // TODO you maybe want to find the goal object and store a reference
    }
       
    
	
	void Update () {
    // TODO: implement the locomotion here: W should move forward, S should move backward, S and D should rotate to the left and right, respectively.
    // Depending on the way you implement this, you might need an actual collision check to avoid moving through walls.
    // TODO: if you reach the goal the maze should restart (see the RestartGame function in the ControllerWithPlayer script)

    Rigidbody rb = this.GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.AddForce(Vector3.back);
        }

        if (Input.GetKey(KeyCode.A)){
            rb.AddTorque(Vector3.left);
        }

        if (Input.GetKey(KeyCode.S)){
            rb.AddTorque(Vector3.right);
        }
            
    }
}
