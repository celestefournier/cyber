using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] Image photo;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;

    public void Init(Sprite photo, string title, string description, Action onClick)
    {
        // photo.sprite = photo;
        this.title.text = title;
        this.description.text = description;
        GetComponent<Button>().onClick.AddListener(() => onClick());
    }
}
