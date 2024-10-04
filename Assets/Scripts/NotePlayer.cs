using UnityEngine;
using UnityEngine.EventSystems;

public class NotePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // UI ��Ұ� ��ġ�� ���, AR ȭ�� ��ġ ó�� ����
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
