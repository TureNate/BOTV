using System;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [System.Serializable]
    class Level
    {
        public float range = 8f;
        public int damage = 25;
        public float fireRate = 1f;
        public int cost = 100;

    }

    [SerializeField] private Level[] levels = new Level[3];
    [SerializeField] public int currentlevel = 0;
    [NonSerialized] public string CurrentCost;

    private Tower tower;
    [SerializeField] private TowerRange towerRange;
    void Awake()
    {
        tower = GetComponent<Tower>();
        CurrentCost = levels[0].cost.ToString();
    }

    // Update is called once per frame
    public void Upgrade()
    {
        if (currentlevel < levels.Length && levels[currentlevel].cost <= Player.main.gold)
        {
            tower.range = levels[currentlevel].range;
            tower.damage = levels[currentlevel].damage;
            tower.fireRate = levels[currentlevel].fireRate;
            tower.SellCost += levels[currentlevel].cost / 2;
            towerRange.UpdateRange();

            Player.main.gold -= levels[currentlevel].cost;

            currentlevel++;

            if (currentlevel >= levels.Length)
            {
                CurrentCost = "MAX";
            }
            else
            {
                CurrentCost = levels[currentlevel].cost.ToString();
            }


                

            Debug.Log("Uppp");
        }
    }
}
