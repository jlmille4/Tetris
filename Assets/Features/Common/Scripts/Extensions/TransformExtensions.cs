using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    public static void SetX(this Transform transform, float x, Space space)
    {
        Vector3 position;
        switch(space)
        {
            case Space.World:
                position = transform.position;
                position.x = x;
                transform.position = position;
                break;
            case Space.Self:
                position = transform.localPosition;
                position.x = x;
                transform.localPosition = position;
                break;
        }
    }

    public static void SetY(this Transform transform, float y, Space space)
    {
        Vector3 position;
        switch (space)
        {
            case Space.World:
                position = transform.position;
                position.y = y;
                transform.position = position;
                break;
            case Space.Self:
                position = transform.localPosition;
                position.y = y;
                transform.localPosition = position;
                break;
        }
    }

    public static void SetZ(this Transform transform, float z, Space space)
    {
        Vector3 position;
        switch (space)
        {
            case Space.World:
                position = transform.position;
                position.z = z;
                transform.position = position;
                break;
            case Space.Self:
                position = transform.localPosition;
                position.z = z;
                transform.localPosition = position;
                break;
        }
    }
}
