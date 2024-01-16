using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Luu vi tri gObj cha hien tai
        parentAfterDrag=transform.parent;
        //2 dong nay dat no lam con cuoi cung cua root de no hien thi len tren nhung thu khac
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        //Khong nhan su kien chuot khi doi tuong dang dc drag
        image.raycastTarget = false;
        //An text so item khi bat dau keo
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position=Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Chuyen item ve lai gObj cha 
        transform.SetParent(parentAfterDrag);
        //Cho phep nhan su kien chuot
        image.raycastTarget = true;
        //Hien text so item
        transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("end drag");
    }
}
