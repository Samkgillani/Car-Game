using UnityEngine;
using UnityEngine.UI;

public class CompletePanel : MonoBehaviour
{
    public Text levelRewardText, livesRewardText, totalRewardText;
    int levelReward, livesReward, totalReward;
    private void OnEnable()
    {
        levelReward = (MainMenu.levelNum) * 50;
        livesReward = Collide.lifeCount * 10;
        totalReward = levelReward+ livesReward;
        PlayerPrefs.SetInt("cash", PlayerPrefs.GetInt("cash") + totalReward);
        levelRewardText.text =$"Level Reward: 50*{MainMenu.levelNum}={levelReward}";
        livesRewardText.text =$"Lives: 10*{Collide.lifeCount}={livesReward}";
        totalRewardText.text =$"Total={totalReward}";
    }
}
