using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SecretBook : ComplexInteractable
{
    [SerializeField] private GameObject bookClosedPopup;
    [SerializeField] private GameObject bookOpenPopup;

    public override void OnPointerClick(PointerEventData data)
    {
        popup.SetActive(true);
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
        foreach (Transform child in closeups.transform)
        {
            // hide all the children
            child.gameObject.SetActive(false);
        }
        if ( GameManager.getInstance().bookUnlocked )
        {
            bookOpenPopup.SetActive(true);
        }
        else
        {
            bookClosedPopup.SetActive(true);
        }
    }
}
