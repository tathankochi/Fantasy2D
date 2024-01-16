using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string folderPath = Application.persistentDataPath;
        string[] filePaths = Directory.GetFiles(folderPath);
        for (int i=0;i < filePaths.Length;++i)
        {
            string fileName = Path.GetFileName(filePaths[i]);
            this.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text=fileName;
            this.transform.GetChild(i).GetComponent<LoadFileChoosen>().fileName=fileName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
