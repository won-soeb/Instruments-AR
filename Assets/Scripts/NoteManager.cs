using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public enum InstrumentType { Piano, Drum, Bell }//악기 종류
    public InstrumentType type;
    private AudioSource audio;//연주 사운드
    private ParticleSystem particle;//이펙트
    private MeshRenderer renderers;
    //인식 표시
    [Header("피아노, 드럼")]
    public Material[] materials;
    [Header("벨")]
    public Animator anim;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        renderers = GetComponent<MeshRenderer>();
    }
    //악기 종류에 따라 다른 로직
    public void CheckNote(bool check)
    {
        if (type == InstrumentType.Bell)
        {
            anim.SetBool("IsFocusing", check);
        }
        else
        {
            if (check)
            {
                renderers.material = materials[1];
                particle.Play();
            }
            else
            {
                renderers.material = materials[0];
                particle.Stop();
            }
        }
    }
    public void PlayNote(bool note)
    {
        if (note)
        {
            //if (audio.isPlaying) return;
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
