using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerCloseup : MonoBehaviour
{
    [SerializeField] private GameObject keyAnim;
    [SerializeField] private GameObject DrawerCloseupPanel;
    [SerializeField] private GameObject openDrawerPanel;
    public void keyTurn()
    {
        Inventory mainInventory = GameManager.getInstance().GetComponent<Inventory>();
        if ( mainInventory.drawerKey )
        {
            keyAnim.SetActive(true);
            StartCoroutine(hideKeyTurn());
            mainInventory.drawerKey = false;
            GameManager.getInstance().drawerUnlocked = true;
            GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();

            GameManager.getInstance().SoundPlayer.playUnlockedSound();
        } else
        {

            GameManager.getInstance().SoundPlayer.playLockedSound();
        }
    }

    IEnumerator hideKeyTurn()
    {
        yield return new WaitForSeconds(1f);
        keyAnim.SetActive(false);
        DrawerCloseupPanel.SetActive(false);
        openDrawerPanel.SetActive(true);
    }
}
