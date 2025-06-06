using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Cek referensi
        if (volumeSlider == null)
        {
            Debug.LogError("Slider belum di-assign di inspector!");
            return;
        }

        // Jika belum ada setting volume, set default
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }

        // Load nilai dan langsung terapkan ke volume
        float savedVolume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Tambahkan listener agar update volume saat slider digeser
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("musicVolume", value);
    }
}
