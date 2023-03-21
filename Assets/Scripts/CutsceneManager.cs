using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cuckooclockLocked;
    [SerializeField] private GameObject cuckooclockUnocked;
    [SerializeField] private GameObject grandfatherClockLocked;
    [SerializeField] private GameObject grandfatherClockUnlocked;
    [SerializeField] private GameObject deskClockLocked;
    [SerializeField] private GameObject deskClockUnlocked;
    [SerializeField] private GameObject spooky1;
    [SerializeField] private GameObject spooky2;
    [SerializeField] private GameObject spooky3;

    [SerializeField] private GameObject cutscene1hide;
    [SerializeField] private GameObject cutscene1;
    [SerializeField] private GameObject cutsceneText1;
    [SerializeField] private GameObject cutsceneText12;
    [SerializeField] private GameObject cutsceneText13;
    [SerializeField] private GameObject cutsceneButton1;
    [SerializeField] private GameObject cutscene1Wrapper;

    [SerializeField] private GameObject cutscene2;
    [SerializeField] private GameObject cutsceneText2;
    [SerializeField] private GameObject cutsceneText22;
    [SerializeField] private GameObject cutsceneText23;
    [SerializeField] private GameObject cutsceneButton2;
    [SerializeField] private GameObject cutscene2Wrapper;

    [SerializeField] private GameObject cutscene3;
    [SerializeField] private GameObject cutsceneText3;
    [SerializeField] private GameObject cutsceneText32;
    [SerializeField] private GameObject cutsceneButton3;
    [SerializeField] private GameObject cutscene3Wrapper;

    private void Start()
    {
        GameManager.getInstance().gameActive = false;
        // play the first cutscene automatically
        cutscene1.SetActive(true);
        cutsceneText1.SetActive(true);
        cutsceneText12.SetActive(true);
        cutsceneText13.SetActive(true);
        cutsceneButton1.SetActive(true);
    }

    public void playNextCutscene()
    {
        int stage = GameManager.getInstance().gameStage;
        if ( stage == 0 ) // next cutscene is 2
        {
            startCutscene2();
        } else if ( stage == 1 ) // next cutscene is 3
        {
            startCutscene3();
        } else if ( stage == 2 ) // next cutscene is 4
        {
            startCutscene4();
        }
        GameManager.getInstance().gameStage++;
    }

    public void endCutscene1()
    {
        cutscene1hide.SetActive(false);
        cutscene1.GetComponent<BackgroundFade>().fadeOut();
        cutsceneButton1.GetComponent<BackgroundFade>().fadeOut();
        StartCoroutine(cutsceneText1.GetComponent<TextFade>().fadeOut());
        StartCoroutine(cutsceneText12.GetComponent<TextFade>().fadeOut());
        StartCoroutine(cutsceneText13.GetComponent<TextFade>().fadeOut());
        GameManager.getInstance().gameActive = true;
        StartCoroutine(cutscene1cleanup());
    }

    private IEnumerator cutscene1cleanup()
    {
        yield return new WaitForSeconds(1.5f);
        cutscene1Wrapper.SetActive(false);
    }

    public void startCutscene2()
    {
        GameManager.getInstance().gameActive = true;
        cutscene2.SetActive(true);
        cutsceneText2.SetActive(true);
        cutsceneText22.SetActive(true);
        cutsceneText23.SetActive(true);
        cutsceneButton2.SetActive(true);
    }

    public void endCutscene2()
    {
        cutscene2.GetComponent<BackgroundFade>().fadeOut();
        cutsceneButton2.GetComponent<BackgroundFade>().fadeOut();
        StartCoroutine(cutsceneText2.GetComponent<TextFade>().fadeOut());
        StartCoroutine(cutsceneText22.GetComponent<TextFade>().fadeOut());
        StartCoroutine(cutsceneText23.GetComponent<TextFade>().fadeOut());
        GameManager.getInstance().gameActive = true;
        GameManager.getInstance().SoundPlayer.maxVolume = 0.33f;
        GameManager.getInstance().SoundPlayer.playTicking();
        setupNextScene();
        spooky1.SetActive(false);
        spooky2.SetActive(true);
        StartCoroutine(cutscene2cleanup());
    }
    private IEnumerator cutscene2cleanup()
    {
        yield return new WaitForSeconds(1.5f);
        cutscene2Wrapper.SetActive(false);
    }

    public void startCutscene3()
    {
        GameManager.getInstance().gameActive = true;
        cutscene3.SetActive(true);
        cutsceneText3.SetActive(true);
        cutsceneText32.SetActive(true);
        cutsceneButton3.SetActive(true);
    }

    public void endCutscene3()
    {
        cutscene3.GetComponent<BackgroundFade>().fadeOut();
        cutsceneButton3.GetComponent<BackgroundFade>().fadeOut();
        StartCoroutine(cutsceneText3.GetComponent<TextFade>().fadeOut());
        StartCoroutine(cutsceneText32.GetComponent<TextFade>().fadeOut());
        GameManager.getInstance().gameActive = true;
        GameManager.getInstance().SoundPlayer.maxVolume = 0.66f;
        GameManager.getInstance().SoundPlayer.playTicking();
        setupNextScene();
        spooky2.SetActive(false);
        spooky3.SetActive(true);
        StartCoroutine(cutscene3cleanup());
    }
    private IEnumerator cutscene3cleanup()
    {
        yield return new WaitForSeconds(1.5f);
        cutscene3Wrapper.SetActive(false);
    }

    public void startCutscene4()
    {

    }

    private void setupNextScene()
    {
        GameManager gm = GameManager.getInstance();
        if ( gm.cuckooClockUnlocked )
        {
            cuckooclockLocked.SetActive(false);
            cuckooclockUnocked.SetActive(true);
        }
        if (gm.grandfatherClockUnlocked)
        {
            grandfatherClockLocked.SetActive(false);
            grandfatherClockUnlocked.SetActive(true);
        }
        if (gm.deskClockUnlocked)
        {
            deskClockLocked.SetActive(false);
            deskClockUnlocked.SetActive(true);
        }
    }
}
