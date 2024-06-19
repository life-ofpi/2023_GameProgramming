using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 1.0f;  // 화살의 속도

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);  // 화살이 왼쪽으로 움직임

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // 화살이 플레이어와 충돌하면
        {
            Destroy(gameObject);  // 화살 파괴
        }

    }
}
