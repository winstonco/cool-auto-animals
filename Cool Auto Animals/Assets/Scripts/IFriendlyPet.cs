using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFriendlyPet
{

    /// <summary>
    /// Adds a pet to the field at the front.
    /// </summary>
    public void AddFriendlyPet();

    /// <summary>
    /// Adds a pet to the field at the index.
    /// </summary>
    /// <param name="index">The index</param>
    public void AddFriendlyPet(int index);
}
