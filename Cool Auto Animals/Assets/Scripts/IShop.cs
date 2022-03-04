using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShop
{
    /// <summary>
    /// Purchase the pet from the shop at index i.
    /// </summary>
    /// <returns>The pet bought</returns>
    Pet BuyPet(int i);

    /// <summary>
    /// Purchase the item from the shop at index i.
    /// </summary>
    /// <returns>The item bought</returns>
    Item BuyItem();

    /// <summary>
    /// Refresh the shop with new random pets and items. Costs 2 gold.
    /// </summary>
    void Refresh();

    /// <summary>
    /// Freezes a pet so it does not refresh.
    /// </summary>
    void FreezePet(int i);

    /// <summary>
    /// Freezes an item so it does not refresh.
    /// </summary>
    void FreezeItem(int i);
}
