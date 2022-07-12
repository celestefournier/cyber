using UnityEngine;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] RectTransform bar;

    public void SetExperience(float experience, float total)
    {
        bar.localScale = new Vector3(experience / total, 1, 1);
    }
}
