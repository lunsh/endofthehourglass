using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine.UIElements;
using System.IO;

public class Movement : MonoBehaviour
{

    private GameManager manager;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bg;

    //===Panning===
    private Vector3 touchStart;

    void Start()
    {
        if (GameManager.getInstance() != null)
        {
            manager = GameManager.getInstance();
        }
        else
        {
            Debug.Log("ERROR: Manager NOT FOUND");
        }


    }

    void Update()
    {
        if (manager.gameActive)
        {
            Panning();
        }
    }

    public void Panning()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if ( Input.GetMouseButton(0) )
        {
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
            direction.y = 0;
            direction.x = Mathf.Clamp(direction.x, bg.transform.position.x - bg.GetComponent<SpriteRenderer>().bounds.size.x / 2, bg.transform.position.x + bg.GetComponent<SpriteRenderer>().bounds.size.x / 2);
            cam.transform.position += direction;
            Vector3 tempCoords = cam.transform.position;

            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            tempCoords.x = Mathf.Clamp(tempCoords.x,
                bg.transform.position.x - bg.GetComponent<SpriteRenderer>().bounds.size.x / 2 + width / 2,
                bg.transform.position.x + bg.GetComponent<SpriteRenderer>().bounds.size.x / 2 - width / 2);
            cam.transform.position = tempCoords;
        }
    }
}

