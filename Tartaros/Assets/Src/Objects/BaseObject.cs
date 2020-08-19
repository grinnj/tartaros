using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    //
    // Config
    //

    protected bool StopsProjectiles;
    protected bool StopsMovement;

    //
    // Interface
    //

    public Vector2 GetPosition()
    {
        return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    public bool StopsProjectilesMove()
    {
        return StopsProjectiles;
    }

    public bool StopsPlayerMove()
    {
        return StopsMovement;
    }
}
