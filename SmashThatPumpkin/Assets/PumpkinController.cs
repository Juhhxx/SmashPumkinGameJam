using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinController : MonoBehaviour
{
    [SerializeField] private Animator animationP;

    void Start()
    {
        animationP = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "floor")
        {
            animationP.Play("PumInPlace");
            Debug.Log("AAAAA");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hammer")
        {
            Debug.Log("BBBBBB");
            animationP.Play("PumkSmash");
        }
        if (collision.gameObject.tag == "lixo")
        {
            Destroy(gameObject);
        }
    }
    public void EndOfAnimation()
    {
        Destroy(gameObject);
    }
   
}
