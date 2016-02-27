using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerClass : MonoBehaviour {
    private float gameScore;
    Rigidbody2D rb;

    public Transform explosion;
    private Data data;
    private SpriteRenderer sprite;
    private BoxCollider2D box;
    // Use this for initialization
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        data = FindObjectOfType<Data>();
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
			rb.AddForce(new Vector2(0, swipeVector.y) * Mathf.Clamp(0.0005f * swipeDistance, 0.0f, 0.1f));
        }
		if (swipeVector.y < 0) {
			rb.AddForce(new Vector2(0, swipeVector.y) * Mathf.Clamp(0.0001f * swipeDistance, 0.0f, 0.1f));
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
            data.SetScore((int)gameScore);

            sprite.enabled = false;
            box.enabled = false;

            Destroy(other.gameObject);
            StartCoroutine(EndGame());
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

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}