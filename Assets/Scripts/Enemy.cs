using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player = default;
    [SerializeField] private float _distance = default;
    [SerializeField] private float _speedEnemy = default;
    [SerializeField] private float _enemyHealth = default;
    private Transform _playerPosition = default;
    private Vector2 _currentPosition = default;

    void Start()
    {
        _playerPosition = _player.GetComponent<Transform>();
        _currentPosition = GetComponent<Transform>().position;
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, _playerPosition.position) < _distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerPosition.position, _speedEnemy * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, _currentPosition) <= 0)
            {
                
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _currentPosition, _speedEnemy * Time.deltaTime);
            }
        }
    }
    
    public void TakeDamage(int _damageRecived)
    {
        _enemyHealth -= _damageRecived;
        if (_enemyHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
