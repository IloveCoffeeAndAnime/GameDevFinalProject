using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour {

    public static CameraScreen current;

    private Vector2 screenSize;
    private Vector3 cameraPos;

    public Vector2 ScreenSize { get { return screenSize; } }

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start () {
        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
