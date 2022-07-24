using TMPro;
using UnityEngine;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] RectTransform bar;
    [SerializeField] TextMeshProUGUI textComponent;

    public void SetExperience(int level, int experience, int totalExp)
    {
        bar.localScale = new Vector3(experience / totalExp, 1, 1);
        textComponent.text = $"Lvl {level}";
    }
}
