using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Data packages de eventos
public struct TogglePlayerInputDP
{
    public bool toggle;
}
public struct ToggleInventoryDP
{
    public bool toggle;
}

public struct UpdatePlayerCoinsDP
{
    public int coins;
}

public class Constantes
{
    public const string TogglePlayerInput = "ToggleInput";
    public const string ToggleInventory = "ToggleInventory";
    public const string UpdatePlayerCoins = "UpdatePlayerCoins";
}