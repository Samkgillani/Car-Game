using UnityEngine;
using UnityEngine.UI;

public class CompletePanel : MonoBehaviour
{
    public Text levelRewardCalculationText, hitRewardCalculationText, levelRewardText, hitRewardText, totalRewardText;
    int levelReward, livesReward, totalReward;
    private void OnEnable()
    {
        levelReward = (MainMenu.levelNum) * 50;
        livesReward = Collide.lifeCount * 10;
        totalReward = levelReward+ livesReward;
        PlayerPrefs.SetInt("cash", PlayerPrefs.GetInt("cash") + totalReward);
        //levelRewardCalculationText.text =$"Level Reward: 50*{MainMenu.levelNum}";
        levelRewardText.text =$"{levelReward}";
        hitRewardText.text =$"{livesReward}";
        //hitRewardCalculationText.text =$"Lives: 10*{Collide.lifeCount}";
        totalRewardText.text =$"{totalReward}";
    }
}
