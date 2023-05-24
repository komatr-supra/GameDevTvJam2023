using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float maxLifetime = 3f;
    private float direction;
    private float speed;
    private Collider2D creatorCollider;
    private int damage;
    private Action onFinished;

    public void Init(float direction, float speed, int damage, Collider2D creatorCollider, Action onFinished)
    {
        this.direction = direction;
        this.speed = speed;
        this.damage = damage;
        this.creatorCollider = creatorCollider;
        this.onFinished = onFinished;
        if(direction < 0) transform.localScale = new Vector3(-1, 1, 1);
        StartCoroutine(LifeTime());
    }
    private void Update()
    {
        float movedValue = direction * speed * Time.deltaTime;
        transform.position += new Vector3(movedValue, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other == creatorCollider) return;
        if(other.TryGetComponent<CharacterStats>(out CharacterStats characterStats))
        {
            characterStats.TakeDamage(damage);
            VFXCreator.Instance.CreateEffect(transform.position, VFXType.explosion);
            Despawn();
        }
    }

    private void Despawn()
    {
        StopAllCoroutines();
        onFinished();
        Destroy(gameObject);
    }
    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(maxLifetime);
        Despawn();
    }
}
