using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float _playerSpeed = default;
    [SerializeField] private Animator _playerAnimator = default;
    private float _horizontal = default;
    private float _vertical = default;
    private Rigidbody2D _rb2d = default;
    private bool _facingRight = true;
    private bool _isDeath = false;
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>(); 
        _playerAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {

        if (_isDeath)
        {
            return;
        }
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        
        if (_horizontal < 0)
        {
            _playerAnimator.SetBool("IsMoving", true);
        }
        if (_horizontal > 0)
        {
            _playerAnimator.SetBool("IsMoving", true);
        }
        if (_vertical < 0)
        {
            _playerAnimator.SetBool("IsMoving", true);
            _playerAnimator.SetBool("IsMovingFront", true);
        }
        if (_vertical > 0)
        {
            _playerAnimator.SetBool("IsMoving", true);
            _playerAnimator.SetBool("IsMovingBack", true);
        }
        if (_horizontal < 0 && _facingRight)
        {
            _playerAnimator.SetBool("IsMoving", true);
            Flip();
        }
        else if (_horizontal > 0 && !_facingRight)
        {
            _playerAnimator.SetBool("IsMoving", true);
            Flip();
        }
        
        if (_horizontal == 0 && _vertical == 0)
        {
            _playerAnimator.SetBool("IsMoving", false);
            _playerAnimator.SetBool("IsMovingFront", false);
            _playerAnimator.SetBool("IsMovingBack", false);
        }
    }
    
    private void FixedUpdate()
    {  
        _rb2d.velocity = new Vector2(_horizontal * _playerSpeed, _vertical * _playerSpeed);
    }
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
    public void PlayerIsDeath()
    {
        _isDeath = true;
     //   LevelManager.Instance.Restart();
    }
}
