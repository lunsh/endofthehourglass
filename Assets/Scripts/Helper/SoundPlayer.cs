using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource lockedSound;
    [SerializeField] private AudioSource unlockedSound;
    [SerializeField] private AudioSource getSound;
    [SerializeField] private AudioSource recordPlayer;
    [SerializeField] private AudioClip[] recordSounds;
    [SerializeField] private AudioSource recordStop;
    [SerializeField] private AudioSource darkbell;
    [SerializeField] private AudioSource ticking;
    [SerializeField] private AudioSource endingSong;

    public float maxVolume;

    public void playEnding()
    {
        recordPlayer.Stop();
        ticking.Stop();
        endingSong.Play();
    }
    public void playTicking()
    {
        ticking.volume = maxVolume;
        ticking.Play();
    }

    public void playLockedSound()
    {
        lockedSound.Play();
    }
    public void playUnlockedSound()
    {
        unlockedSound.Play();
    }

    public void playGetSound()
    {
        getSound.Play();
    }

    public void playRecord(int recordToPlay)
    {
        recordPlayer.clip = recordSounds[recordToPlay];
        recordPlayer.Play();
    }

    public void stopRecord()
    {
        recordPlayer.Stop();
        recordStop.Play();
    }

    public void playDarkBell()
    {
        darkbell.Play();
    }
}
