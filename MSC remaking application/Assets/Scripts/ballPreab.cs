using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPreab : MonoBehaviour
{
    public float scanRadius = 3f;
    public LayerMask filterMask;
    private Overlap SP;
    private Collider2D checkCollider;
    void Awake()
    {
        SP = FindObjectOfType<Overlap>();
    }
    void Update()
    {
        checkCollider = Physics2D.OverlapCircle(transform.position, scanRadius,
            filterMask);
        if (checkCollider != null && checkCollider.transform != transform)
        {
            Destroy(checkCollider.gameObject);
            SP.CountD = 0;
        }
    }
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }

}
