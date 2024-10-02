using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSource;
    public AudioClip[] startClips;
    public AudioClip[] endClips;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySoundStart(int index)
    {
        audioSource.clip = startClips[index];
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    public void PlaySoundEnd(int index)
    {
        audioSource.clip = endClips[index];
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    //Test
    [ContextMenu("StartSound")]
    private void TestPlayStart()
    {
        PlaySoundStart(UIManager.instNumber);
    }
    [ContextMenu("EndSound")]
    private void TestPlayEnd()
    {
        PlaySoundEnd(UIManager.instNumber);
    }
}
