using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject LoadGame;
    public GameObject Menu;
    public GameObject Settings;


    public GameObject New;
    public GameObject inputField;
    public GameObject notice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoadGame.SetActive(false);
            Menu.SetActive(true);
            New.SetActive(false);
            Settings.SetActive(false);
        }
    }
    public void OpenLoadGame()
    {
        LoadGame.SetActive(true);
        Menu.SetActive(false);
        New.SetActive(false);
        Settings.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("a");
        Application.Quit();
    }
    public void NewGame()
    {
        LoadGame.SetActive(false);
        Menu.SetActive(false);
        New.SetActive(true);
        Settings.SetActive(false);
    }
    public void NewStart()
    {
        if (inputField.GetComponent<TMP_InputField>().text=="")
        {
            notice.GetComponent<TextMeshProUGUI>().text = "Please input name";
        }
        else
        {
            SaveAndLoad.Instance.fileName = inputField.GetComponent<TMP_InputField>().text+".dat";
            SaveAndLoad.Instance.PlayNewGame();
        }
    }
    public void SettingsGame()
    {
        LoadGame.SetActive(false);
        Menu.SetActive(false);
        New.SetActive(false);
        Settings.SetActive(true);
    }
}
