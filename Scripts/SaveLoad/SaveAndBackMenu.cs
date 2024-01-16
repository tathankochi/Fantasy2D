using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndBackMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Da nhan B");
            try
            {
                SaveAndLoad.Instance.SaveGameData();
                SceneManager.MoveGameObjectToScene(GameObject.Find("Player"), SceneManager.GetActiveScene());
                SceneManager.MoveGameObjectToScene(GameObject.Find("CanvasHealth"), SceneManager.GetActiveScene());
                SceneManager.MoveGameObjectToScene(GameObject.Find("Canvas"), SceneManager.GetActiveScene());
                SceneManager.MoveGameObjectToScene(GameObject.Find("GameController"), SceneManager.GetActiveScene());
                SceneManager.LoadScene("Menu");
            }
            catch { 
            
            }
        }
    }
}
