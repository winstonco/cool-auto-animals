using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : PetBuilder
{
    // This pet's Prefab
    public GameObject Prefab;
    private GameObject spawnedPet;

    public override void SpawnPet()
    {
        spawnedPet = Instantiate(Prefab);
    }

    public override void UseAbility()
    {
        // Nothing happens
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnedPet.transform.position = new Vector2(spawnedPet.transform.position.x + 1, 0);
    }
}
