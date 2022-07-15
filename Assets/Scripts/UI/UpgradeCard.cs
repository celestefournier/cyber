using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] Image photo;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI level;

    public void Init(UpgradeBase upgrade, Action onClick)
    {
        this.photo.sprite = upgrade.photo;
        this.title.text = upgrade.title;
        this.description.text = upgrade.description;
        this.level.text = $"Lvl {upgrade.level}";

        GetComponent<Button>().onClick.AddListener(() => onClick());
    }
}
