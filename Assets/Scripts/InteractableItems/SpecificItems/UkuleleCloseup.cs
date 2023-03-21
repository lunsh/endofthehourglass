using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkuleleCloseup : MonoBehaviour
{
    [SerializeField] private GameObject ukuleleCloseup;
    [SerializeField] private GameObject ukuleleSuccess;

    [SerializeField] private GameObject[] noteObjects;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] noteAudios;

    private Queue<int> notesPlayed;

    private void Start()
    {
        notesPlayed = new Queue<int>();
    }

    public void playNote(int noteId)
    {
        notesPlayed.Enqueue(noteId);
        if ( notesPlayed.Count > 4 )
        {
            notesPlayed.Dequeue();
        }
        audioSource.clip = noteAudios[noteId];
        audioSource.Play();
        checkQueue();
    }

    private void checkQueue()
    {
        string check = "";
        foreach (int value in notesPlayed)
        {
            check += value;
        }
        if ( check == "1302" )
        {
            StartCoroutine(success());
        }
    }

    private IEnumerator success()
    {
        yield return new WaitForSeconds(1);
        ukuleleCloseup.SetActive(false);
        ukuleleSuccess.SetActive(true);
        // play sound clunk
    }
}
