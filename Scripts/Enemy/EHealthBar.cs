using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EHealthBar : MonoBehaviour
{
    public Image fillbar;
    public Image easebar;
    public TextMeshProUGUI valueText;
    private float easeHP = -9999;
    private int curHP = -9999;
    private int maxHP = -9999;
    public void UpdateBar(int currentValue, int maxValue)
    {
        if (easeHP == -9999)
        {
            easeHP = maxValue;
            maxHP = maxValue;
        }
        curHP = currentValue;
        fillbar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
        Debug.Log(valueText.text);
    }
    private void Update()
    {
        if (easeHP != curHP)
        {
            easeHP = Mathf.Lerp((float)curHP, easeHP, 0.8f);
            easebar.fillAmount = easeHP / (float)maxHP;
        }
    }
}
