using System.Collections;
using System.Collections.Generic;
using TopDownCharacter2D.Stats;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : EnemyStateController, IDamageable
{
    public int typeEnemy;
    public float HP;
    public float maxhp;
    public Slider healthSlider;
    public float AttackDistance;
    public GameObject bulletPrefab;
    public int bulletSpeed;
    public GameObject sword;
    public SpriteRenderer enemySprite;
    public CharacterStatsHandler stats;
    
    private void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<CharacterStatsHandler>();
    }
    void Update()
    {
        StateTransition();
        if (currentState.action != null) currentState.action.OnUpdate();
        
    }
    public void OnHurt(float damage)
    {
        HP -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = HP / maxhp;
            var animator = healthSlider.GetComponent<Animator>();
            animator.SetTrigger("PlayEffect");
        }
        else
        {
            UnityEngine.Color newcolor = new(0f, HP / maxhp, 0f, 1.0f);
            enemySprite.color = newcolor;
        }
        if (HP <= 0)
        {
            bulletSpeed += 2;
            stats.money += 10;
            Destroy(gameObject);
        }
    }
    public void LaunchBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        var bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.velocity = (target.transform.position - transform.position) * bulletSpeed;
    }
    /*public void RotateSword()
    {
        var swordScript = sword.GetComponent<RotateSword>();
        swordScript.RotateArm(target.transform.position);
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var temp = collision.gameObject.GetComponent<CharacterStatsHandler>() as IDamageable;
        if (temp != null)
        {
            temp.OnHurt(5);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;
        }
       // target = GameObject.Find("Player");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }
}
