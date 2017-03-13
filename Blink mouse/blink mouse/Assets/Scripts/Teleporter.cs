using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public bool cantTeleport;
    public Transform target;
    private Transform pivot;
    private bool foReal;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        pivot = new GameObject("Teleport location").transform;
        pivot.transform.position = GameObject.Find("Soric").transform.position;
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
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Hit");
        cantTeleport = true;
        foReal = true;
  
    }
    void OnTriggerExit2D(Collider2D other)
    {
       
        Debug.Log("Out");
        cantTeleport = false;
       
    }
}