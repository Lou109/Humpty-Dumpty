using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    // parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    public void CountBlocks()
    {
        breakableBlocks++;
    }
  
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            Destroy(FindObjectOfType<LoseColider>().gameObject);
        }
      
        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);
        }
    }
}