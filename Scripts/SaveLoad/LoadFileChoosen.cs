using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFileChoosen : MonoBehaviour
{
    public string fileName;
    public GameObject saveAndLoad;
    // Start is called before the first frame update
    void Start()
    {
        saveAndLoad=GameObject.Find("SaveAndLoad");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadThis()
    {
        SaveAndLoad.Instance.PlayGame(fileName);
        SaveAndLoad.Instance.fileName = fileName;
    }
}
