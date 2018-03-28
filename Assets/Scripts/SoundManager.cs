using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource efxSource;
    public float pitch = 1.0f;
    public float volume = 1.0f;
    
    public void PlaySingle(AudioClip clip) {
        efxSource.clip = clip;
        efxSource.pitch = pitch;
        efxSource.volume = volume;
        efxSource.Play();
    }
}