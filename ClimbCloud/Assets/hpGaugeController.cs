using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hpGaugeController : MonoBehaviour
{
    public Image hpGuage;  // HP �������� �̹��� ������Ʈ (Inspector���� ����)
    public float decreaseAmount = 0.2f;  // HP ������ ���ҷ�

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
