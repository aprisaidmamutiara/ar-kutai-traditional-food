using UnityEngine;

public class AudioMakanan : MonoBehaviour
{
    private AudioSource audioSource;

    private AudioClip currentClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // menerima audio dari marker
    public void SetAudio(AudioClip clip)
    {
        currentClip = clip;
    }

    // dipanggil tombol suara
    public void PlayAudio()
    {
        if (currentClip != null)
        {
            audioSource.clip = currentClip;
            audioSource.Play();
        }
    }
}