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
        }
        else
        {
            audio.Stop();
        }
    }
}
