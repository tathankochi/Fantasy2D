using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool isNew = SaveAndLoad.Instance.isNew;
        if (!isNew)
        {
            Debug.Log("3");
            //string fileName = GameObject.Find("SaveAndLoad").GetComponent<SaveAndLoad>().fileName;
            //string path = Path.Combine(Application.persistentDataPath, fileName);
            SaveAndLoad.Instance.SetData();
            //if (File.Exists(path))
            //{
            //    Debug.Log(path);
            //    GameObject.Find("SaveAndLoad").GetComponent<SaveAndLoad>().SetData();
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
