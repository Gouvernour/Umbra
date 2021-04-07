using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject startpoint;
    public GameObject startClone;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;
    private float distance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Startpoint();
        }
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (ShadowStrength.instance.UseStrength(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1])))
            {
                endPoint(tempFingerPos);
                
            }
            else
                Destroy(startpoint);
        }
    }

    void Startpoint()
    {
        startpoint = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = startpoint.GetComponent<LineRenderer>();
        edgeCollider = startpoint.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
        
    }

    void endPoint(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
        if (startClone != null)
            Destroy(startClone, 1.5f);
        startClone = startpoint as GameObject;
        Destroy(startClone, 3f);
    }
}
