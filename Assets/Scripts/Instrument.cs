using UnityEngine;

public abstract class Instrument : MonoBehaviour
{
    protected AudioSource audio;//연주 사운드
    protected ParticleSystem particle;//이펙트
    protected MeshRenderer renderers;
    //인식 표시
    [Header("피아노, 드럼")]
    public Material[] materials;
    [Header("벨")]
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
