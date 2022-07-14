using System;
using UnityEngine;

public class OrbUpgrade : MonoBehaviour
{
    [SerializeField] Orb orbPrefab;

    int level;
    int levelMax = 5;
    float distance = 0.35f;
    float rotationSpeed = 140f;

    Transform player;
    Action<float> onKill;

    public void Init(Transform player, Action<float> onKill)
    {
        this.player = player;
        this.onKill = onKill;

        Upgrade();
    }

    public void Upgrade()
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
