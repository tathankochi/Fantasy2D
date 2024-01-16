using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayer : MonoBehaviour
{
    public int level=1;
    private int hpEachLevel = 15;
    private int damageEachLevel = 2;
    private int hpInitial = 100;
    private int damageInitial = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpLevel()
    {
        level += 1;
        SetInfomation();
        GameObject.Find("Player").GetComponent<PlayerHealth>().HealthFull();
    }
    public void SetInfomation()
    {
        GameObject.Find("SwordAnimation").GetComponent<Attack>().damageRoot=(level-1)*damageEachLevel+damageInitial;
        int maxHealth= (level - 1) * hpEachLevel + hpInitial;
        GameObject.Find("Player").GetComponent<PlayerHealth>().maxHealth = maxHealth;
        GameObject.Find("Health Bar").GetComponent<HealthBar>().UpdateBar(maxHealth,maxHealth);
    }
    public string GetInformation()
    {
        string hp = (level - 1) * hpEachLevel + hpInitial+"";
        string atk = (level - 1) * damageEachLevel + damageInitial + GameObject.Find("SwordAnimation").GetComponent<Attack>().damageSword+"";
        return "Level: " + level + "\nHp: " + hp.TrimStart('0') + "\nAtk: " + atk.TrimStart('0');
    }
}
