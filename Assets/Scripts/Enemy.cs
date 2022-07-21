using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Material hitMaterial;

    bool canMove = true;
    float experienceGain = 1;
    float knockbackForce = 0.2f;
    float health = 2;

    Transform player;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    Material spriteMaterial;

    public void Init(Transform player)
    {
        this.player = player;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        spriteMaterial = sprite.material;
    }

    void Update()
    {
        if (!canMove)
            return;

        var directionBase = player.position - transform.position;
        var direction = directionBase.normalized * moveSpeed;

        rb.velocity = direction;
    }

    public void SetDamage(float damage, Vector3 contactPoint, Action<float> onDie)
    {
        StartCoroutine(DamageEffect());

        health -= damage;

        if (health <= 0)
        {
            anim.SetBool("died", true);
            rb.velocity = Vector2.zero;
            canMove = false;
            onDie(experienceGain);
        }

        var knockbackPos = (transform.position - contactPoint).normalized;

        rb.DOMove(knockbackPos * knockbackForce + transform.position, 0.2f).SetEase(Ease.Linear);
    }

    IEnumerator DamageEffect()
    {
        sprite.material = hitMaterial;
        yield return new WaitForSeconds(0.1f);
        sprite.material = spriteMaterial;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
