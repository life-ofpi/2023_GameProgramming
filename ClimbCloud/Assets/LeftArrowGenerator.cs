using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrowGenerator : MonoBehaviour
{
    public GameObject LeftArrowPrefab;
    public float speed = 1.0f;
    float span = 1.5f;
    float delta = 0;
    List<GameObject> arrows = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(LeftArrowPrefab) as GameObject;
            int py = Random.Range(-4, 14);
            go.transform.position = new Vector3(10, py, 0);
            arrows.Add(go);
        }

        for (int i = arrows.Count - 1; i >= 0; i--)
        {
            var arrow = arrows[i];

            if (arrow == null)
                continue;

            arrow.transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (arrow.transform.position.x < -10)
            {
                Destroy(arrow);
                arrows.RemoveAt(i);
            }
        }
    }

}
