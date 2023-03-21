using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject closeups;


    public void closePopup()
    {
        foreach( Transform child in closeups.transform)
        {
            // hide all the children
            child.gameObject.SetActive(false);
        }
        popup.SetActive(false);
    }
}
