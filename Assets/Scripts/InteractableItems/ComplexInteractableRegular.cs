using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComplexInteractableRegular : ComplexInteractable
{
    public override void OnPointerClick(PointerEventData data)
    {
        popup.SetActive(true);
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
        if ( closeups != null )
        {
            foreach (Transform child in closeups.transform)
            {
                // hide all the children
                child.gameObject.SetActive(false);
            }
        }
        if ( popupToShow != null )
        {
            popupToShow.SetActive(true);
        }
    }
}
