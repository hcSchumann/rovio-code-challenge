using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBoundryBehaviour : MonoBehaviour
{
    public Transform ArenaTransform;

    private float _halfArenaWidth;
    private float _halfArenaHeight;

    public void Start()
    {
        _halfArenaWidth = ArenaTransform.localScale.x / 2;
        _halfArenaHeight = ArenaTransform.localScale.y / 2;
    }

    public void Update()
    {
        var horizontalOffset = 0f;
        var verticalOffset = 0f;

        if (transform.position.x > _halfArenaWidth)
        {
            horizontalOffset = -2 * _halfArenaWidth;
        }
        else if(transform.position.x < -_halfArenaWidth)
        {
            horizontalOffset = 2 * _halfArenaWidth;
        }
        else if (transform.position.y >_halfArenaHeight)
        {
            verticalOffset = -2 * _halfArenaHeight;
        }
        else if (transform.position.y < -_halfArenaHeight)
        {
            verticalOffset = 2 * _halfArenaHeight;
        }

        if (horizontalOffset != 0 || verticalOffset != 0)
        {
            transform.position = transform.position + new Vector3(horizontalOffset, verticalOffset, 0);
        }
    }
}
