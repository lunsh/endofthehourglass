using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseovers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setInteractCursor();
    }

    public void OnPointerExit(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
    }
}
