
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//���� ������Ʈ�� ���������� �������� �����̴� ��ũ��Ʈ �Դϴ�.
public class Scrolling : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 5f; //�̵��ӵ�

    private void OnValidate()
    {
        if (!gameManager)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }
    //private void Start()
    //{
    //    gameManager = GetComponentInParent<GameManager>();
    //}
    //private void OnEnable()
    //{
    //    gameManager = GetComponentInParent<GameManager>();
    //}
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameover)
        {
            //�ʴ�(Time.deltatime) speed�� �ӵ��� �������� �����̵� ����
            transform.Translate(Vector3.left * gameManager.rollingSpeed * Time.deltaTime);
        }
    }
}