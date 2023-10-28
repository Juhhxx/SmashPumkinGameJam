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
        float x = transform.position.x;
         x += Input.GetAxis("Horizontal");
        transform.position = new Vector3(x, 0, 0);   
        //transform.position.x = x;



        Input.GetAxis("Vertical");
    }
}
