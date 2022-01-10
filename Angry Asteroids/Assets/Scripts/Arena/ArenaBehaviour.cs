using UnityEngine;

public class ArenaBehaviour : MonoBehaviour
{
    public static float Width = 1920;
    public static float Height = 1080;

    public static Vector2 GetSize()
    {
        return new Vector2(Width, Height);
    }

    public void Start()
    {
        transform.localScale = new Vector3(Width, Height, 0);
    }
}
