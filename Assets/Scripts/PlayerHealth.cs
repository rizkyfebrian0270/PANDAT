using UnityEngine;
using UnityEngine.SceneManagement; // untuk reload scene jika nyawa habis

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;
    public GameObject[] lifeIcons; // isi dengan UI hati di Inspector (opsional)

    private void Start()
    {
        currentLives = maxLives;
        UpdateLifeUI();
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            UpdateLifeUI();
        }
    }

    void Die()
    {
        Debug.Log("Player mati");
        // Bisa diganti dengan animasi mati, disable player, dll.
        gameObject.SetActive(false);
        // Atau reload scene:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateLifeUI()
    {
        if (lifeIcons.Length == 0) return;
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < currentLives);
        }
    }
}