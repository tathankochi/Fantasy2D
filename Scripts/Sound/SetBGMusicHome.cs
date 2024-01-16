using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBGMusicHome : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundHome;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("soundBG").GetComponent<AudioSource>().clip = soundHome;
        GameObject.Find("soundBG").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
