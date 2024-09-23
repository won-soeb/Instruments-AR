using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note") && other != null)
        {
            other.GetComponent<NoteManager>().PlayNote(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            other.GetComponent<NoteManager>().PlayNote(false);
        }
    }
}
