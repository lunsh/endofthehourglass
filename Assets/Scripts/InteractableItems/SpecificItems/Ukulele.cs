using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ukulele : ComplexInteractable
{
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private string textToShow;
    [SerializeField] private int waitTime;

    // Start is called before the first frame update
    public override void OnPointerClick(PointerEventData data)
    {

        if (! GameManager.getInstance().ukuleleSolved )
        {
            popup.SetActive(true);
            GameManager.getInstance().GetComponent<CustomCursor>().setRegularCursor();
            foreach (Transform child in closeups.transform)
            {
                // hide all the children
                child.gameObject.SetActive(false);
            }

            popupToShow.SetActive(true);
        }
        else
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
