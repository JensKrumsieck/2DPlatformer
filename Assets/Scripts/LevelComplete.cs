using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
private AudioSource _sfx;

    private bool _completed;
    void Start()
    {
        _sfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !_completed)
        {
            _sfx.Play();
            Invoke(nameof(HandleLevelComplete), 1f);
            _completed = true;
        }
    }

    void HandleLevelComplete()
    {
        //go to next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
