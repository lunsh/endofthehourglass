using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolCheckClock : SymbolCheck
{
    [SerializeField] private GameObject panelToClose;
    [SerializeField] private GameObject clockPanelClose;

    public override void success()
    {
        GameManager.getInstance().SoundPlayer.playDarkBell();
        GameManager.getInstance().GetComponent<CutsceneManager>().playNextCutscene();
        StartCoroutine(hidePanel());
    }

    IEnumerator hidePanel()
    {
        yield return new WaitForSeconds(1f);
        panelToClose.SetActive(false);
        clockPanelClose.SetActive(false);
        GameManager.getInstance().cuckooClockUnlocked = true;
    }
}
