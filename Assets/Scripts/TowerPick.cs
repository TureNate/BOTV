



using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerPick : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] private List<GameObject> towers;
    private List<GameObject> rare = new List<GameObject>();
    private List<GameObject> rare1 = new List<GameObject>();

    [Header("UI Tower Names")]
    [SerializeField] public List<TextMeshProUGUI> Towernames;
    
    [Header("Towers Portrait")]
    [SerializeField] public List<Image> Towerportrait1;
   
    [Header("UI Tower Costs")]
    [SerializeField] public List<TextMeshProUGUI> TowerCosts;
    
    private List<GameObject> Towerlist;
    private int[] rarecost = new int[2];


    void Awake()
    {
        rarecost[0] = 50;
        rarecost[1] = 100;
        foreach (GameObject go in towers)
        {
            if (go.GetComponent<Tower>().Rare == 0)
            {
                //rarecost[0] = 50;
                rare.Add(go);
            }
            else if (go.GetComponent<Tower>().Rare == 1)
            {
                //rarecost[1] = 100;
                rare1.Add(go);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TowerPickRare12()
    {
        Player.main.CheckTowerCount();
        Debug.Log(Player.main.Towers.Length.ToString());
        if (Player.main.gold >= rarecost[0] && Player.main.Towers.Length + 1 <= Player.main.TowerLimit)
        {
            Player.main.gold -= rarecost[0];
            Player.main.GoldExpended += rarecost[0];
            Towerlist = TowerPickList(0);
            for (int i = 0; i < Towerlist.Count; i++)
            {
                Towernames[i].text = Towerlist[i].GetComponent<Tower>().TowerName;
                TowerCosts[i].text = Towerlist[i].GetComponent<Tower>().cost.ToString();
                Towerportrait1[i].sprite = Towerlist[i].GetComponent<Tower>().ImageTower;
            }
            panel.SetActive(true);
            Debug.Log(Towerlist.ToString());
        }
        else
            Debug.Log("NeedMoreMoney");
    }

    public List<GameObject> TowerPickList(int ChooseRare)
    {
        
        List<GameObject> list = new List<GameObject>();
        bool RareUpIs = false;
        GameObject MbTower = null;

        while (list.Count < 3)
        {
            Debug.Log(list.Count.ToString());
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    GameObject go = list[i];
                    if (go.GetComponent<Tower>().Rare > ChooseRare)
                    {
                        RareUpIs = true;
                    }
                }
            }
            if (!RareUpIs)
            {
                MbTower = PickTower(rare, rare1);
            }
            if (RareUpIs)
            {
                MbTower = PickTower(rare, null);
            }

            if (list.Count == 0)
            {
                list.Add(MbTower);
            }
            else if (MbTower != list[0])
            {
                list.Add(MbTower);
            }
            else if((MbTower != list[0] && MbTower != list[1]))
            {
                list.Add(MbTower);
            }
        }

        return list;
        
    }

    public GameObject PickTower(List<GameObject> rare, List<GameObject> rare1) 
    { 
        GameObject TowerResult = null;
        if(rare1 != null)
        {
            int Fart = UnityEngine.Random.Range(0, 100);
            if (Fart > 80)
            {
                TowerResult = rare1[UnityEngine.Random.Range(0, rare1.Count)];
            }
            else if(Fart <= 80)
            {
                TowerResult = rare[UnityEngine.Random.Range(0, rare.Count)];
            }
        }
        else
        {
            TowerResult = rare[UnityEngine.Random.Range(0, rare.Count)];
        }
            return TowerResult;
    }


    public void DenyTower()
    {
        int goldcost = 0;
        foreach (GameObject go in Towerlist)
        {
            if (go.GetComponent<Tower>().cost / 2 > goldcost)
                goldcost = go.GetComponent<Tower>().cost / 2;
        }
            Player.main.gold += goldcost;
        panel.SetActive(false);
    }
    
    public void SelectTower(int index)
    {
        gameObject.GetComponent<TowerManager>().setTower(Towerlist[index]);
        panel.SetActive(false);
    }

}
