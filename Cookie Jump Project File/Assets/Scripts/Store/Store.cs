//Made by Joel Draper for MansionGaming
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    public Text text; //Allows us to display the amount of coins collected
    //public Sprite []playerSkinNew;

    public coinManager coinManager;
    public RespawnBasics respawnManager;
    public achievementManager achievement;
    public PlayerFunctions player;

    private int itemCost;

    public GameObject purchase;
    public GameObject failPurchase;

    public void buyRespawn()
    {
        if (coinManager.gold >= 5)
        {
            itemCost = 5;
            coinManager.gold -= itemCost;
            respawnManager.respawnsLeft += 1;
            achievement.spenderB += 1;
            Debug.Log("respawn purchased. You have " + respawnManager.respawnsLeft);
            purchase.GetComponent<AudioSource>().Play();
        }
        else
        {
            failPurchase.GetComponent<AudioSource>().Play();
            return;
        }
    }
    public void buyGold()
    {
        itemCost = 1000;
        coinManager.gold += itemCost;
        purchase.GetComponent<AudioSource>().Play();
    }
    public void back()
    {
        Application.LoadLevel(1);
    }
    public void loseRespawn()
    {
        respawnManager.respawnsLeft -= 1;
    }
    public void buySkin1()
    {
        if (coinManager.gold >= 25)
        {
            itemCost = 25;
            coinManager.gold -= itemCost;
            achievement.spenderB += 1;
            player.skinOne = false;
            player.skinTwo = true;
            player.skin2Av = 1;
            purchase.GetComponent<AudioSource>().Play();
        }
        else
        {
            failPurchase.GetComponent<AudioSource>().Play();
            return;
        }
    }
}
