using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour
{
    [SerializeField] private AudioClip ballLostSound;
    [SerializeField] Lives lives;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            lives.numLives = 3;
        }
        else
        {
            lives.numLives += 1;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {    
        lives.numLives--; 
        if (lives.numLives <=0)
        {
            SceneManager.LoadScene("Game Over");  
        }
        else
        {
            FindObjectOfType<GameplayController>().CountLives();
            FindObjectOfType<Ball>().SetBallPosition();
        }
        AudioSource.PlayClipAtPoint(ballLostSound, transform.position, 1f);
    }
}
