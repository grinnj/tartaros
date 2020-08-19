using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<BaseObject> LevelObjects = new List<BaseObject>();
    private static Level Instance;

    Level()
    {
        //LevelObjects = new List<BaseObject>();
        Instance = this;
    }

    public static Level GetLevel()
    {
        return Instance;
    }

    public bool CanPass(Vector3 _Dir)
    {
        Player Player = Player.GetPlayer();
        foreach (BaseObject Object in LevelObjects)
        {
            Vector3 TargetBoundsCenter = _Dir + Player.gameObject.transform.position;
            Bounds TargetBounds = new Bounds(new Vector3(TargetBoundsCenter.x, TargetBoundsCenter.y, Object.gameObject.GetComponent<BoxCollider2D>().bounds.center.z),
                Player.gameObject.GetComponent<BoxCollider2D>().bounds.size);

            if (Object.StopsPlayerMove() &&
                Object.gameObject.GetComponent<BoxCollider2D>().bounds.Intersects(TargetBounds))
            {
                return false;
            }
        }

        return true;
    }

}
