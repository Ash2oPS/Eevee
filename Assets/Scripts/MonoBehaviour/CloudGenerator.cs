using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public Cloud CloudPrefab;
    public Sprite[] Sprites;
    public int MinClouds, MaxClouds;
    public float MinX, MaxX, MinY, MaxY;

    private void Start()
    {
        if (MinClouds > MaxClouds || MinX > MaxX || MinY > MaxY)
        {
            Debug.LogWarning("Min et Max incorrects. Les nuages n'ont pas spawné");
            return;
        }

        int nombreDeNuages = Random.Range(MinClouds, MaxClouds + 1);

        for (int i = 0; i < nombreDeNuages; i++)
        {
            float x, y;
            x = Random.Range(MinX, MaxX);
            y = Random.Range(MinY, MaxY);
            SpawnCloud(new Vector3(x, y, 0));
        }
    }

    private void SpawnCloud(Vector3 pos)
    {
        Cloud cloud = Instantiate(CloudPrefab, transform);
        transform.localPosition = pos;
        cloud.Sr.sprite = SpritePicker();
        cloud.Sr.sortingOrder = Random.Range(-35, -7);

        cloud.OnCreated();
    }

    private Sprite SpritePicker()
    {
        return Sprites[Random.Range(0, Sprites.Length)];
    }
}