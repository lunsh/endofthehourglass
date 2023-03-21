using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RecordSmall : ComplexInteractable
{
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private string textToShow;
    [SerializeField] private int waitTime;
    public override void OnPointerClick(PointerEventData data)
    {

        if (GameManager.getInstance().playingRecord != 3)
        {
            popup.SetActive(true);
            GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
            foreach (Transform child in closeups.transform)
            {
                // hide all the children
                child.gameObject.SetActive(false);
            }

            popupToShow.SetActive(true);
            popupToShow.GetComponent<RecordSelect>().StartRecordShow();
        } else
        {
            popupText.text = textToShow;
            StartCoroutine(popupText.GetComponent<TextFade>().fading());
            StartCoroutine(hideText());
        }
    }

    private IEnumerator hideText()
    {
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(popupText.GetComponent<TextFade>().fadeOut());
    }
}
