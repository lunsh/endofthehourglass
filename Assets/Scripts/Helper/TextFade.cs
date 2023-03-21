using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    [SerializeField] private Animator textAnim;
    [SerializeField] private int fadeinWaitTime;
    [SerializeField] private int fadeoutWaitTime;

    private void Start()
    {
        StartCoroutine(fading());
    }

    public IEnumerator fading()
    {
        yield return new WaitForSeconds(fadeinWaitTime);

        textAnim.SetBool("TextFade", true);
        textAnim.SetBool("TextFadeOut", false);
    }

    public IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(fadeoutWaitTime);
        textAnim.SetBool("TextFade", false);
        textAnim.SetBool("TextFadeOut", true);
    }
}
