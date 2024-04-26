using System.Collections;
using System.Collections.Generic;
using TopDownCharacter2D.Stats;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : EnemyStateController, IDamageable
{
    public float HP;
    public float maxhp;
    public Slider healthSlider;
    public float AttackDistance;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        StateTransition();
        if (currentState.action != null) currentState.action.OnUpdate();
    }
    public void OnHurt(float damage)
    {
        
        HP -= damage;
        //healthSlider.value = HP / maxhp;
        //var animator = healthSlider.GetComponent<Animator>();
        //animator.SetTrigger("PlayEffect");
        if (HP < 0) Destroy(gameObject);
    }
    public void LaunchBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        var bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.velocity = target.transform.position;
    }
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
