using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class BasicInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private string textToShow;
    [SerializeField] private string textToShow2;
    [SerializeField] private string textToShow3;
    [SerializeField] private string textToShow4;
    [SerializeField] private int waitTime;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setInteractCursor();
    }

    public void OnPointerExit(PointerEventData data)
    {
        GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
    }
    public void OnPointerClick(PointerEventData data)
    {
        GameManager gm = GameManager.getInstance();

        if ( gm.gameStage == 0 )
        {
            popupText.text = textToShow;
        } else if ( gm.gameStage == 1 )
        {
            popupText.text = textToShow2;
        } else if ( gm.gameStage == 2 )
        {
            popupText.text = textToShow3;
        } else
        {
            popupText.text = textToShow4;
        }
        StartCoroutine(popupText.GetComponent<TextFade>().fading());
        StartCoroutine(hideText());
    }

    private IEnumerator hideText()
    {
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(popupText.GetComponent<TextFade>().fadeOut());
    }
}
