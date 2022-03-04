using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetBuilder : FieldPet
{
    private GameObject spawnedPet;
    private FieldPet petScript;

    public override GameObject SpawnPet()
    {
        /*
        spawnedPet = Instantiate(gameObject);
        petScript = GetComponent<Ant>();
        return spawnedPet;*/
        return null;
    }

    void Start()
    {
        
    }

    void Awake()
    {
        gameObject.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * 1);
        Debug.Log("updating");
    }
}