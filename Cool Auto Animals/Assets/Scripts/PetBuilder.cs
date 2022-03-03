using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetBuilder : FieldPet, IFriendlyPet
{
    private Field field;
    //public GameObject PetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        field = GameObject.Find("Friendly Field").GetComponent<Field>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnPet();
        }
    }

    public abstract void SpawnPet();

    public void AddFriendlyPet()
    {
        field.AddPet(this);
    }

    public void AddFriendlyPet(int index)
    {
        field.AddPet(this, index);
    }
}