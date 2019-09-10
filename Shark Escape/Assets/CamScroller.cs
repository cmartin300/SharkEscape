using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScroller : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var camPosition = cam.transform.position;
        camPosition.y -= moveSpeed * Time.deltaTime;
        cam.transform.position = camPosition;
    }
}
