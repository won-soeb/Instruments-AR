public class PianoNote : Instrument
{
    private void Awake()
    {
        base.Awake();
    }
    public override void CheckNote(bool check)
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
