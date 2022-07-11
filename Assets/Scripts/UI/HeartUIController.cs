using UnityEngine;

public class HeartUIController : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] Player player;

    float hearts;

    void Start()
    {
        hearts = player.health;
        SetHeart(hearts);
    }

    public void SetHeart(float hearts)
    {
        this.hearts = hearts;

        foreach (Transform heart in transform)
            Destroy(heart.gameObject);

        for (int i = 0; i < hearts; i++)
        {
            Instantiate(heartPrefab, transform);
        }
    }
}
