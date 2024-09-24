using UnityEngine;

public class NoteChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<Instrument>().CheckNote(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<Instrument>().CheckNote(false);
        }
    }
}
