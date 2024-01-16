using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    //cung chi so index la tuong ung
    [SerializeField]
    private List<Recipe> items = new List<Recipe>();
    [SerializeField]
    private GameObject prefabsListItem;
    [SerializeField]
    private GameObject prefabsMaterial;

    private int curIndex;
    private InventoryManager inventoryManager;

    [SerializeField]
    private GameObject notice;

    [SerializeField] private Canvas canvasCraft;

    [SerializeField]
    private AudioClip craftSuccess;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        GameObject parentGObj = GameObject.Find("CraftContent");
        for (int i = 0; i < items.Count; i++) { 
            GameObject gObjListItem= Instantiate(prefabsListItem);
            //gObjListItem.transform.parent = parentGObj.transform;
            gObjListItem.transform.SetParent(parentGObj.transform, false);
            gObjListItem.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = items[i].item.itemIcon;
            gObjListItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].item.itemName;
            //--------------------------------------------------------------
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            canvasCraft.enabled = !canvasCraft.enabled;
        }
    }
    public void RefreshMaterial(int i)
    {
        GameObject parentGObj2 = GameObject.Find("MaterialContent");
        foreach (Transform child in parentGObj2.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int j = 0; j < items[i].materials.Count; j++)
        {
            GameObject gObjMaterial = Instantiate(prefabsMaterial);
            //gObjMaterial.transform.parent = parentGObj2.transform;
            gObjMaterial.transform.SetParent(parentGObj2.transform, false);
            gObjMaterial.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = items[i].materials[j].itemIcon;
            int curQuantity = inventoryManager.GetQuantity(items[i].materials[j]);
            gObjMaterial.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = curQuantity+"/"+items[i].quantity[j];
        }
        curIndex = i;
    }
    public void Craft()
    {
        for (int i = 0; i < items[curIndex].materials.Count; i++)
        {
            if (items[curIndex].quantity[i] > inventoryManager.GetQuantity(items[curIndex].materials[i]))
            {
                notice.GetComponent<TextMeshProUGUI>().text = items[curIndex].materials[i].itemName + " don't enough!";
                return;
            }
        }
        for (int i = 0; i < items[curIndex].materials.Count; i++)
        {
            if (items[curIndex].quantity[i] <= inventoryManager.GetQuantity(items[curIndex].materials[i]))
            {
                inventoryManager.RemoveItem(items[curIndex].materials[i], items[curIndex].quantity[i]);
            }
        }
        inventoryManager.AddItem(items[curIndex].item,1);
        notice.GetComponent<TextMeshProUGUI>().text = "Craft " + items[curIndex].item.itemName + " successfully!";

        GameObject.Find("soundRemain").GetComponent<AudioSource>().clip = craftSuccess;
        GameObject.Find("soundRemain").GetComponent<AudioSource>().Play();
    }
}
