using System;
using UnityEngine;

public abstract class UpgradeBase : MonoBehaviour
{
    public Sprite photo;
    public string title;
    public string description;
    
    [HideInInspector]
    public int level;
    public int levelMax;

    protected Transform player;
    protected Action<float> onKill;

    public void Init(Transform player, Action<float> onKill)
    {
        this.player = player;
        this.onKill = onKill;
    }

    public virtual void LevelUp()
    {
    }
}
