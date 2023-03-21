using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bg;

    private void Start()
    {
        float orthoSize = bg.bounds.size.y / 2;

        Camera.main.orthographicSize = orthoSize;
    }
}
