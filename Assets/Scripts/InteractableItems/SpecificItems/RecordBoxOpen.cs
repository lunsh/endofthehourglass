using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordBoxOpen : MonoBehaviour
{
    [SerializeField] private GameObject handle;

    private Inventory mainInventory;

    private void Start()
    {
        mainInventory = GameManager.getInstance().GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainInventory.handle || GameManager.getInstance().handlePlaced)
        {
            handle.SetActive(false);
        }
    }

    public void getHandle()
    {
        mainInventory.handle = true;
        GameManager.getInstance().SoundPlayer.playGetSound();
        GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();
    }

    public void locked()
    {
        GameManager.getInstance().SoundPlayer.playLockedSound();
    }
}
