using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
	
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	public void ReceiveInput(Vector2 swipeVector, float swipeDistance) {
		rb.AddForce (new Vector2(0, swipeVector.y) * 0.001f * swipeDistance);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
    
}