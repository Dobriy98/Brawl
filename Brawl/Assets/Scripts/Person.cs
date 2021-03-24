using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameOver gameOverScript;
    protected float speed;
    protected float radiusToAttack;
    protected float damage;
    protected float health;
    protected float startHealth;

    private GameObject targetToAttack;
    private Person targetToAttackScript;

    private float interval = 0;
    private float secondsToAttack = 2;

    private bool canMove = true;
    private bool canAttack = false;
    private bool isRed;

    private void Start()
    {
        ChooseTarget();
    }

    private void Update()
    {
        Interaction();
        if (canAttack)
        {
            interval -= Time.deltaTime;
            if (interval <= 0)
            {
                Attack();
                interval = secondsToAttack;
            }
        }
        if (canMove)
        {
            Move();
        }
    }

    private void ChooseTarget()
    {
        isRed = this.gameObject.GetComponent<RedPerson>();
        if (isRed)
        {
            if (BluePerson.GetPesonList().Count > 0)
            {
                targetToAttack = BluePerson.GetTarget();
                targetToAttackScript = targetToAttack.GetComponent<Person>();
            }
        }
        else
        {
            if (RedPerson.GetPesonList().Count > 0)
            {
                targetToAttack = RedPerson.GetTarget();
                targetToAttackScript = targetToAttack.GetComponent<Person>();
            }
        }
    }

    private void Interaction()
    {
        if (targetToAttack == null)
        {
            ChooseTarget();
        }
        else
        {
            float distance = Vector3.Distance(transform.position, targetToAttack.transform.position);
            if (distance <= radiusToAttack)
            {
                canAttack = true;
                canMove = false;
            }
            else
            {
                canAttack = false;
                canMove = true;
            }
        }
    }

    private void Move()
    {
        if (targetToAttack != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetToAttack.transform.position, step);
        }
    }

    private void Attack()
    {
        if (targetToAttack != null)
        {
            targetToAttackScript.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (healthBar != null)
        {
            float damageToReduceHB = damageTaken / startHealth;
            healthBar.ReduceHealthBar(damageToReduceHB);

            health -= damageTaken;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (isRed)
        {
            RedPerson.RemoveFromList(this.gameObject);
        }
        else
        {
            BluePerson.RemoveFromList(this.gameObject);
        }

        Destroy(this.gameObject);

        if (RedPerson.GetPesonList().Count <= 0)
        {
            gameOverScript.BlueWins();
        }
        else if (BluePerson.GetPesonList().Count <= 0)
        {
            gameOverScript.RedWins();
        }
    }

}
