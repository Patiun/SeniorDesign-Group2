using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ViewCastInfo
{
    public bool hit;
    public Vector3 point;
    public float dst;
    public float angle;

    public ViewCastInfo(bool hit, Vector3 point, float dst, float angle)
    {
        this.hit = hit;
        this.point = point;
        this.dst = dst;
        this.angle = angle;
    }
}

public class FieldOfView : MonoBehaviour {

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    public float meshResolution;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    private void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = "view Mesh";
        viewMeshFilter.mesh = viewMesh;
        //StartCoroutine(FindTargetWithDelay(.2f)); //use this to execute if agent is in FOV
    }
    //private void FindVisibleTarget()
    //{
    //    visibleTargets.Clear();
    //    Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

    //    foreach(Collider target in targetInViewRadius)
    //    {
    //        Transform t = target.transform;
    //        Vector3 dirToTarget = (t.position - transform.position).normalized;
    //        if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle /2)
    //        {
    //            float dstToTarget = Vector3.Distance(transform.position, t.position);

    //            if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
    //            {
    //                visibleTargets.Add(t);
                      //do what you must here to destroy the agent.
    //            }
    //        }
    //    }
    //}

    //IEnumerator FindTargetWithDelay(float delay)
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(delay);
    //        FindVisibleTarget();
    //    }
    //}

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for(int i =0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle/2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
            //Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle, true) * viewRadius, Color.red);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] verticies = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        verticies[0] = Vector3.zero;
        for(int i = 0; i <vertexCount -1; i++)
        {
            verticies[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
            if(i < vertexCount -2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }

            viewMesh.Clear();
            viewMesh.vertices = verticies;
            viewMesh.triangles = triangles;
            viewMesh.RecalculateNormals();
            
        }
    }

    private ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
    }

    private void LateUpdate()
    {
        DrawFieldOfView();
    }
}
