using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // You must set the cursor in the inspector.
    [SerializeField] private Texture2D regularCursor;
    [SerializeField] private Texture2D interactCursor;

    void Start()
    {
        setRegularCursor();
    }

    public void setRegularCursor()
    {
        //set the cursor origin to its centre. (default is upper left corner)
        Vector2 cursorOffset = new Vector2(0, 0);
        Cursor.SetCursor(regularCursor, cursorOffset, CursorMode.Auto);
    }

    public void setInteractCursor()
    {
        //set the cursor origin to its centre. (default is upper left corner)
        Vector2 cursorOffset = new Vector2(interactCursor.width / 2, interactCursor.height / 2);
        Cursor.SetCursor(interactCursor, cursorOffset, CursorMode.Auto);
    }
}
