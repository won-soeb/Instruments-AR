using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<Instrument>().PlayNote(true);
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
