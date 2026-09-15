using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<int> healthUpdated;
    public UnityEvent died;

    /*[SerializeField]
    List<DamageTypes> resistances = new List<DamageTypes>();
    
    [SerializeField]
    List<DamageTypes> weaknesses = new List<DamageTypes>();*/

    [SerializeField] GameObject parent;
    [SerializeField] int maxHealth = 5;
    public Factions faction = Factions.Enemies;
    private int _currentHealth;
    public int CurrentHealth
    {
        set {
            if (_currentHealth != value)
            {
                healthUpdated.Invoke(value);
            }
            if (value > _currentHealth)
            {
                //Healing Animation Here
            }
            if (value < _currentHealth)
            {
                //Damage Animation Here
            }
            _currentHealth = value;
        }
        get {
            return _currentHealth;
        }
    }

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, DamageTypes type = DamageTypes.Physical)
    {   
        /*if (weaknesses.Contains(type))
        {
            damage *= 2;
        }
        if (resistances.Contains(type))
        {
            damage = Mathf.CeilToInt((float)damage / 2.0f);
        }*/
        CurrentHealth -= damage;
        //healthUpdated.Invoke(_currentHealth);
        
        if (_currentHealth <= 0)
        {
            died.Invoke();
            Destroy(parent);
        }
    }
}

/*public enum Factions
{
    Players,
    Enemies
}*/