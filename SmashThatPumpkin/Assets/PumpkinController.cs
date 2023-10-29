using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinController : MonoBehaviour
{
    [SerializeField] private Animator animationP;
    private CircleCollider2D circleCollider2D;
    private bool hasFallen = false;
    public bool GhasFallen => hasFallen;

    void Start()
    {
        hasFallen = false;
        animationP = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    void Update()
    {
        Debug.Log(GhasFallen);
    }

    public void HasFallen()
    {
        hasFallen = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "floor")
        {
            animationP.Play("PumInPlace");
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
