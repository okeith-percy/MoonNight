using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    private BoxCollider2D me;
    private CameraController cameraRef;

    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<BoxCollider2D>();
        cameraRef = FindObjectOfType<CameraController>();
        // cameraRef.SetMapBounds(me);
    }

}
