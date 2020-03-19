using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChecker : MonoBehaviour
{
    bool isCollidingWall = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        isCollidingWall = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isCollidingWall = false;
    }

    public bool IsCollidingWall()
    {
        return isCollidingWall;
    }
}
