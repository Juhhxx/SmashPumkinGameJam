using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    private bool hasPumpkin = false;
    [SerializeField] private GameObject objectToSpawn;
    private GameObject currentPumpkin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (GameObject.Find("Pumpkin") = null)
        // {
        //     hasPumpkin = true;
        // }
        // else
        // {
        //     hasPumpkin = false;
        // }

        // Debug.Log(hasPumpkin);
        // if (hasPumpkin == false)
        // {
        //     Instantiate(objectToSpawn);
        // }

        if (currentPumpkin == null)
        {
            currentPumpkin = Instantiate(objectToSpawn);
            Debug.Log("Nova abobora yay");
        }

    }
}