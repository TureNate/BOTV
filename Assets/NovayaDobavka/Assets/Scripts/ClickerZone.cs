using UnityEngine;
using TMPro;
                          

public class ClickerZone : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;
    public int clickValue;

    [Header("Upgrade Click")]
    public int upgradeCost;
    public int upgradeValue;
    public TMP_Text upgradeInfoText;

    private void Start()
    {
        scoreText.text = score.ToString();
        upgradeInfoText.text = upgradeCost.ToString() + " + " + upgradeValue + " leaves";
    }

    public void Clicked()
    {
        score += clickValue;
        scoreText.text = score.ToString() + " L";
    }
    public void UpgradeClick()
    {
        if (score >= upgradeCost)
        {
            score -= upgradeCost;
            clickValue += upgradeValue;
            upgradeCost *= 2;
            scoreText.text = score.ToString() + " ";
            upgradeInfoText.text = upgradeCost.ToString() + " + " +  upgradeValue + " leaves";
        }
    }
}
