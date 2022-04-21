using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    private bool isGameOver = false;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
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
            isGameOver = true;
        }

        else if (other.tag == "Enemy")
        {
            Debug.Log("Level Failed!!!");
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Button Clicked");
        //gameWonPanel.SetActive(false);
        //isGameWon = false;
    }
}
