using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {

    public GameObject obstacle;
    private float coordY;
    private Vector2 objectPos;
    public Camera cam;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 3.0f, 5.0f);
		cam = FindObjectOfType<Camera>();
		objectPos.x = cam.orthographicSize * 1.5f;
	}

	void Update()
	{
		coordY = Random.Range(-cam.orthographicSize, cam.orthographicSize);
		objectPos.y = coordY;
	}

    void Spawn()
    {
        Instantiate(obstacle, objectPos, Quaternion.Euler(0.0f, 180.0f, 0.0f));
    }
}
