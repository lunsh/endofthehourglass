using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBookUnlocked : MonoBehaviour
{
    [SerializeField] private GameObject key;

    private Inventory mainInventory;

    private void Start()
    {
        mainInventory = GameManager.getInstance().GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( mainInventory.drawerKey || GameManager.getInstance().drawerUnlocked )
        {
            key.SetActive(false);
        }
    }

    public void getKey()
    {
        mainInventory.drawerKey = true;
        GameManager.getInstance().SoundPlayer.playGetSound();
        GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();
    }
}
