using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
        if(GameManager.instance.isGameOver==true){

            Destroy(this.gameObject);
        }
    }


//passing pipe increase score
    private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Bird"))
			{
				GameManager.instance.UpdateScore();
			}
		}


}
