using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {

    public GameObject obstacle;
    private float coordY;
    private Vector2 objectPos;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 3.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
        coordY = Random.Range(-5.0f, 5.0f);
        objectPos.x = 6.68f;
        objectPos.y = coordY;
	}

    void Spawn()
    {
        Instantiate(obstacle, objectPos, Quaternion.Euler(0.0f, 180.0f, 0.0f));
    }
}
