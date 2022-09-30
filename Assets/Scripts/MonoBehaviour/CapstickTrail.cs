using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapstickTrail : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private LineRenderer _lr;

    [SerializeField]
    private EdgeCollider2D _edgeCollider;

    [SerializeField]
    private PolygonCollider2D _polygonCollider;

    private List<Vector2> _edgeColliderPoints, _polygonColliderPoints;

    #endregion PrivateVariables

    private void Start()
    {
        _edgeColliderPoints = new List<Vector2>();
        _polygonColliderPoints = new List<Vector2>();
    }

    public void SetColliderEnable(Collider2D col, bool value)
    {
        col.enabled = value;
    }

    public void UpdateTrailCollider(List<Vector2> positions)
    {
        _edgeCollider.SetPoints(positions);
    }

    public void RemoveTrailCollider()
    {
        _edgeColliderPoints.Clear();

        SetColliderEnable(_edgeCollider, false);
    }

    private void CreateLoopCollider()
    {
        List<Vector2> newList = new List<Vector2>();

        for (int i = 0; i < _lr.positionCount; i++)
        {
            newList.Add(_lr.GetPosition(i));
        }

        _polygonCollider.SetPath(0, newList);
    }

    private void RemoveLoopCollider()
    {
        _polygonCollider.SetPath(0, new List<Vector2>());
    }

    private void DetectCapstickableInLoop()
    {
        if (_polygonCollider.GetPath(0).Length <= 1)
        {
            return;
        }

        ContactFilter2D cf = new ContactFilter2D();
        List<Collider2D> newList = new List<Collider2D>();

        _polygonCollider.OverlapCollider(cf, newList);

        List<Collider2D> newTrueList = new List<Collider2D>();

        foreach (Collider2D col in newList)
        {
            if (col.TryGetComponent<Capstickable>(out Capstickable c))
            {
                newTrueList.Add(col);
            }
        }

        if (newTrueList.Count > 0)
        {
            Debug.Log(newTrueList[0]);
        }
    }
}