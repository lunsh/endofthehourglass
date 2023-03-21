using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelryBox : MonoBehaviour
{
    [SerializeField] private GameObject keyAnim;
    [SerializeField] private GameObject jewelryboxCloseupPanel;
    [SerializeField] private GameObject openJewelryBoxPanel;
    public void keyTurn()
    {
        Inventory mainInventory = GameManager.getInstance().GetComponent<Inventory>();
        if (mainInventory.tuningPeg)
        {
            keyAnim.SetActive(true);
            StartCoroutine(hideKeyTurn());

            GameManager.getInstance().SoundPlayer.playUnlockedSound();
            mainInventory.tuningPeg = false;
            GameManager.getInstance().jewelryBoxOpen = true;
            GameManager.getInstance().GetComponent<Inventory>().inventoryDisplay.UpdateUI();
        }
        else
        {

            GameManager.getInstance().SoundPlayer.playLockedSound();
        }
    }

    IEnumerator hideKeyTurn()
    {
        yield return new WaitForSeconds(1f);
        keyAnim.SetActive(false);
        jewelryboxCloseupPanel.SetActive(false);
        openJewelryBoxPanel.SetActive(true);
    }
}
