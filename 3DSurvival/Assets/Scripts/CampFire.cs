using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamagalbe> things = new List<IDamagalbe>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    // Update is called once per frame
    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicaIDamage(damage);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagalbe damagable))
        {
            things.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagalbe damagable))
        {
            things.Remove(damagable);
        }
    }
}
