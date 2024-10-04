using UnityEngine;
using UnityEngine.EventSystems;

public class NotePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // UI 요소가 터치된 경우, AR 화면 터치 처리 무시
        if (EventSystem.current.IsPointerOverGameObject()) return;

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
