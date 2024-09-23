using UnityEngine;

public class RayController : MonoBehaviour
{
    public GameObject notePlayer;
    private void Update()
    {
        //Vector3 dir = Camera.main.transform.forward;
        //Debug.DrawRay(transform.position, dir * 10, Color.red);
        if (Input.GetMouseButton(0))
        {
            notePlayer.SetActive(true);
        }
        else
        {
            notePlayer.SetActive(false);
        }
    }
}
