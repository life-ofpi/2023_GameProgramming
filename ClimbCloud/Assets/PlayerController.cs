using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    public hpGaugeController hpControl; // HP ������ ��Ʈ�� ��ũ��Ʈ ������ �߰�

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {   //�����Ѵ�.
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //�����̴� ���⿡ ���� �����Ѵ�.
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        this.animator.speed = speedx / 2.0f;

        //�÷��̾ ȭ�� ������ �����ٸ� ó������
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("ClearScene");
        }
        if (Mathf.Abs(transform.position.x) > 10) // �� ���� �����Ͽ� ȭ�� �� ������ ������ �� �ֽ��ϴ�.
        {
            SceneManager.LoadScene("ClearScene");
        }

    }
    //�� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            if (hpControl != null)
            {
                bool isDead = hpControl.DecreaseHP(); // ȭ�쿡 �¾��� �� HP ������ ����
                if (isDead)
                {SceneManager.LoadScene("ClearScene");}
            }
            else
            {Debug.LogError("hpControl is not assigned in the inspector!");}
            return;
        }

        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
}
