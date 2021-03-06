using System;
using UnityEngine;

public abstract class UpgradeBase : MonoBehaviour
{
    public Sprite photo;
    public string title;
    public string description;
    
    [HideInInspector]
    public int level;
    [HideInInspector]
    public int levelMax;

    protected Transform player;
    protected Action<int> onKill;

    public virtual void Init(Transform player, Action<int> onKill)
    {
        this.player = player;
        this.onKill = onKill;
    }

    public virtual void LevelUp()
    {
        level++;
    }
}
