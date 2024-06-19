using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f; //1�ʰ������� ������ 
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;
    // Update is called once per frame
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0; //�ٽ� 0���� ���� 
            int seed = Mathf.FloorToInt(Time.time * 1000);
            Random.InitState(seed);

            GameObject item;
            int dice = Random.Range(1, 11);
            if(dice<=this.ratio) //�ֻ����� 2 ���ϸ� 
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }
            Random.InitState(seed + 1);
            float x = Random.Range(-1, 2); // -1,0,1�߿��� ������ 
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed; 
        }
    }
}
