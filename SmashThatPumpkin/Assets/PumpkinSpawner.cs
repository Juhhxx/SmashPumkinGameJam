using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject objectToSpawn2;
    [SerializeField] private GameObject objectToSpawn3;
    private int _pumpkinType;
    private GameObject currentPumpkin;
    public GameObject CurrentPumpkin => currentPumpkin;
    
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
            _pumpkinType = Random.Range(0,99);

            if (_pumpkinType <= 49)
            {
                currentPumpkin = Instantiate(objectToSpawn);
                Debug.Log("Nova abobora yay");
            }
            else if (_pumpkinType >= 50 && _pumpkinType <= 89)
            {
                currentPumpkin = Instantiate(objectToSpawn2);
                Debug.Log("Nova abobora má yay");
            }
            else 
            {
                currentPumpkin = Instantiate(objectToSpawn3);
                Debug.Log("Nova abobora dourada yay");
            }
            
        }

    }
}