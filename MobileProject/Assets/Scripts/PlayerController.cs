using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Setup Fields")]
    public float attackSpeed;
    Vector2 moveVec;
    public GameObject hpBar;

    [Header("Stats")]
    public float damage;
    public float moveSpeed;
    public float health;
    public float blockAmount;

    // Local Variables
    float currentHealth;
    float dps;
    Animator anim;
    Rigidbody2D rb;
    bool dashing;
    bool attacking;
    bool blocking;
    [HideInInspector] public EnemyController collided;
    AttackHitBox ahb;
    HPBar hp;

    private void Awake()
    {
        moveVec = Vector2.right;
        currentHealth = health;
        dps = damage * attackSpeed;

        ahb = GetComponentInChildren<AttackHitBox>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponentInChildren<HPBar>();

        anim.SetFloat("SpeedMultiplier", attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (collided) ? Vector2.zero : (dashing) ? moveVec * moveSpeed * 5.0f : moveVec * moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            // If in range - Attack
            if (collided)
            {
                attacking = false;
                anim.SetTrigger("AttackClick");
                return;
            }
            // If not in range - Dash forward
            dashing = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // If in range - Attack
            if (collided)
            {
                attacking = false;
                blocking = true;
                return;
            }
            // If not in range - Dash forward
            dashing = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            blocking = false;
        }

        SetAnims();
    }

    void SetAnims()
    {
        anim.SetBool("Blocking", blocking);
        anim.SetBool("Attacking", attacking);
        anim.SetFloat("MoveSpeed", Mathf.Clamp01(rb.velocity.x));
        anim.SetBool("Collided", collided);
        anim.SetFloat("SpeedMultiplier", attackSpeed);
    }

    public void SetAttacking()
    {
        attacking = true;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth -= Mathf.Clamp(_damage - blockAmount, 0, _damage);
        hp.UpdateHealth(currentHealth / health);
        if (currentHealth <= 0.0f)
        {
            Die();
            return;
        }
    }
    void Die()
    {
        anim.SetTrigger("Death");
        Destroy(this.gameObject, 3.0f);
    }

    public void DealDamage()
    {
        if (collided)
            collided.TakeDamage(1.0f);
    }

    #region CollisionEvents
    public void HitBoxOn()
    {
        ahb.Toggle(true);
    }
    public void HitBoxOff()
    {
        ahb.Toggle(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
            collided = collision.gameObject.GetComponent<EnemyController>();
    
        dashing = false;
        SetAttacking();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() == collided)
            collided = null;
    }
    #endregion CollisionEvents
}
