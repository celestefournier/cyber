using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] Sword sword;
    [SerializeField] SpriteRenderer swordSprite;
    [SerializeField] Material hitMaterial;
    [SerializeField] GameController gameController;
    [SerializeField] ExperienceBar experienceUI;
    [SerializeField] HeartUIController heartUI;
    [SerializeField] List<UpgradeBase> upgradeList;
    [SerializeField] LevelUpUIController levelUpScreen;

    [HideInInspector]
    public int expLevelUp = 15;
    [HideInInspector]
    public int experience;
    [HideInInspector]
    public int totalExperience;
    [HideInInspector]
    public float maxHealth = 3;
    [HideInInspector]
    public float health;

    int level = 1;
    bool canMove = true;
    float moveBaseSpeed = 0.7f;
    bool isInvencible;
    List<Transform> enemiesNearby = new List<Transform>();
    SpriteRenderer sprite;
    Animator anim;
    Rigidbody2D rb;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        health = maxHealth;
    }

    void Start()
    {
        GetSkills();

        heartUI.SetHeart(health, maxHealth);
        experienceUI.SetExperience(level, experience, expLevelUp);
        sword.Init(OnKillEnemy);
        upgradeList.ForEach(upgrade => upgrade.Init(transform, OnKillEnemy));
    }

    void GetSkills()
    {
        if (PlayerPrefs.GetInt("HP_Skill", 0) == 1)
        {
            maxHealth += 2;
            health = maxHealth;
        }
        if (PlayerPrefs.GetInt("XP_Skill", 0) == 1)
        {
            LevelUp();
        }
        if (PlayerPrefs.GetInt("Vel_Skill") == 1)
        {
            moveBaseSpeed += 0.3f;
        }
    }

    void Update()
    {
        if (canMove)
        {
            Move(joystick.Horizontal, joystick.Vertical);
            CheckEnemyAround();
        }
    }

    public void Move(float horizontal, float vertical)
    {
        var moveDirection = new Vector2(horizontal, vertical);
        var moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0f, 1f);
        var direction = moveDirection.normalized * moveSpeed * moveBaseSpeed;
        var isMoving = direction != Vector2.zero;

        if (isMoving)
        {
            if (!sword.isAttacking)
                sword.SetRotation(direction);

            sprite.flipX = direction.x < 0;
        }

        anim.SetBool("walking", isMoving);
        rb.velocity = direction;
    }

    void CheckEnemyAround()
    {
        if (enemiesNearby.Count <= 0)
            return;

        Transform closestEnemy = null;

        foreach (var enemy in enemiesNearby)
        {
            if (closestEnemy == null)
            {
                closestEnemy = enemy;
                continue;
            }

            if (Vector2.Distance(transform.position, enemy.position) < Vector2.Distance(transform.position, closestEnemy.position))
            {
                closestEnemy = enemy;
            }
        }

        sword.Attack(closestEnemy.position - transform.position);
    }

    public void OnKillEnemy(int experienceGain)
    {
        experience += experienceGain;
        totalExperience += experienceGain;

        if (experience >= expLevelUp)
        {
            LevelUp();
        }

        experienceUI.SetExperience(level, experience, expLevelUp);
    }

    void LevelUp()
    {
        level++;
        levelUpScreen.Show(level, upgradeList);
        expLevelUp += 30;
        experience = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !enemiesNearby.Contains(other.transform))
        {
            enemiesNearby.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy" && enemiesNearby.Contains(other.transform))
        {
            enemiesNearby.Remove(other.transform);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && !isInvencible)
            SetDamage(1, other.transform.position);
    }

    void SetDamage(float damage, Vector3 contactPoint)
    {
        StartCoroutine(Invicible());
        StartCoroutine(DamageEffect());

        health -= damage;
        heartUI.SetHeart(health, maxHealth);

        if (health <= 0)
            gameController.GameOver();

        float knockbackForce = 0.2f;
        var knockbackPos = (transform.position - contactPoint).normalized;

        rb.DOMove(knockbackPos * knockbackForce + transform.position, 0.2f).SetEase(Ease.Linear);
    }

    IEnumerator Invicible()
    {
        isInvencible = true;
        yield return new WaitForSeconds(0.3f);
        isInvencible = false;
    }

    IEnumerator DamageEffect()
    {
        Material prevPlayerMaterial = sprite.material;
        Material prevSwordMaterial = swordSprite.material;

        sprite.material = hitMaterial;
        swordSprite.material = hitMaterial;

        yield return new WaitForSeconds(0.1f);

        sprite.material = prevPlayerMaterial;
        swordSprite.material = prevSwordMaterial;
    }
}
