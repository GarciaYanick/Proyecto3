using System.Collections;
using System.Collections.Generic;
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
        healthSlider.value = HP / maxhp;
        var animator = healthSlider.GetComponent<Animator>();
        animator.SetTrigger("PlayEffect");
    }
    public void LaunchBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        var bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.velocity = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        target = GameObject.Find("Player");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }
}
