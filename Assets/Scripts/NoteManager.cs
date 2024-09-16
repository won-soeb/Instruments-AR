using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private AudioSource audio;//���� ����
    private ParticleSystem particle;//����Ʈ
    private MeshRenderer renderers;
    public Material[] materials;//�ν� ǥ��

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
