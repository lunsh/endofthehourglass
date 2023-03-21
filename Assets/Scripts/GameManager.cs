using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // inception (also known as: singleton pattern)
    private static GameManager instance;
    [SerializeField] public SoundPlayer SoundPlayer;

    public bool gameActive;
    public int gameStage;

    public bool bookUnlocked;
    public bool drawerUnlocked;
    public bool cuckooClockUnlocked;
    public bool grandfatherClockUnlocked;
    public bool deskClockUnlocked;
    public int playingRecord;
    public bool handlePlaced;
    public bool ukuleleSolved;
    public bool jewelryBoxOpen;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            // inception
            instance = this;
        }

        gameActive = true;
        playingRecord = -1;
    }

    public static GameManager getInstance()
    {
        return instance;
    }
}
