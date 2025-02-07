﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootInstance : MonoBehaviour //behaviour of loot as a game object
{
    enum LootOptions { TestLoot, TestGun } //enum for all loot that exists, prolly need a better way to do this
    public int lootNum; //int to know what loot to spawn
    public int amount; //int to know amount of loot
    Loot thisLoot; //instance of the loot that this game object is 

    public void DefineMe() //set up game objects apperance and instanciates the loot
    {
        thisLoot = LootSpawner.GetLootFromNum(lootNum, amount); //instanciates the loot and save it
        Mesh mesh = Resources.Load<GameObject>(thisLoot.meshPath).GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<GameObject>(thisLoot.meshPath).GetComponent<MeshRenderer>().sharedMaterial;
        GetComponent<Rigidbody>().mass = thisLoot.weight;
        name = thisLoot.name + "(loot instance)";
    }

    public void AddToInventory(Inventory inv) //if you pick up the items
    {
        if (!inv.Add(thisLoot)) //tries to add it, and if it didn't work
            Debug.Log("Inventory full"); //error message for not working
        else //if it worked
        {
            Debug.Log("Added " + thisLoot.name); //it worked message
            Destroy(gameObject); //remove the game object, the loot is now in your inventory
        }
    }
}
