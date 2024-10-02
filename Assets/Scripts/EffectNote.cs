using UnityEngine;

public class EffectNote : MonoBehaviour
{
    public float moveSpeed;
    public float duration;
    private void Start()
    {
        Destroy(gameObject, duration);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
