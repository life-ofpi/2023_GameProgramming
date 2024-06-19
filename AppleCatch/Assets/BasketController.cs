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
        this.director = GameObject.Find("GameDirector");// script 호출 
        this.aud = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other) //사과 or 폭탄 콜라이더 전달. 
    {

        if (other.gameObject.tag == "Apple")
        {
            this.director.GetComponent<GameDirector>().GetApple(); //함수 호출
            this.aud.PlayOneShot(this.appleSE); //한번만 소리 내는 함수
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
            RaycastHit hit; //찍는다 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //ray 집어넣고, 부딪힌 point가 hit. mathf 함수로 반올림 
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z); //바구니 배치 좌표
            }
        }
    }
}
