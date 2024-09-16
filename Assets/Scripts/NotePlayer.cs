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

        //��Ʈ ������ Ray
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

        //�Ǳ� ���ֿ� Ray
        if (Physics.Raycast(transform.position, dir, out hit, 10, 1 << 6))
        {
            if (Input.GetMouseButton(0))//�׽�Ʈ - ���콺�� ������ ���� �Ҹ��� ����Ʈ ���
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
