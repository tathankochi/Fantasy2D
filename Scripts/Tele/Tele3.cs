using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tele3 : MonoBehaviour
{
    [SerializeField]
    private AudioClip map1;
    [SerializeField]
    private AudioClip map2;
    [SerializeField]
    private AudioClip map3;

    private AudioSource audioSourceBG;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceBG = GameObject.Find("soundBG").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveMap1()
    {
        SceneLoad.Instance.LoadScene("map1", new Vector2(-16.5f, -2.0f));
        audioSourceBG.clip = map1;
        audioSourceBG.Play();
    }
    public void MoveMap2()
    {
        SceneLoad.Instance.LoadScene("map2", new Vector2(53.5f, 5f));
        audioSourceBG.clip = map2;
        audioSourceBG.Play();
    }
    public void MoveMap3()
    {
        SceneLoad.Instance.LoadScene("map3", new Vector2(12.5f, -25f));
        audioSourceBG.clip = map3;
        audioSourceBG.Play();
    }
}
