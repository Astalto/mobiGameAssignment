using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material bgmat = mr.material;

        Vector2 offset = bgmat.mainTextureOffset;
        offset.x += Time.deltaTime / 4.0f;
        bgmat.mainTextureOffset = offset;

    }
}
