using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

    [Tooltip("Speed of the background/game")]
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
