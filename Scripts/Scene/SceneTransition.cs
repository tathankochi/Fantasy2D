using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Va cham");
        if (other.tag == "Player")
        {
            SceneLoad.Instance.LoadScene(sceneName,new Vector2(x,y));
        }
        else
        {
            Debug.Log("Khong chuyen");
        }
    }
}
