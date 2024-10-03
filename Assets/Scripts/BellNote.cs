public class BellNote : Instrument
{
    private void Awake()
    {
        base.Awake();
    }
    public override void CheckNote(bool check)
    {
        anim.SetBool("IsFocusing", check);
    }
    public override void PlayNote(bool note)
    {
        if (note)
        {
            //if (audio.isPlaying) return;
            audio.Play();
            Instantiate(effectNote, transform.position, UnityEngine.Quaternion.Euler(0, 180, 0));
        }
        else
        {
            audio.Stop();
        }
    }
}
