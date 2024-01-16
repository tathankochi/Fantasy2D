using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image fillbar;
    public Image easebar;
    public TextMeshProUGUI valueText;
    public float easeHP = 0;
    private int curHP=-9999;
    private int maxHP = -9999;
    public void UpdateBar(int currentValue, int maxValue)
    {
        maxHP = maxValue;
        //if (easeHP==-9999)
        //{
        //    easeHP = maxValue;
        //    maxHP = maxValue;
        //}
        curHP = currentValue;
        fillbar.fillAmount=(float)currentValue/(float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
        Debug.Log(valueText.text);
    }
    private void Update()
    {
        if (easeHP!=curHP)
        {
            easeHP = Mathf.Lerp((float)curHP,easeHP,0.98f);
            easebar.fillAmount = easeHP / (float)maxHP;
        }
    }
}
