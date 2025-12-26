
using TMPro;
using UnityEngine;

using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player main;

    [SerializeField] private int health;
    public int gold = 0;
    public int leaves = 0;
    public int leavesUp = 2;

    public int EnemyKills = 0;
    public int GoldExpended = 0;
    public int LeavesExpended = 0;

    private int maxEnemies = 50;

    [SerializeField] private TextMeshProUGUI HPGui;
    [SerializeField] private TextMeshProUGUI GoldGui;
    [SerializeField] private TextMeshProUGUI LeavesGui;
    [SerializeField] private TextMeshProUGUI WaveNumber;
    [SerializeField] private TextMeshProUGUI LimitTowers;
    [SerializeField] private TextMeshProUGUI LimitTowersCost;

    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject GameOverPanel;
    
    [SerializeField] private GameObject Manager;
    [SerializeField] public int TowerLimit = 7;
    [SerializeField] public List<GameObject> TowerCount;
    [SerializeField] public GameObject[] Towers;
    [SerializeField] public GameObject[] Enemies;

    private bool VarnedEnd = false;
    [SerializeField] public bool isPlaying = true;
    public bool isPaused = false;
    public bool Victory = false;
    private int CurrLevelPopulaty = 0;
    private int[] CostPopulaty;

    
    void Awake()
    {
        main = this;
    }

    private void Start()
    {
        CostPopulaty = new int[7];
        for (int i = 0; i < CostPopulaty.Length; i++)
        {
            CostPopulaty[i] = 4000 * (i + 1);            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<EnemyManager>().wave >= 50 && Enemies.Length <= 0)
        {
            isPlaying = false;
        }
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        health = GetComponent<EnemyManager>().enemyLeft;
        
            HPGui.text = "Враги: " + health.ToString() + " /" + "50";
        
            GoldGui.text = "Золото: " + gold.ToString();
        
            LeavesGui.text = "Листочки: " + leaves.ToString();
        
            WaveNumber.text = (GetComponent<EnemyManager>().wave).ToString();
        
            LimitTowers.text = "Лимит башен: " + TowerLimit.ToString();
        if (CurrLevelPopulaty < CostPopulaty.Length)
        {
            LimitTowersCost.text = "Цена: " + CostPopulaty[CurrLevelPopulaty].ToString() + " листочков";
        }
        else
            LimitTowersCost.text = "Максимальный уровень!";

        if (isPlaying)
        {
            GamePanel.SetActive(true);
        }
        else
        {
            EndGame();
            GamePanel.SetActive(false);
            if (Victory)
            {
                GetComponent<GameOverScript>().VorF = true;
            }
            else
            {
                GetComponent<GameOverScript>().VorF = false;
            }
            GameOverPanel.SetActive(true);
        }

        if (Enemies.Length > maxEnemies)
        {
            isPlaying = false;
            Victory = false;
        }
        if (GetComponent<EnemyManager>().wave >= 50)
        {
            Victory = true;
            isPlaying = false;
        }

    }

    public void CheckTowerCount()
    {
        Towers = GameObject.FindGameObjectsWithTag("Tower");
    }

    public void GetLeaves()
    {
        leaves += leavesUp;
    }

    public void EndGame()
    {
        foreach (GameObject enemy in Enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject tower in Towers)
        {
            Destroy(tower);
        }
    }

    public void UpdateMaxTowers()
    {
        if (leaves >= CostPopulaty[CurrLevelPopulaty] && CurrLevelPopulaty < 7)
        {
            LeavesExpended += CostPopulaty[CurrLevelPopulaty];
            leaves -= CostPopulaty[CurrLevelPopulaty];
            TowerLimit++;
            CurrLevelPopulaty++;
        }
    }
}
