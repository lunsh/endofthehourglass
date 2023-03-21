using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolCheckBook : SymbolCheck
{
    [SerializeField] private GameObject bookUnlocked;
    [SerializeField] private GameObject bookLocked;

    public override void success()
    {
        GameManager.getInstance().SoundPlayer.playUnlockedSound();
        GameManager.getInstance().bookUnlocked = true;
        bookLocked.SetActive(false);
        bookUnlocked.SetActive(true);
    }
}
