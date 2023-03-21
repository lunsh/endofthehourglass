using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SymbolCheck : MonoBehaviour
{
    [SerializeField] private string correctSymbol;
    [SerializeField] private SymbolInput[] symbolLocks;

    private int[] symbolLocksArray;

    private void Start()
    {
        symbolLocksArray = new int[symbolLocks.Length];

        foreach( SymbolInput symbolLock in symbolLocks )
        {
            symbolLock.onSymbolChange += checkSymbol;
        }
    }

    private void checkSymbol(int id, int symbol)
    {
        symbolLocksArray[id] = symbol;

        string tempCheck = string.Join("", symbolLocksArray);

        if ( tempCheck == correctSymbol )
        {
            success();
        }
    }

    public abstract void success();
}
