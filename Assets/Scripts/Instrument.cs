using UnityEngine;

public abstract class Instrument : MonoBehaviour
{
    protected AudioSource audio;//���� ����
    protected ParticleSystem particle;//����Ʈ
    protected MeshRenderer renderers;
    //�ν� ǥ��
    [Header("�ǾƳ�, �巳")]
    public Material[] materials;
    [Header("��")]
    public Animator anim;
    [Header("Effect")]
    public GameObject effectNote;

    protected void Awake()
    {
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        renderers = GetComponent<MeshRenderer>();
    }
    public abstract void CheckNote(bool check);
    public abstract void PlayNote(bool note);
}
