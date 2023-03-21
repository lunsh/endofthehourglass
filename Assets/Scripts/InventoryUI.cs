using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject drawerKeyUI;
    [SerializeField] private GameObject handleUI;
    [SerializeField] private GameObject[] records;
    [SerializeField] private GameObject tuningPeg;

    private void Update()
    {
    }

    public void UpdateUI()
    {
        Inventory mainInventory = GameManager.getInstance().GetComponent<Inventory>();
        // drawer key
        if (mainInventory.drawerKey)
        {
            drawerKeyUI.SetActive(true);
        }
        else
        {
            drawerKeyUI.SetActive(false);
        }
        // records
        foreach (GameObject record in records)
        {
            record.SetActive(false);
        }
        if ( mainInventory.recordInHand != -1 )
        {
            records[mainInventory.recordInHand].SetActive(true);
        }
        // handle
        if (mainInventory.handle)
        {
            handleUI.SetActive(true);
        }
        else
        {
            handleUI.SetActive(false);
        }
        // tuning Peg
        if ( mainInventory.tuningPeg)
        {
            tuningPeg.SetActive(true);
        }
        else
        {
            tuningPeg.SetActive(false);
        }
    }
}
