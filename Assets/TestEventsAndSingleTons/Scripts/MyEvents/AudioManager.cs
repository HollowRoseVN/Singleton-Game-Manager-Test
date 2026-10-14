using System.Net.NetworkInformation;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Allows you to assign your AudioSource and Click Sound in the Inspector

    [SerializeField] 
    private AudioSource audioSource;
    private AudioClip YumSound;
    private AudioClip YuckSound;

    private static AudioManager m_Instance;
    public static AudioManager Instance

    {
        get
        {
            if (m_Instance == null) {
                m_Instance = FindAnyObjectByType<AudioManager>();
            }

            return m_Instance;
        }
    }
    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

   // public void PlayYumSound()
   // {
   //     if (audioSource != null && YumSound != null)
      //  {
            // PlayOneShot prevents overlapping audio files from cutting each other off
       //     audioSource.PlayOneShot(YumSound);
      //  }
  //  }
   // public void PlayYuckSound()
   // {
   //     if (audioSource != null && YuckSound != null)
    ///    {
        // PlayOneShot prevents overlapping audio files from cutting each other off
    //        audioSource.PlayOneShot(YuckSound);
     //   }
}
