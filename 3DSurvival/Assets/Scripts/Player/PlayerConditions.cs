using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public interface IDamagalbe
{
    void TakePhysicaIDamage(int damage);
}

public class PlayerConditions : MonoBehaviour, IDamagalbe
{
    public UICondition uiCondition;


    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }


    public float noHungerHealthDecay;
    public event Action onTakeDamage;



    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue == 0.0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0.0f)
        {
            Die();
        }

    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void Eat(float amount)
    {
        hunger.Add(amount);
    }


    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicaIDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}
