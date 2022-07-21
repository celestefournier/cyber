using UnityEngine;

public class OrbUpgrade : UpgradeBase
{
    [SerializeField] Orb orbPrefab;

    float distance = 0.35f;
    float rotationSpeed = 70f;

    void Awake()
    {
        levelMax = 5;
    }

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
            var vectorAngle = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
            var position = vectorAngle * distance + transform.position;

            Instantiate(orbPrefab, position, Quaternion.identity, transform).Init(player, onKill);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
