using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UkuleleTuningPeg : ComplexInteractable
{
    public override void OnPointerClick(PointerEventData data)
    {
        // take the tuning peg and close menus
        GameManager.getInstance().ukuleleSolved = true;
        GameManager.getInstance().GetComponent<Inventory>().tuningPeg = true;
        GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();

        popup.SetActive(false);
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
        if (closeups != null)
        {
            foreach (Transform child in closeups.transform)
            {
                // hide all the children
                child.gameObject.SetActive(false);
            }
        }
    }
}
