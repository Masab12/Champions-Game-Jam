using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 

    [SerializeField] AudioSource backgroundMusicSource;
    [SerializeField] AudioSource soundEffectsSource;

    [SerializeField] AudioClip backgroundMusicClip;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip gunfireSound;
    [SerializeField] AudioClip victorySound;
    [SerializeField] AudioClip gameOverSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make AudioManager persistent
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.clip = backgroundMusicClip;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayExplosionSound()
    {
        soundEffectsSource.PlayOneShot(explosionSound);
    }

    public void PlayGunfireSound()
    {
        soundEffectsSource.PlayOneShot(gunfireSound);
    }
    public void PlayVictorySound()
    {
        soundEffectsSource.PlayOneShot(victorySound);
    }

    public void PlayGameOverSound()
    {
        soundEffectsSource.PlayOneShot(gameOverSound);
    }
}