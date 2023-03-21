using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecordBox : ComplexInteractable
{
    [SerializeField] private GameObject boxClosedPopup;
    [SerializeField] private GameObject boxOpenPopup;
    public override void OnPointerClick(PointerEventData data)
    {
        popup.SetActive(true);
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
        foreach (Transform child in closeups.transform)
        {
            // hide all the children
            child.gameObject.SetActive(false);
        }

        if (GameManager.getInstance().playingRecord != 3)
        {
            boxClosedPopup.SetActive(true);
        }
        else
        {
            boxOpenPopup.SetActive(true);
        }
    }
}
