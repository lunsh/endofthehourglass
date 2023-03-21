using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] records;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject popupRecord;

    private int heldRecord;
    private int shownRecord;
    public void StartRecordShow()
    {
        heldRecord = GameManager.getInstance().GetComponent<Inventory>().recordInHand;
        shownRecord = 0;

        foreach ( GameObject record in records )
        {
            record.SetActive(false);
        }

        if ( heldRecord == 0 || GameManager.getInstance().playingRecord == 0)
        {
            records[0].SetActive(false);
            records[1].SetActive(true);
            shownRecord = 1;
        } else
        {
            records[0].SetActive(true);
        }
    }

    public void PressUp()
    {
        records[shownRecord].SetActive(false);
        decreaseRecord();
        if ( shownRecord == heldRecord || shownRecord == GameManager.getInstance().playingRecord )
        {
            decreaseRecord();
        }
        records[shownRecord].SetActive(true);
    }

    public void PressDown()
    {
        records[shownRecord].SetActive(false);
        increaseRecord();
        if ( shownRecord == heldRecord || shownRecord == GameManager.getInstance().playingRecord)
        {
            increaseRecord();
        }
        records[shownRecord].SetActive(true);
    }

    private void decreaseRecord()
    {
        if (shownRecord - 1 < 0)
        {
            shownRecord = records.Length - 1;
        }
        else
        {
            shownRecord--;
        }
    }

    private void increaseRecord()
    {
        if (shownRecord + 1 >= records.Length)
        {
            shownRecord = 0;
        }
        else
        {
            shownRecord++;
        }
    }

    public void GetRecord()
    {
        GameManager.getInstance().GetComponent<Inventory>().recordInHand = shownRecord;
        GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();
        popupRecord.SetActive(false);
        popup.SetActive(false);
        GameManager.getInstance().SoundPlayer.playGetSound();
    }
}
