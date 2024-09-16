using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    private RaycastHit hit;
    private NoteManager[] notes;
    private void Start()
    {
        notes = FindObjectsOfType<NoteManager>();
    }
    private void Update()
    {
        Vector3 dir = Camera.main.transform.forward;

        //노트 감지용 Ray
        if (Physics.Raycast(transform.position, dir, out hit, 10, 1 << 6))
        {
            foreach (var note in notes)
            {
                if (note == hit.collider.GetComponent<NoteManager>())
                {
                    note.CheckNote(true);
                }
                else
                {
                    note.CheckNote(false);
                }
            }
        }
        else
        {
            foreach (var note in notes)
            {
                note.CheckNote(false);
            }
        }

        //악기 연주용 Ray
        if (Physics.Raycast(transform.position, dir, out hit, 10, 1 << 6))
        {
            if (Input.GetMouseButton(0))//테스트 - 마우스를 누르는 동안 소리와 이펙트 재생
            {
                hit.collider.GetComponent<NoteManager>().PlayeNote(true);
            }
            else
            {
                hit.collider.GetComponent<NoteManager>().PlayeNote(false);
            }
            //Debug.Log(hit.collider.name);
        }
        Debug.DrawRay(transform.position, dir * 10, Color.red);
    }
}
