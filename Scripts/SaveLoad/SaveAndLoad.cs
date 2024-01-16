using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad Instance { get; private set; }

    private GameObject player;
    private InventoryManager inventoryManager;
    private GameData data;

    public string fileName;
    public bool isNew = false;

    private Canvas saved;
    // Start is called before the first frame update
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
    void Start()
    {
        saved=GameObject.Find("Saved").GetComponent<Canvas>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveGameData();
            saved.enabled = true;
            StartCoroutine(SavedCoroutine());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            try
            {
                SaveGameData();
                SceneManager.MoveGameObjectToScene(GameObject.Find("Player"), SceneManager.GetActiveScene());
                SceneManager.MoveGameObjectToScene(GameObject.Find("CanvasHealth"), SceneManager.GetActiveScene());
                SceneManager.MoveGameObjectToScene(GameObject.Find("Canvas"), SceneManager.GetActiveScene());
                SceneManager.MoveGameObjectToScene(GameObject.Find("GameController"), SceneManager.GetActiveScene());
                SceneManager.LoadScene("Menu");
            }
            catch
            {

            }
        }
    }
    public void SaveGameData()
    {
        inventoryManager=GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        player = GameObject.Find("Player");
        //Create binary formatter
        BinaryFormatter bf = new BinaryFormatter();
        //Create file stream
        //Data path
        string path = Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log(path+"aaaaaa"+fileName);
        FileStream file = File.Create(path);
        //Create player data object
        List<string> items = new List<string>();
        List<int> itemsQuantity= new List<int>();
        List<string> equipments = new List<string>();
        int level = GameObject.Find("Player").GetComponent<LevelPlayer>().level;
        try
        {
            for (int i = 0; i < inventoryManager.items.Count; i++)
            {
                items.Add(inventoryManager.items[i].GetItem().itemName);
                itemsQuantity.Add(inventoryManager.items[i].GetQuantity());
            }
        }
        catch {
            Debug.Log("Khong co item");
        }
        try
        {
            equipments.Add(inventoryManager.weapon.GetItem().itemName);
        }
        catch
        {
            Debug.Log("Khong co vu khi (SaveAndLoad)");
        }
        data = new GameData(items, itemsQuantity,equipments, player.transform.position.x, player.transform.position.y,level);
        //Set data to file stream
        bf.Serialize(file, data);
        //Close file stream
        file.Close();
    }
    //Lay Data tu file
    public void LoadGameData(string fileName)
    {
        //Create binary formatter
        BinaryFormatter bf = new BinaryFormatter();
        //Create file stream
        string path = Path.Combine(Application.persistentDataPath, fileName);
        FileStream file = File.Open(path, FileMode.Open);
        //Create player data object
        data = (GameData)bf.Deserialize(file);
        //Close file stream
        file.Close();
        //Set
        //SetData();
    }
    public void SetData()
    {
        player = GameObject.Find("Player");
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        player.transform.position = new Vector3(data.positionX, data.positionY, 0);
        inventoryManager.SetInventoryData(data.items, data.itemsQuantity, data.equipments);
        GameObject.Find("Player").GetComponent<LevelPlayer>().level=data.level;
        //Cap nhat chi so tren code
        GameObject.Find("Player").GetComponent<LevelPlayer>().SetInfomation();
        Debug.Log("Da set");
    }
    public void PlayGame(string fileName)
    {
        Debug.Log("1");
        LoadGameData(fileName);
        SceneManager.LoadSceneAsync("HomeLand");
    }
    public void PlayNewGame()
    {
        Debug.Log("2");
        isNew = true;
        BinaryFormatter bf = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log(path);
        FileStream file = File.Create(path);
        file.Close();
        SceneManager.LoadSceneAsync("HomeLand");
    }
    IEnumerator SavedCoroutine()
    {
        yield return new WaitForSeconds(2);
        saved.enabled = false;
    }
}
