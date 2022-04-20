using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    private bool isGameWon = false;
    public GameObject gameWonPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameWon)
        {
            return;
        }
        if(Input.GetAxis("Horizontal") > 0) // It is positive //Right button or D key
        {
            rigidbody2D.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0) // It is negative //Left Button or A Key
        {
            rigidbody2D.velocity = new Vector2(-speed, 0f);
        }

        else if (Input.GetAxis("Vertical") > 0) // It is positive //Up button or W key
        {
            rigidbody2D.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)// It is negative //Down button or S key
        {
            rigidbody2D.velocity = new Vector2(0f, -speed);
        }
        else if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            //stop
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Complete!!!");
            gameWonPanel.SetActive(true);
            isGameWon = true;
        }
    }

    private void
}
