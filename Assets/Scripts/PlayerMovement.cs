using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private BoxCollider2D _collider;
    
    [SerializeField]private LayerMask ground;
    [SerializeField]
    private float moveSpeed = 7f;
    [SerializeField]
    private float jumpForce = 14f;
    [SerializeField]
    private AudioSource jumpEffect;
    
    private static readonly int State = Animator.StringToHash("animationState");

    private enum AnimationState
    {
        Idle,
        Run,
        Jump,
        Fall
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(dirX * moveSpeed,_rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpEffect.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
        UpdateAnimation(dirX);
        
    }

    private void UpdateAnimation(float dirX)
    {
        _renderer.flipX = dirX < 0;
        var state = AnimationState.Idle;
        if (dirX != 0) state = AnimationState.Run;
        if (_rb.velocity.y > .1f) state = AnimationState.Jump;
        if (_rb.velocity.y < -.1f) state = AnimationState.Fall;
        _animator.SetInteger(State, (int)state);
    }

    private bool IsGrounded()
    {
        var bounds = _collider.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f,ground);
    }
}
