using TMPro;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private AudioSource collectSfx;
    
    private int _score = 0;
    private static readonly int Picked = Animator.StringToHash("Picked");

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Item")) return;
        _score++;
        collectSfx.Play();
        scoreText.text = $"Score: {_score.ToString()}";
        other.GetComponent<Animator>().SetTrigger(Picked);
    }
}
