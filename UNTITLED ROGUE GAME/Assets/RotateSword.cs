using System.Collections;
using System.Collections.Generic;
using TopDownCharacter2D.Stats;
using UnityEngine;

public class RotateSword : MonoBehaviour
{
    public SpriteRenderer armRenderer;
    public Transform pivot;
    public Animator anim;

    public void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //armRenderer.flipY = Mathf.Abs(rotZ) > 90f;

        pivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    public void Attack()
    {
        anim.SetBool("Attack",true);
        StartCoroutine(NoAttack());
    }
    IEnumerator NoAttack()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Attack", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var temp = collision.gameObject.GetComponent<CharacterStatsHandler>() as IDamageable;
        if (temp != null)
        {
            temp.OnHurt(10);
        }
    }
}
