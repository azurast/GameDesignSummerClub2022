using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All we need to know about MonoBehaviour is that it is a C# class that is recognized by Unity
public class BirdMovement_Finished : MonoBehaviour {
    /* STEP 1 : Define the properties the bird needs
        - rigidBody will be used to access the bird's physical properties like velocity & direction
        - jumpForce will be used to define how big the force of each jump the bird will do
     */
    Rigidbody2D rigidBody;
    public float jumpForce;

    // Start is called before the first frame update
    void Start() {
        /* STEP 2 : Setting the properties
            Now that we have define that the bird needs this property we need to find a way to access it.
            Since we want the properties to be available from the beginning of the game, we put it in this Start() method.
            We use this by 'getting' that previously attached component like this. 
        */ 
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        /* STEP 3 : Detecting user input
            Whenever the frame changes, we want the bird to 'fly up' whenever we click on them 
        */
        if (Input.GetMouseButtonDown(0)) {
            Flap();
        }
    }

    // Flap is the function where you define the physics of the bird
    void Flap() {
        /* STEP 4 : Make the bird fly with some math & physics! */
        rigidBody.velocity = Vector2.up * jumpForce;
    }
}
