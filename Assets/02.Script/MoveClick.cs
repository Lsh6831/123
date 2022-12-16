using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClick : MonoBehaviour
{
    public PlayerMove playermove;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    public void OnEnable()
    {
            playermove = GetComponent<PlayerMove>();
    }
    public void PointerDown()
    {
        //if (gameManager.isGameover)
        //{
            playermove.playerMove = true;
            Debug.Log(playermove.playerMove);
        //}
    }

    public void PointerUp()
    {
        //if (gameManager.isGameover)
        //{
            playermove.playerMove = false;
        //}
        }
}
