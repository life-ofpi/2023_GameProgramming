using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 1.0f;  // ȭ���� �ӵ�

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);  // ȭ���� �������� ������

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // ȭ���� �÷��̾�� �浹�ϸ�
        {
            Destroy(gameObject);  // ȭ�� �ı�
        }

    }
}
