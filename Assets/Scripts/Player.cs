using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player main;

    [SerializeField] private int health;
    public int gold = 0;
    public int leaves = 0;
    public int leavesUp = 2;

    [SerializeField] private TextMeshProUGUI HPGui;
    [SerializeField] private TextMeshProUGUI GoldGui;
    [SerializeField] private TextMeshProUGUI LeavesGui;
    [SerializeField] private TextMeshProUGUI WaveNumber;
    [SerializeField] private TextMeshProUGUI LimitTowers;
    [SerializeField] private GameObject Manager;
    [SerializeField] public int TowerLimit = 7;
    [SerializeField] public List<GameObject> TowerCount;
    [SerializeField] public GameObject[] Towers;


    
    void Awake()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        health = GetComponent<EnemyManager>().enemyLeft;
        HPGui.text = "Enemies: " + health.ToString();
        GoldGui.text = "Gold: " + gold.ToString();
        LeavesGui.text = "Leaves :" + leaves.ToString();
        WaveNumber.text = GetComponent<EnemyManager>().wave.ToString();
        LimitTowers.text = "Max.Towers: " + TowerLimit.ToString();

        
    }

    public void CheckTowerCount()
    {
        Towers = GameObject.FindGameObjectsWithTag("Tower");
    }

    public void GetLeaves()
    {
        leaves += leavesUp;
    }

}
