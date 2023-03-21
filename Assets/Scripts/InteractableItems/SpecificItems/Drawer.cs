using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drawer : ComplexInteractable
{
    [SerializeField] private GameObject drawerClosedPopup;
    [SerializeField] private GameObject drawerOpenPopup;

    public override void OnPointerClick(PointerEventData data)
    {
        popup.SetActive(true);
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
        foreach (Transform child in closeups.transform)
        {
            // hide all the children
            child.gameObject.SetActive(false);
        }
        if ( GameManager.getInstance().drawerUnlocked )
        {
            drawerOpenPopup.SetActive(true);
        } else
        {
            drawerClosedPopup.SetActive(true);
        }
    }
}
