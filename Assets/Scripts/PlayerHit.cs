
using System;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private int _meleeDamage = default;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy _basicEnemy = hitInfo.GetComponent<Enemy>();
        if (_basicEnemy != null)
        {
            _basicEnemy.TakeDamage(_meleeDamage);
        }
    }
}
