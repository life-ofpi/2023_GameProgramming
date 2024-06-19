using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    public float destroyTime;

    AudioSource aud;
    GameObject director;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");// script ȣ�� 
        this.aud = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other) //��� or ��ź �ݶ��̴� ����. 
    {

        if (other.gameObject.tag == "Apple")
        {
            this.director.GetComponent<GameDirector>().GetApple(); //�Լ� ȣ��
            this.aud.PlayOneShot(this.appleSE); //�ѹ��� �Ҹ� ���� �Լ�
            ParticleSystem particleSystem =other. GetComponent<ParticleSystem>();

            if (particleSystem != null)
            {
                particleSystem.Play();
            }
            Destroy(other.gameObject, destroyTime);

        }
        else if (other.gameObject.tag == "Bomb")
        {
            this.director.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
            ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();

            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            Destroy(other.gameObject, destroyTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //��´� 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //ray ����ְ�, �ε��� point�� hit. mathf �Լ��� �ݿø� 
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z); //�ٱ��� ��ġ ��ǥ
            }
        }
    }
}
