using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyComponent;
    [SerializeField] GameObject descriptionHolder;
    [SerializeField] TextMeshProUGUI skillTitle;
    [SerializeField] TextMeshProUGUI skillDescription;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] Button buyButton;

    [SerializeField] List<Image> skillsImage;
    [SerializeField] List<Sprite> skillsSprites;
    [SerializeField] List<Sprite> skillsSelectedSprites;

    Image selectedSkill;
    int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        moneyComponent.text = $"{money}G";
        CheckAvailableSkills();
    }

    void CheckAvailableSkills()
    {
        foreach (var skill in skillsImage)
        {
            var hasSkill = PlayerPrefs.GetInt($"{skill.gameObject.name}_Skill", 0) == 1;

            skill.gameObject.GetComponent<Button>().interactable = !hasSkill;
        }
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

        var selectedSkillName = selectedSkill.gameObject.name;
        int costInterno = 0;

        switch (selectedSkillName)
        {
            case "HP":
                skillTitle.text = "+HP";
                skillDescription.text = "Mais 1 vida";
                costInterno = 300;
                cost.text = $"{300}G";
                break;
            case "XP":
                skillTitle.text = "+XP";
                skillDescription.text = "Começa no level 1";
                costInterno = 350;
                cost.text = $"{350}G";
                break;
            case "Vel":
                skillTitle.text = "+Vel";
                skillDescription.text = "Mais velocidade";
                costInterno = 400;
                cost.text = $"{400}G";
                break;
        }

        buyButton.interactable = costInterno <= money;
    }

    public void Buy()
    {
        var cost = GetCost();

        if (cost <= money)
        {
            money -= cost;

            PlayerPrefs.SetInt($"{selectedSkill.gameObject.name}_Skill", 1);
            PlayerPrefs.SetInt("Money", money);
            moneyComponent.text = $"{money}G";
            buyButton.interactable = cost <= money;
            CheckAvailableSkills();
        }
    }

    int GetCost()
    {
        var selectedSkillName = selectedSkill.gameObject.name;

        switch (selectedSkillName)
        {
            case "HP":
                return 300;
            case "XP":
                return 350;
            case "Vel":
                return 400;
            default:
                return 0;
        }
    }
}
