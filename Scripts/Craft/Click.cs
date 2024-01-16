using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefreshMaterial()
    {
        GameObject craftManager = GameObject.Find("CraftManager");
        craftManager.GetComponent<CraftManager>().RefreshMaterial(transform.GetSiblingIndex());
    }
}
