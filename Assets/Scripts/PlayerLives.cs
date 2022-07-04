using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [SerializeField]
    private AudioSource hitSfx;
    
    private Animator _animator;
    private Rigidbody2D _rb;

    private static readonly int Death = Animator.StringToHash("death");

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Damage();
        }
    }

    private void Damage()
    {
        _animator.SetTrigger(Death);
        _rb.bodyType = RigidbodyType2D.Static;
        hitSfx.Play();
    }

    private void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}