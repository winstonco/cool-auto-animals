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
        if (Input.GetButtonDown("Fire2"))
        {
            CreateRandomPet();
        }
    }

    private GameObject CreateRandomPet()
    {
        PetTypes type = (PetTypes)(Random.Range(0,System.Enum.GetValues(typeof(PetTypes)).Length));
        GameObject myPet;
        switch (type)
        {
            case PetTypes.Ant:
                myPet = Instantiate(antPrefab) as GameObject;
                break;
            case PetTypes.Beaver:
                myPet = Instantiate(beaverPrefab) as GameObject;
                break;
            default:
                myPet = Instantiate(antPrefab) as GameObject;
                break;
        }
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        myPet.transform.SetParent(gameObject.transform);
        myPet.transform.position = gameObject.transform.parent.transform.position;

        return myPet;
    }
}

public enum PetTypes
{
    Ant,
    Beaver
}