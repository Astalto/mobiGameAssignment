using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
    private float gameScore;
    Rigidbody2D rb;

    public Transform explosion;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gameScore = 0;
    }

    void Update()
    {
        //Increment the score by 5 every second
        gameScore += Time.deltaTime * 5;
    }

    public void ReceiveInput(Vector2 swipeVector, float swipeDistance) {
        if (swipeVector.y > 0) {
            rb.AddForce(new Vector2(0, swipeVector.y) * 0.001f * swipeDistance);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pickups")
        {
            gameScore += 100;
            Destroy(other.gameObject);
        }
    }

    public float getScore()
    {
        return gameScore;
    }
}