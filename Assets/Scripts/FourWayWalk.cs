using UnityEngine;

public class FourWayWalk : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = default;
    private Rigidbody2D _rigidBody2D = default;
    private Vector3 _change = default;
    private Animator _animator = default;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove()
    {
        if (_change != Vector3.zero)
        {
            MoveCharacter();
            _animator.SetFloat("MoveX", _change.x);
            _animator.SetFloat("MoveY", _change.y);
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    private void MoveCharacter()
    {
        _rigidBody2D.MovePosition(transform.position + _change * _playerSpeed * Time.deltaTime);
    }
}
