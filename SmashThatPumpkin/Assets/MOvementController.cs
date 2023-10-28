using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MOvementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            print("X");
        else if(Input.GetButtonDown("Fire2"))
            print("Y");
        float x = transform.position.x;
         x += Input.GetAxis("Horizontal")/2;
        transform.position = new Vector3(x, 0, 0);   
        //transform.position.x = x;



        Input.GetAxis("Vertical");
    }
}
