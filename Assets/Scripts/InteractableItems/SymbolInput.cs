using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SymbolInput : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private GameObject upButton;
    [SerializeField] private GameObject downButton;
    [SerializeField] private Image symbolToShow;

    [SerializeField] private Sprite[] symbols;
    private int activeSymbol;

    public UnityAction<int, int> onSymbolChange;

    private void Start()
    {
        activeSymbol = 0;
        symbolToShow.sprite = symbols[activeSymbol];
    }

    public void cycleUp()
    {
        if ( activeSymbol + 1 >= symbols.Length )
        {
            activeSymbol = 0;
        } else
        {
            activeSymbol++;
        }
        symbolToShow.sprite = symbols[activeSymbol];

        onSymbolChange?.Invoke(id, activeSymbol);
    }

    public void cycleDown() {
        if (activeSymbol - 1 < 0)
        {
            activeSymbol = symbols.Length - 1;
        } else
        {
            activeSymbol--;
        }
        symbolToShow.sprite = symbols[activeSymbol];

        onSymbolChange?.Invoke(id, activeSymbol);
    }
}
