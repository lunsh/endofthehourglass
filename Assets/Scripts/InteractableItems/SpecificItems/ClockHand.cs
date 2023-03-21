using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClockHand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject timeButton;
    [SerializeField] private GameObject timeHand;

    public UnityAction<float> onTimeChange;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setInteractCursor();
    }

    public void OnPointerExit(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
    }
    public void changeTime()
    {
        timeHand.transform.rotation *= Quaternion.Euler(0, 0, -30f);
        onTimeChange?.Invoke(timeHand.transform.localEulerAngles.z);
    }

}
