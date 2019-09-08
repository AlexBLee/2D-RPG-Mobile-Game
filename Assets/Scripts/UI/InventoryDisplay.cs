﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    public List<Item> items;
    public List<Image> images;
    public Sprite blankImage;
    public Player player;
    public int count = 0;
    public GameObject inventoryDisplay;
    private int tempIndex;
    private bool notFront;
    public ItemDisplay itemDisplay;
    public TextMeshProUGUI goldText;


    private void Start() 
    {
        inventoryDisplay.SetActive(false);
        player = GameManager.instance.playerObject;
        items = player.itemList;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.I) && !inventoryDisplay.activeSelf)
        {
            inventoryDisplay.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventoryDisplay.activeSelf)
        {
            inventoryDisplay.SetActive(false);
        }
    }

    public void AddItemImage(Item item, int index)
    {
        images[index].sprite = items[index].image;

        if(notFront)
        {
            count = tempIndex;
        }
        else
        {
            count++;
        }
        notFront = false;
    }

    public void RemoveItemImage(int index)
    {
        images[index].sprite = blankImage;
        tempIndex = count;
        
        count = index;
        notFront = true;
    }

    public void SwapItem(int indexA, int indexB)
    {
        Sprite imgTemp = images[indexA].sprite;
        images[indexA].sprite = images[indexB].sprite;
        images[indexB].sprite = imgTemp;
    }

    public void DisplayItemInfo(int index, Vector3 position)
    {
        itemDisplay.gameObject.SetActive(true);
        itemDisplay.nameOfItem.text = items[index].itemName;
        itemDisplay.description.text = items[index].description;
        itemDisplay.gameObject.transform.parent.position = position;
    }
    


}