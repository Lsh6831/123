using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundLoop : MonoBehaviour
{
    // ����� ���� ���̸� ��Ƶ� ���� ����
    [SerializeField]public GameManager gameManager;
    private float width;
    public float plus = 9f;

   
    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x+plus;

    }
    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }


    void Update()
    {
        if (!gameManager.isGameover)
        {
            // ���� ��ġ�� �������� �������� width �̻� �̵� ���� ��
            // ��ġ�� ���ġ 
            if (transform.position.x <= -width)
            {
                Repostion();
            }
        }

    }

    void Repostion() //��ġ�� �� ��ġ�ϴ� �޼���
    {
        // ���� ��ġ���� ���������� ���� ���� * 2 ��ŭ �̵�
        Vector2 offset = new Vector2(width * 4f, 0);
        transform.position = (Vector2)transform.position + offset;

    }
}