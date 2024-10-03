public class DrumNote : Instrument
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
            Instantiate(effectNote, transform.position, UnityEngine.Quaternion.Euler(0, 180, 0));
        }
        else
        {
            audio.Stop();
        }
    }
}
