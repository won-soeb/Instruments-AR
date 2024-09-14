using UnityEngine;

public class RaycastPitch : MonoBehaviour
{
    private RaycastHit hit;
    private void Update()
    {
        Vector3 dir = Camera.main.transform.forward;
        if (Physics.Raycast(transform.position, dir, out hit, 10, 1 << 6))
        {
            Debug.Log(hit.collider.name);
        }
        Debug.DrawRay(transform.position, dir * 10, Color.red);
    }
}
