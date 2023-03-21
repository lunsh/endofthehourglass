using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryDisplay;

    public bool drawerKey;
    public int recordInHand;
    public bool handle;
    public bool tuningPeg;

    private void Awake()
    {
        recordInHand = -1;
    }
}
