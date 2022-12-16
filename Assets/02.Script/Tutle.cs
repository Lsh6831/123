using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutle : MonoBehaviour
{
    private Animator tutleanimator;

    private void Start()
    {
        tutleanimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tutleanimator.SetTrigger("Hurt");
        }
    }
}
