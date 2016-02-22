using UnityEngine;
using System.Collections;

public class SceneTiling : MonoBehaviour {
    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingOrder = -1;
        Debug.Log(GetComponent<Renderer>().sortingLayerName);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 bgOffset = new Vector2(Time.time * speed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = bgOffset;
	}
}
