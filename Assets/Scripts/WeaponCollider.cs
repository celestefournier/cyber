using System;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    Action<Collider2D> trigger;

    public void Init(Action<Collider2D> trigger)
    {
        this.trigger = trigger;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        trigger(other);
    }
}