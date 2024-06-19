using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hpGaugeController : MonoBehaviour
{
    public Image hpGuage;  // HP 게이지의 이미지 컴포넌트 (Inspector에서 연결)
    public float decreaseAmount = 0.2f;  // HP 게이지 감소량

    // Start is called before the first frame update
    void Start()
    {
        hpGuage.fillAmount = 1.0f;

    }

    public bool DecreaseHP()
    {
        hpGuage.fillAmount -= decreaseAmount;
        if (hpGuage.fillAmount <= 0)
        {
            return true;
        }
        return false;
    }
}
