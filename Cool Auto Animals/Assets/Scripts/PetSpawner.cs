using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    public GameObject beaverPrefab;

    // Start is called before the first frame update
    void Start()
    {
        antPrefab = Resources.Load<GameObject>("Prefabs/PetPrefabs/Ant");
        beaverPrefab = Resources.Load<GameObject>("Prefabs/PetPrefabs/Beaver");
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateRandomPet();
        }
    }

    private GameObject CreateRandomPet()
    {
        PetTypes type = (PetTypes)(Random.Range(0,System.Enum.GetValues(typeof(PetTypes)).Length));
        switch (type)
        {
            case PetTypes.Ant:
                return Instantiate(antPrefab);
            case PetTypes.Beaver:
                return Instantiate(beaverPrefab);
            default:
                return Instantiate(antPrefab);
        }
    }
}

public enum PetTypes
{
    Ant,
    Beaver
}