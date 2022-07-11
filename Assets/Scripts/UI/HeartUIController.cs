using UnityEngine;

public class HeartUIController : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;

    public void SetHeart(float hearts)
    {
        foreach (Transform heart in transform)
            Destroy(heart.gameObject);

        for (int i = 0; i < hearts; i++)
        {
            Instantiate(heartPrefab, transform);
        }
    }
}
