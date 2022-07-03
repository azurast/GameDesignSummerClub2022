using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All we need to know about MonoBehaviour is that it is a C# class that is recognized by Unity
public class Flappy : MonoBehaviour {
    /* STEP 1 : Define the properties the bird needs*/
    public float flapPower = 1;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start() {
        /* STEP 2 : Setting the properties */
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        /* STEP 3 : Detecting user input
            Whenever the frame changes, we want the bird to 'fly up' whenever we click on them 
        */
        if(Input.GetMouseButtonDown(0)&&GameManager.instance.isOnMainMenu==false)
            Flap();
    }

    // Flap is the function where you define the physics of the bird
    void Flap() {
        /* STEP 4 : Make the bird fly with some math & physics! */
        Debug.Log("Flap");
        rigidbody2D.velocity = Vector2.up * flapPower;
    }

    
	private void OnCollisionEnter2D(Collision2D collision)
	{
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GameManager.instance.MarkAsGameOver();
    }
}
