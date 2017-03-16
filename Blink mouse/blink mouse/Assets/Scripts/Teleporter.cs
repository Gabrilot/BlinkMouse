using UnityEngine;
using System.Collections;

public class Teleporter : RaycastController
{
    public LayerMask TeleportnMask;
    float lockPos = 0;
    public bool cantTeleportX;
    public bool cantTeleportY;
    public Transform target;
    private Transform pivot;
    

   public override void Start()
    {
        base.Start();
        GetComponent<SpriteRenderer>().enabled = false;
        pivot = new GameObject("Teleport location").transform;
        pivot.transform.position = GameObject.Find("Soric").transform.position;
        transform.parent = pivot;
        
    }

    void FixedUpdate()
    {
        cantTeleportY = false;
        cantTeleportX = false;
        UpdateRaycastOrigins();
        
        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
      
        pivot.position = target.position;
        pivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        CheckColision(v3Pos);


    }


    void CheckColision(Vector3 v3Pos)
    {
        float directionX = Mathf.Sign(v3Pos.x);
        float directionY = Mathf.Sign(v3Pos.y);
        
        //
        if (v3Pos.y != 0)
        {
            float rayLength = Mathf.Abs(v3Pos.y) + skinWidth;
            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, TeleportnMask);
                Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);
                if (hit)
                {
                    if (hit.distance == 0)
                    {
                        cantTeleportY = true;
                        Debug.Log("Hit y");

                    }
                }
            }
        }
        //
        if (v3Pos.x != 0)
        {
            float rayLength = Mathf.Abs(v3Pos.x) + skinWidth;

                for (int i = 0; i < horizontalRayCount; i++)
                {
                    Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                    rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, TeleportnMask);
                    Debug.DrawRay(rayOrigin, Vector2.right * directionX, Color.red);

                    if (hit)
                    {
                        if (hit.distance == 0)
                        {
                        cantTeleportX = true;
                        Debug.Log("Hit x");

                        }
                    }
                }
            }
        }
   
}