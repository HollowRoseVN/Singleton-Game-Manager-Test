using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Allows you to assign your AudioSource and Click Sound in the Inspector
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip YumSound;
    [SerializeField] private AudioClip YuckSound;

    // Public method that buttons can trigger
    public void PlayYumSound()
    {
        if (audioSource != null && YumSound != null)
        {
            // PlayOneShot prevents overlapping audio files from cutting each other off
            audioSource.PlayOneShot(YumSound);
        }
    }
    public void PlayYuckSound()
    {
        if (audioSource != null && YuckSound != null)
        {
            // PlayOneShot prevents overlapping audio files from cutting each other off
            audioSource.PlayOneShot(YuckSound);
        }
    }
}