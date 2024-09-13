using UnityEngine;

public class Controller : MonoBehaviour
{
    RaycastHit hit;
    Block block;
    private bool isGrab = false;
    private void Start()
    {
        block = FindAnyObjectByType<Block>();
    }
    private void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, 1 << 6))
        {
            block.Grab(hit.point, isGrab);
        }
        else
        {
            block.Grab(hit.point, false);
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
    public void ButtonDown()
    {
        isGrab = true;
        Debug.Log("button Down");
    }
    public void ButtonUp()
    {
        isGrab = false;
        Debug.Log("button Up");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Debug.Log("Block1");
        }
    }
}
