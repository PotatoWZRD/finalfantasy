using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip song;
    public AudioClip enemyHit;
    public AudioClip problemWrong;
    public AudioClip problemRight;

    public bool isAudioOn;

    private void Start()
    {
        musicSource.clip = song;
        if(isAudioOn)
        {
            musicSource.Play();

        }
    }

    public void PlaySfx(AudioClip clip)
    {
        if(isAudioOn)
        {
            sfxSource.PlayOneShot(clip);
        }
        
    }

    /*
     Game Sound InCorrect Organic Violin by Bertrof -- https://freesound.org/s/351565/ -- License: Attribution 3.0
    Game Sound Correct Organic Violin by Bertrof -- https://freesound.org/s/351566/ -- License: Attribution 3.0
    Hit Modulated FX.wav by Motion_S -- https://freesound.org/s/177850/ -- License: Attribution 4.0
     */
}
