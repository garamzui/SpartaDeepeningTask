using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum SFX
{
}

public enum BGM
{
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private AudioClip[] bgmClips;

    private Dictionary<SFX, AudioClip> sfxDict;
    private Dictionary<BGM, AudioClip> bgmDict;

    private AudioSource sfxSource;
    private AudioSource bgmSource;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 오디오소스 2개 부착
        sfxSource = gameObject.AddComponent<AudioSource>();
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;

        // 딕셔너리로 변환
        sfxDict = sfxClips.ToDictionary(c => (SFX)System.Enum.Parse(typeof(SFX), c.name));
        bgmDict = bgmClips.ToDictionary(c => (BGM)System.Enum.Parse(typeof(BGM), c.name));
    }

    public void PlaySFX(SFX type)
    {
        if (sfxDict.TryGetValue(type, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayBGM(BGM type)
    {
        if (bgmDict.TryGetValue(type, out AudioClip clip))
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}