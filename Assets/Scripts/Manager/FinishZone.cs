using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    public int requiredScore = 50;

    private void OnTriggerEnter(Collider other)
    {
        
        if(!other.CompareTag("Player"))
        return;

        PlayerScore player = other.GetComponent<PlayerScore>();
        if (player == null) return;

        if(player.score >= requiredScore)
        {
            Debug.Log("You Won!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Less than required score: " + player.score + "/" + requiredScore);
        }
    }
}
