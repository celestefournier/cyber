using System.Collections;
using UnityEngine;

public class LaserUpgrade : UpgradeBase
{
    [SerializeField] LaserWeapon laserWeapon;

    float fireInterval = 3;

    void Awake()
    {
        levelMax = 5;
    }

    public override void LevelUp()
    {
        if (level >= levelMax)
            return;

        level++;

        if (level == 1)
            StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);

            AudioManager.Instance.Play(Sound.Laser);

            for (int i = 0; i < level; i++)
            {
                var randomRotate = Quaternion.Euler(0, 0, Random.Range(0, 360));

                Instantiate(laserWeapon, transform.position, randomRotate, transform)
                    .Init(player, onKill);
            }
        }
    }
}
