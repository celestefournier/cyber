using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] OrbUpgrade orbUpgrade;

    Player player;

    void Start()
    {
        player = GetComponent<Player>();

        orbUpgrade.Init(player.transform, player.OnKillEnemy);
    }
}
