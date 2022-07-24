using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI money;
    [SerializeField] GameObject descriptionHolder;
    [SerializeField] TextMeshProUGUI skillTitle;
    [SerializeField] TextMeshProUGUI skillDescription;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] Button buyButton;

    [SerializeField] List<Image> skillsImage;
    [SerializeField] List<Sprite> skillsSprites;
    [SerializeField] List<Sprite> skillsSelectedSprites;

    Image selectedSkill;

    void Start()
    {
        money.text = $"{200}G";
    }

    public void SelectSkill(Image skill)
    {
        selectedSkill = skill;

        UpdateDescription();

        for (int i = 0; i < skillsImage.Count; i++)
        {
            var skillImage = skillsImage[i];
            skillImage.sprite = skillImage == selectedSkill ? skillsSelectedSprites[i] : skillsSprites[i];
        }
    }

    void UpdateDescription()
    {
        descriptionHolder.SetActive(true);
        buyButton.interactable = true;

        var selectedSkillName = selectedSkill.gameObject.name;

        switch (selectedSkillName)
        {
            case "HP":
                skillTitle.text = "+HP";
                skillDescription.text = "Mais vida";
                cost.text = $"{300}G";
                break;
            case "XP":
                skillTitle.text = "+XP";
                skillDescription.text = "Começa com level a mais";
                cost.text = $"{350}G";
                break;
            case "Vel":
                skillTitle.text = "+Vel";
                skillDescription.text = "Mais velocidade";
                cost.text = $"{400}G";
                break;
        }
    }

    public void Buy()
    {
        // Comprar skill
    }
}
