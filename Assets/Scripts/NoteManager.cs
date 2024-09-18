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
    public void CheckNote(bool check)
    {
        //악기 종류에 따라 다른 로직
        if (type == InstrumentType.Bell)
        {
            anim.SetBool("IsFocusing", check);
        }
        else
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
