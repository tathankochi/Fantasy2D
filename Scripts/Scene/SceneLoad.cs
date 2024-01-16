using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad Instance { get; private set; }
    private GameObject player;
    private Vector2 vt2;

    [SerializeField]
    private Animator transitionAnimator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadScene(string sceneName, Vector2 vt2)
    {
        StartCoroutine(IELoadScene(sceneName, vt2));
    }
    IEnumerator IELoadScene(string sceneName, Vector2 vt2)
    {
        // Load the new scene
        this.vt2 = vt2;
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
        transitionAnimator.SetTrigger("Start");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player");
        if (player!=null)
        {
            player.transform.position = new Vector3(vt2.x, vt2.y, 0);
        }
        else
        {
            Debug.Log("Player khi chuyen canh bi null");
        }
    }
}
