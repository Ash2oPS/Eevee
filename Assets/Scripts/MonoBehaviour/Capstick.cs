using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capstick : MonoBehaviour
{
    [SerializeField]
    private CapstickTrail _trail;

    [SerializeField]
    private SpriteRenderer _capstickSR;

    private LineRenderer _trailLineRenderer;

    private List<Vector2> _pointsTrailLineRenderer;

    [SerializeField]
    private float _distanceFromPoints;

    [SerializeField]
    private int _trailPointsLimit;

    private void Awake()
    {
        _trailLineRenderer = _trail.GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _pointsTrailLineRenderer = new List<Vector2>();
    }

    public void CheckDistanceFromLastPoint()
    {
        if (_trailLineRenderer.positionCount == 0)
        {
            SetCapstickOpacity(1);

            _trail.SetColliderEnable(_trail.GetComponent<EdgeCollider2D>(), true);

            AddPointEdgeCollider(0);

            return;
        }

        if (Vector2.Distance(transform.position, _trailLineRenderer.GetPosition(_trailLineRenderer.positionCount - 1)) >= _distanceFromPoints)
        {
            AddPointEdgeCollider(_trailLineRenderer.positionCount);
        }
    }

    private void AddPointEdgeCollider(int index)
    {
        _pointsTrailLineRenderer.Add(new Vector2(transform.position.x, transform.position.y));

        _trailLineRenderer.positionCount = _pointsTrailLineRenderer.Count;
        _trailLineRenderer.SetPosition(index, _pointsTrailLineRenderer[index]);

        _trail.UpdateTrailCollider(_pointsTrailLineRenderer);

        if (_pointsTrailLineRenderer.Count >= _trailPointsLimit)
        {
            RemoveFirstTrailPoint();
            Debug.Log("index :" + index + " - _pointsTrailLineRenderer.Count :" + _pointsTrailLineRenderer.Count);
        }
    }

    private void RemoveFirstTrailPoint()
    {
        for (int i = _pointsTrailLineRenderer.Count; i >= _trailPointsLimit - 1; i--)
        {
            _pointsTrailLineRenderer.RemoveAt(0);
        }

        Vector3[] array = new Vector3[_pointsTrailLineRenderer.Count];

        for (int i = 0; i < _pointsTrailLineRenderer.Count; i++)
        {
            array[i] = _pointsTrailLineRenderer[i];
        }

        _trailLineRenderer.SetPositions(array);
    }

    public void ReleaseCapstick()
    {
        _trailLineRenderer.positionCount = 0;

        _pointsTrailLineRenderer.Clear();

        _trail.RemoveTrailCollider();

        SetCapstickOpacity(0);
    }

    private void SetCapstickOpacity(float value)
    {
        _capstickSR.color = new Vector4(1, 1, 1, value);
    }
}