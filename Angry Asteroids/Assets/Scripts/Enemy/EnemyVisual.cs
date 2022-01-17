using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    public SpriteRenderer[] VisualElements;

    public void SetEnemyColor(Color color)
    {
        foreach (var visualElement in VisualElements)
        {
            visualElement.color = color;
        }
    }
}
