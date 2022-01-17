using UnityEngine;

public class ArenaBehaviour : MonoBehaviour
{
    public static float Width = 1920;
    public static float Height = 1080;

    public static Vector2 GetSize()
    {
        return new Vector2(Width, Height);
    }

    public static Vector2 GetRandomPositionInside()
    {
        var randX = Random.Range(0, Width) - Width/2;
        var randY = Random.Range(0, Height) - Height/2;
        return new Vector2(randX, randY);
    }

    public void Start()
    {
        transform.localScale = new Vector3(Width, Height, 0);
    }
}
