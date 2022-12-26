using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private List<Sound> _musics = new List<Sound>();
    [SerializeField] private List<Sound> _sounds = new List<Sound>();

    public bool IsMute { get; private set; } = false;

    public void SwitchMuteState()
    {
        foreach (var music in _musics)
        {
            music.AudioSource.mute = !music.AudioSource.mute;
        }

        foreach (var sound in _sounds)
        {
            sound.AudioSource.mute = !sound.AudioSource.mute;
        }

        IsMute = !IsMute;
    }

    public void PlaySound(string soundName)
    {
        var sound = _sounds.FirstOrDefault(sound => sound.Name == soundName);

        sound.AudioSource.Play();
    }

    public void PlayMusic(string musicName)
    {
        foreach (var music in _musics)
        {
            if (music.Name == musicName)
                music.AudioSource.Play();
            else
                music.AudioSource.Stop();
        }
    }

    public void StopAllMusic()
    {
        foreach (var music in _musics)
        {
            music.AudioSource.Stop();
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);

        foreach (var sound in _sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();

            sound.AudioSource.clip = sound.AudioClip;
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.playOnAwake = false;
        }

        foreach (var music in _musics)
        {
            music.AudioSource = gameObject.AddComponent<AudioSource>();

            music.AudioSource.clip = music.AudioClip;
            music.AudioSource.volume = music.Volume;
            music.AudioSource.pitch = music.Pitch;
            music.AudioSource.loop = true;
        }

        PlayMusic("Main");
    }
}
