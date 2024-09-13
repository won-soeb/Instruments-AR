using UnityEngine;

public class Block : MonoBehaviour
{
    public Material[] meshColor;
    MeshRenderer render;
    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }
    public void Grab(Vector3 pos,bool isGrab)
    {
        float distance = Vector3.Distance(pos, transform.position);
        Debug.Log(isGrab == true ? "collision" : "Non collision");
        if (isGrab)
        {
            render.material = meshColor[1];
            transform.SetParent(Camera.main.transform);
            //transform.position = new Vector3(
            //    Mathf.RoundToInt(transform.position.x),
            //    Mathf.RoundToInt(transform.position.y),
            //    Mathf.RoundToInt(transform.position.z));
        }
        else
        {
            render.material = meshColor[0];
            transform.SetParent(null);
        }
    }
}
