using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelUpUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLevel;
    [SerializeField] UpgradeCard upgradeCard;
    [SerializeField] RectTransform upgradeCardHolder;

    int upgradeMaxItems = 3;

    public void Show(int playerLevel, List<UpgradeBase> upgradeList)
    {
        Time.timeScale = 0;

        var upgrades = new List<UpgradeBase>(upgradeList);
        gameObject.SetActive(true);
        textLevel.text = $"Level {playerLevel}";

        foreach (Transform child in upgradeCardHolder)
            Destroy(child.gameObject);

        upgrades.RemoveAll(upgrade => upgrade.level >= upgrade.levelMax);

        var availableUpgrades = upgrades.Count > upgradeMaxItems ? upgradeMaxItems : upgrades.Count;

        for (int i = 0; i < availableUpgrades; i++)
        {
            var upgrade = upgrades[Random.Range(0, upgrades.Count)];

            Instantiate(upgradeCard, upgradeCardHolder).Init(upgrade, () => Hide(upgrade));

            upgrades.Remove(upgrade);
        }
    }

    public void Hide(UpgradeBase upgrade)
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        upgrade.LevelUp();
    }
}
