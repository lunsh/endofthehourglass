using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandfatherClock : MonoBehaviour
{
    [SerializeField] private GameObject panelToClose;
    [SerializeField] private GameObject clockPanelClose;
    [SerializeField] private GameObject handle;
    public void placeHandle()
    {
        if ( GameManager.getInstance().GetComponent<Inventory>().handle )
        {
            GameManager.getInstance().SoundPlayer.playDarkBell();
            handle.SetActive(true);
            GameManager.getInstance().GetComponent<Inventory>().handle = false;
            GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();
            GameManager.getInstance().GetComponent<CutsceneManager>().playNextCutscene();
            StartCoroutine(hidePanel());
        } else
        {
            GameManager.getInstance().SoundPlayer.playLockedSound();
        }
    }

    IEnumerator hidePanel()
    {
        yield return new WaitForSeconds(1f);
        panelToClose.SetActive(false);
        clockPanelClose.SetActive(false);
        GameManager.getInstance().grandfatherClockUnlocked = true;
    }
}
