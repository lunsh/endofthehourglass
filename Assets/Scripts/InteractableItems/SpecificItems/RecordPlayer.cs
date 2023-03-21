using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RecordPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private RecordArm recordArm;
    [SerializeField] private TextMeshProUGUI successText;
    [SerializeField] private GameObject recordImg;

    private bool playingRecord;
    private int recordToPlay;

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
        recordToPlay = GameManager.getInstance().GetComponent<Inventory>().recordInHand;

        // can only mess with the record if we haven't already solved it
        if (GameManager.getInstance().playingRecord != 3)
        {
            if (playingRecord)
            {
                recordArm.moveArmBack();
                playingRecord = false;
                recordImg.SetActive(false);
                GameManager.getInstance().GetComponent<Inventory>().recordInHand = recordToPlay;
                GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();

                GameManager.getInstance().playingRecord = -1;
                GameManager.getInstance().SoundPlayer.stopRecord();
            }
            else
            {
                if (recordToPlay == -1)
                {
                    // no record in hand
                    // play sound bleh
                }
                else
                {
                    playingRecord = true;
                    recordImg.SetActive(true);
                    GameManager.getInstance().playingRecord = GameManager.getInstance().GetComponent<Inventory>().recordInHand;
                    GameManager.getInstance().GetComponent<Inventory>().recordInHand = -1;
                    GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();
                    recordArm.moveArmOnRecord();

                    GameManager.getInstance().SoundPlayer.playRecord(recordToPlay);

                    if (GameManager.getInstance().playingRecord == 3) // correct record chosen
                    {
                        GameManager.getInstance().SoundPlayer.playUnlockedSound();
                        successText.gameObject.SetActive(true);
                        StartCoroutine(hideText());
                    }
                }
            }
        } else
        {
            successText.gameObject.SetActive(true);
            StartCoroutine(hideText());
        }
    }
    private IEnumerator hideText()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(successText.GetComponent<TextFade>().fadeOut());
    }
}
