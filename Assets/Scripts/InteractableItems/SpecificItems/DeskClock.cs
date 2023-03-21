using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskClock : MonoBehaviour
{
    [SerializeField] private ClockHand minuteHand;
    [SerializeField] private ClockHand hourHand;
    [SerializeField] private float hourToCheck;
    [SerializeField] private float minuteToCheck;
    [SerializeField] private GameObject panelToClose;
    [SerializeField] private GameObject clockPanelClose;

    private float currentHour;
    private float currentMinute;

    private void Start()
    {
        minuteHand.onTimeChange += changeMinute;
        hourHand.onTimeChange += changeHour;
    }

    private void changeMinute(float minuteRotation)
    {
        currentMinute = minuteRotation;
        checkTime();
    }

    private void changeHour(float hourRotation)
    {
        currentHour = hourRotation;
        checkTime();
    }

    private void checkTime()
    {
        if ( currentHour == hourToCheck && currentMinute == minuteToCheck )
        {
            // success
            GameManager.getInstance().SoundPlayer.playDarkBell();
            GameManager.getInstance().GetComponent<CutsceneManager>().playNextCutscene();
            StartCoroutine(hidePanel());
        }
    }

    IEnumerator hidePanel()
    {
        yield return new WaitForSeconds(1f);
        panelToClose.SetActive(false);
        clockPanelClose.SetActive(false);
        GameManager.getInstance().deskClockUnlocked = true;
    }
}
