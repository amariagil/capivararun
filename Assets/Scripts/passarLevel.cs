using UnityEngine;
using UnityEngine.SceneManagement;

public class passarLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arvore"))
        {
            LoadNextLevel(); // Chama o método para carregar o próximo nível
        }
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevelByName(string Level2)
    {
        SceneManager.LoadScene(Level2);
    }
}
