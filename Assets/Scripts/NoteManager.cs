using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public enum InstrumentType { Piano, Drum, Bell }//�Ǳ� ����
    public InstrumentType type;
    private AudioSource audio;//���� ����
    private ParticleSystem particle;//����Ʈ
    private MeshRenderer renderers;
    //�ν� ǥ��
    [Header("�ǾƳ�, �巳")]
    public Material[] materials;
    [Header("��")]
    public Animator anim;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        renderers = GetComponent<MeshRenderer>();
    }
    public void CheckNote(bool check)
    {
        //�Ǳ� ������ ���� �ٸ� ����
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
