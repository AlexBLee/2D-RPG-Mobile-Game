﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class ShopDisplay : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public Player player;
    public List<Item> itemList;
    public List<ItemDisplay> itemDisplays;
    public Button shopButton;
    public Button exitButton;
    public GameObject shop;
    public GameObject inventory;

    void Start()
    {
        shopButton.onClick.AddListener(ShowShop);
        exitButton.onClick.AddListener(ExitShop);

        if(moneyText != null)
        {
            UpdateGold();
        }


        for(int i = 0; i < itemList.Count; i++)
        {
            itemDisplays[i].nameOfItem.text = itemList[i].itemName;
            itemDisplays[i].cost.text = itemList[i].cost.ToString();
            itemDisplays[i].image.sprite = itemList[i].image;
        }

        for(int i = 0; i < itemDisplays.Count; i++)
        {
            int x = i;
            itemDisplays[x].button.onClick.AddListener(delegate {player.AddItem(itemList[x]);});
        }
        
    }

    public void ShowShop()
    {
        inventory.SetActive(false);
        shop.SetActive(true);
    }

    public void UpdateGold()
    {
        moneyText.text = player.gold.ToString();
    }

    public void ExitShop()
    {
        player.ApplyItemsTo(GameManager.instance.playerStats);
        SceneManager.LoadScene(GameManager.instance.levelNumber);
    }
}
