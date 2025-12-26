using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    GameOverScript main;
    [SerializeField] private TextMeshProUGUI EnemyKillsGUI;
    [SerializeField] private TextMeshProUGUI GoldExpGui;
    [SerializeField] private TextMeshProUGUI LeavesExpGui;
    [SerializeField] private GameObject VinText;
    [SerializeField] private GameObject LoseText;
    [SerializeField] public bool VorF = false;
    void Awake()
    {
        main = this;
    }


    void Update()
    {
        if (VorF)
        {
            LoseText.SetActive(false);
            VinText.SetActive(true);
        }
        else
        {
            VinText.SetActive(false);
            LoseText.SetActive(true);
        }

            LeavesExpGui.text = "Потраченные листочки: " + Player.main.LeavesExpended.ToString();
        
            GoldExpGui.text = "Потраченное золото: " + Player.main.GoldExpended.ToString();
        
            EnemyKillsGUI.text = "Уничтожения: " + Player.main.EnemyKills.ToString();
    }
}
