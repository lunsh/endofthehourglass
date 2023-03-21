using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ComplexInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject popup;
    public GameObject closeups;
    public GameObject popupToShow;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setInteractCursor();
    }

    public void OnPointerExit(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
    }
    public abstract void OnPointerClick(PointerEventData data);
}
