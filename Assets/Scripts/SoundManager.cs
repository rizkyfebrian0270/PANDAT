using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Pastikan ada referensi ke slider
        if (volumeSlider == null)
        {
            Debug.LogError("Volume Slider belum di-assign ke SoundManager!");
            return;
        }

        // Set nilai awal dari PlayerPrefs
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }

        Load();

        // Tambahkan listener agar bisa update saat dislide
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        float volume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = volume;
        AudioListener.volume = volume;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
