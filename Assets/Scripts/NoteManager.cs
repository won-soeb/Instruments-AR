using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private AudioSource audio;//연주 사운드
    private ParticleSystem particle;//이펙트
    private MeshRenderer renderers;
    public Material[] materials;//인식 표시

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        renderers = GetComponent<MeshRenderer>();
    }
    public void CheckNote(bool check)
    {
        if (check)
        {
            renderers.material = materials[1];
        }
        else
        {
            renderers.material = materials[0];
        }
    }
    public void PlayeNote(bool note)
    {
        if (note)
        {
            if (audio.isPlaying) return;
            audio.Play();
            particle.Play();
        }
        else
        {
            audio.Stop();
            particle.Stop();
        }
    }
}
