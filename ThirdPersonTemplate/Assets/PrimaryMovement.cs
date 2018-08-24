// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

/// < NOTES> 
/// Time.deltaTime scales _ according to my machine's frame rate
/// </NOTES>

public class PrimaryMovement : MonoBehaviour {

    public Rigidbody rb;
    public int smllr_pos_update = 12;
    public int sml_pos_update = 25;
    public int med_pos_update = 50;
    public int big_pos_update = 100;
    public float forwardFore = 2000f;

    void Start () {
        Debug.Log("My first print statement");
        rb.AddForce(0, sml_pos_update, sml_pos_update);
	}

    // Update is called once per frame
    void Update() {
    
    }

    // FixedUpdate is used for objects with physics
    void FixedUpdate () {
        
        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, smllr_pos_update); 
        }

        if (Input.GetKey("s")) {
            rb.AddForce(0, 0, -smllr_pos_update);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-smllr_pos_update , 0, 0);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(smllr_pos_update, 0, 0);
        }
        if (Input.GetKey("space"))
        {
            rb.AddForce(0, sml_pos_update, 0);
        }
    }
}
