
using TMPro;
using UnityEngine;

using UnityEngine.EventSystems;

using System.Collections.Generic;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private LayerMask towerLayer;

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI towerName;
    [SerializeField] private TextMeshProUGUI towerLevel;
    [SerializeField] private TextMeshProUGUI UpgradeCost;
    [SerializeField] private TextMeshProUGUI SellCost;
    [SerializeField] private TextMeshProUGUI towerTargetting;
    [SerializeField] private List<GameObject> towers;


    private GameObject selectedTower;

    private GameObject placingTower;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    setTower(Tower1);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    setTower(Tower2);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{ 
        //    setTower(Tower3); 
        //}
        //else
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearSelected();
        }
        if (placingTower)
        {
            if (!placingTower.GetComponent<TowerPlacing>().isPlacing)
            {
                placingTower = null;
            }
        }

        if (Input.GetMouseButtonDown(0) && Player.main.isPlaying)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100f, towerLayer);

            if (hit.collider != null)
            {

                if (selectedTower)
                {
                    GameObject range1 = selectedTower.transform.GetChild(1).gameObject;
                    range1.GetComponent<SpriteRenderer>().enabled = false;
                }

                selectedTower = hit.collider.gameObject;

                GameObject range2 = selectedTower.transform.GetChild(1).gameObject;

                range2.GetComponent<SpriteRenderer>().enabled = true;

                panel.SetActive(true);
                towerName.text = selectedTower.GetComponent<Tower>().TowerName;
                towerLevel.text = "Башня ЛВЛ: " + selectedTower.GetComponent<TowerUpgrade>().currentlevel.ToString();
                UpgradeCost.text = selectedTower.GetComponent<TowerUpgrade>().CurrentCost;
                SellCost.text = selectedTower.GetComponent<Tower>().SellCost.ToString();


                Tower tower = selectedTower.GetComponent<Tower>();

                if (tower.first)
                {
                    towerTargetting.text = "Первый";
                }
                else if (tower.last)
                {
                    towerTargetting.text = "Последний";

                }
                else if (tower.strong)
                {
                    towerTargetting.text = "Сильнейший";
                }
            }

            else if (!EventSystem.current.IsPointerOverGameObject() && selectedTower)
            {
                panel.SetActive(false);

                GameObject range1 = selectedTower.transform.GetChild(1).gameObject;

                range1.GetComponent<SpriteRenderer>().enabled = false;

                selectedTower = null;

            }
        }

        //if (Input.GetKeyDown(KeyCode.U) && selectedTower)
        //{
        //    selectedTower.GetComponent<TowerUpgrade>().Upgrade();
        //}
    }

    public void DestroyTower()
    {
        if (selectedTower)
        {
            Player.main.gold += selectedTower.GetComponent<Tower>().SellCost;
            Player.main.TowerCount.Remove(selectedTower);
            Destroy(selectedTower);
        }
    }

    private void ClearSelected()
    {
        if (placingTower)
        {
            Destroy(placingTower);
            placingTower = null;
        }
    }

    public void setTower(GameObject tower)
    {
        ClearSelected();
        placingTower = Instantiate(tower);
        Player.main.TowerCount.Add(tower);
    }

    public void UpgradeSelected()
    {
        if(selectedTower)
        {
            selectedTower.GetComponent<TowerUpgrade>().Upgrade();
            towerLevel.text = "Башня ЛВЛ: " + selectedTower.GetComponent<TowerUpgrade>().currentlevel.ToString();
            UpgradeCost.text = selectedTower.GetComponent<TowerUpgrade>().CurrentCost;
            SellCost.text = selectedTower.GetComponent<Tower>().SellCost.ToString();
        }
    }
    public void ChangeTargetting()
    {
        Tower tower = selectedTower.GetComponent<Tower>();

        if (tower.first)
        {
            tower.first = false;
            tower.last = true;
            tower.strong = false;
            towerTargetting.text = "Последний";
        }
        else if (tower.last)
        {
            tower.first = false;
            tower.last = false;
            tower.strong = true;
            towerTargetting.text = "Сильнейший";
        }
        else if(tower.strong)
        {
            tower.first = true;
            tower.last = false;
            tower.strong = false;
            towerTargetting.text = "Первый";
        }
    }
}

