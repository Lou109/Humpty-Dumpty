using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifecount;
    [SerializeField] Lives lives;

    void Start()
    {
        CountLives();
    }

    public void CountLives()
    {
        lifecount.text = "Lives: " + lives.numLives;
    }
}