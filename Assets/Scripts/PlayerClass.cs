using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerClass : MonoBehaviour {
    private float gameScore;
    Rigidbody2D rb;

    public Transform explosion;
    public BoxCollider2D box;
    private Data data;
    private SpriteRenderer sprite;
    private bool isDead = false;
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
        if (!isDead)
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
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Floor")
        {
        	isDead = true;
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            data.SetScore((int)gameScore);
            sprite.enabled = false;
            box.enabled = false;
            Destroy(other.gameObject);
            StartCoroutine(EndGame());
        }

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
        data.SetHighscoreArray(gameScore);
        SceneManager.LoadScene(2);
    }
}