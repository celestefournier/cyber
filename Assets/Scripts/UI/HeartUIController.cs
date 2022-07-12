using UnityEngine;

public class HeartUIController : MonoBehaviour
{
    [SerializeField] GameObject heartFullPrefab;
    [SerializeField] GameObject heartEmptyPrefab;

    public void SetHeart(float hearts, float maxHeart)
    {
        foreach (Transform heart in transform)
            Destroy(heart.gameObject);

        for (int i = 0; i < maxHeart; i++)
        {
            Instantiate(i < hearts ? heartFullPrefab : heartEmptyPrefab, transform);
        }
    }
}
