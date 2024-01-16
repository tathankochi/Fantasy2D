using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList;
    [SerializeField]
    private List<int> enemyQuantity;
    [SerializeField]
    private List<Vector2> enemyPosition;
    [SerializeField]
    private List<float> startTime;
    [SerializeField]
    private List<float> delayTime;

    [SerializeField]
    private GameObject chest;

    private Vector2 direction;
    private bool checkFinish=false;
    [SerializeField]
    private AudioClip xongMap;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            StartCoroutine(DelayCoroutine(i));
        }
        StartCoroutine(CheckFinishCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (checkFinish)
        {
            if (transform.childCount == 0)
            {
                chest.GetComponent<Chest>().SetAllowOpen(true);
                GameObject.Find("Player").GetComponent<LevelPlayer>().UpLevel();
                checkFinish = false;
                GameObject.Find("soundRemain").GetComponent<AudioSource>().clip = xongMap;
                GameObject.Find("soundRemain").GetComponent<AudioSource>().Play();
            }
        }
    }
    IEnumerator DelayCoroutine(int i)
    {
        yield return new WaitForSeconds(startTime[i]);
        for (int j = 0; j < enemyQuantity[i]; j++)
        {
            GameObject enemy=Instantiate(enemyList[i], enemyPosition[i], Quaternion.identity);
            direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            enemy.GetComponent<Rigidbody2D>().AddForce(direction * 5);
            enemy.transform.SetParent(this.transform);
            yield return new WaitForSeconds(delayTime[i]);
        }
    }
    IEnumerator CheckFinishCoroutine()
    {
        int end = startTime.Count - 1;
        yield return new WaitForSeconds(startTime[end] + enemyQuantity[end] * delayTime[end]);
        checkFinish = true;
    }
}
