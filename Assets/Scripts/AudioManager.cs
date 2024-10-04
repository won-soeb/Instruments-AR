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
        //미션 이벤트
        GameManager.instance.PlayMission += () => PlaySoundStart(UIManager.instNumber);
        GameManager.instance.SuccessMission += () => PlaySoundEnd(UIManager.instNumber);
    }
    public void PlaySoundStart(int index)
    {
        audioSource.clip = startClips[index];
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    private void PlaySoundEnd(int index)
    {
        audioSource.clip = endClips[index];
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
}
