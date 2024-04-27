using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Slider health;
    [SerializeField] private CapsuleCollider col;

    public Action onDeath;
    private int hp = 2;
    private bool isAlive = true;
    public void takeDamage(int damage)
    {
        
        if (isAlive)
        {
            hp -= damage;
           
            health.value = hp;
            if (hp <= 0)
            {
                Death();
            }
        }
    } 

    public void Death()
    {
        col.enabled = false;
        health.gameObject.SetActive(false);
        animator.enabled=false;
        onDeath?.Invoke();
        isAlive = false;
    }
}
