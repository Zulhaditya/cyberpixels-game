using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public AudioSource audioSource;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
