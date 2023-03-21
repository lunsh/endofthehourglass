using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFade : MonoBehaviour
{
    [SerializeField] private Animator bgAnim;
    [SerializeField] private int beforeFadeTime;

    private void Start()
    {
        StartCoroutine(fading());
    }

    IEnumerator fading()
    {
        yield return new WaitForSeconds(beforeFadeTime);

        bgAnim.SetBool("FadeIn", true);
        bgAnim.SetBool("FadeOut", false);
    }

    public void fadeOut()
    {

        bgAnim.SetBool("FadeIn", false);
        bgAnim.SetBool("FadeOut", true);
    }
}
