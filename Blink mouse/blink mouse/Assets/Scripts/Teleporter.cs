using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public bool cantTeleport;
    public Transform target;
    private Transform pivot;

    void Start()
    {
     
         pivot = new GameObject("Teleport location").transform;
        transform.parent = pivot;
    }

    void Update()
    {
        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;

        pivot.position = target.position;
        pivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
      cantTeleport  = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out");
        cantTeleport = false;
    }
}