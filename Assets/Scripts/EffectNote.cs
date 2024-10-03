using UnityEngine;

public class EffectNote : MonoBehaviour
{
    public float moveSpeed;
    public float duration;
    public enum Direction { UP, DOWN }
    public Direction dirType;
    private void Start()
    {
        Destroy(gameObject, duration);
    }
    private void Update()
    {
        switch (dirType)
        {
            case Direction.UP:
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                break;
            case Direction.DOWN:
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
                break;
        }
    }
}
