using UnityEngine;

public class NoteChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<NoteManager>().CheckNote(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<NoteManager>().CheckNote(false);
        }
    }
}
