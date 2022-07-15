using UnityEngine;

public class OrbUpgrade : UpgradeBase
{
    [SerializeField] Orb orbPrefab;

    new int levelMax = 5;
    float distance = 0.35f;
    float rotationSpeed = 140f;

    public override void LevelUp()
    {
        if (level >= levelMax)
            return;

        foreach (Transform orb in transform)
            Destroy(orb.gameObject);

        level++;

        for (int i = 0; i < level; i++)
        {
            var angle = 360 / level * i + 1;
            var position = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));

            Instantiate(orbPrefab, position * distance, Quaternion.identity, transform)
                .Init(player, onKill);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
