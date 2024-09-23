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
    //�Ǳ� ������ ���� �ٸ� ����
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
