using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    public int health = 250;

    [SerializeField]
    public int maxHealth = 250;

    public delegate void HealthValueChangedHandler(int newHealth, int newMaxHealth);

    public event HealthValueChangedHandler HealthValueChanged;

    void Awake()
    {
        // TODO: Code here
    }

    void Start()
    {
        StartCoroutine(DamageCounter());
    }

    IEnumerator DamageCounter()
    {
        while (health > 1)
        {
            yield return new WaitForSeconds(1);
            AddDamage(1);
        }
    }

    void AddDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);

        if (HealthValueChanged != null)
            HealthValueChanged(health, maxHealth);
    }

    void Reset()
    {
        health = maxHealth;

        if (HealthValueChanged != null)
            HealthValueChanged(health, maxHealth);
    }
}
