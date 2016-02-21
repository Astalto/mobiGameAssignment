using UnityEngine;
using System.Collections;

public class DebrisMovement : MonoBehaviour {
    private float speed = 2.0f;

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
