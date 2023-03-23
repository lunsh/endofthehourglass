using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndingDoor : ComplexInteractable
{
    public override void OnPointerClick(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CutsceneManager>().playEnding();
    }
}
