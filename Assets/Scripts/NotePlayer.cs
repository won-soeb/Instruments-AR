using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note") && UIManager.isPlaying)
        {
            other.GetComponent<Instrument>().PlayNote(true);
            GameManager.instance.CheckNote(other.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<Instrument>().PlayNote(false);
        }
    }
}
