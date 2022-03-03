using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FriendlyPet : FieldPet
{
    private Field myField = GameObject.Find("FriendlyField").GetComponent<Field>();

    public FriendlyPet()
    {
        myField.AddPet(this);
    }
    public FriendlyPet(int index)
    {
        myField.AddPet(this, index);
    }
}
