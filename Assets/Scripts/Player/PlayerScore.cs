using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{
    public int score = 0;

    public AudioClip coinSound;
    private AudioSource audioSource;

    public TMP_Text scoreText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

        UpdateScoreUI();

        audioSource = GetComponent<AudioSource>();
    }

    public void AddScore()
    {
        score += 10;
        UpdateScoreUI();
    }

    public void MinusScore()
    {
        score -= 5;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Puan:" + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            AddScore();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            MinusScore();
            Destroy(other.gameObject);
        }
        if (coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    


    }
}
