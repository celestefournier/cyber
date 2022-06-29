using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail : MonoBehaviour
{
    [SerializeField] bool emit = true;
    [SerializeField] float lifeTime = 1;
    [SerializeField] Transform tip;
    [SerializeField] Transform _base;

    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;
    bool lastFrameEnabled;
    float swordSize;

    void Start()
    {
        lastFrameEnabled = emit;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new List<Vector3>() { _base.position, tip.position };
        triangles = new List<int>();
        swordSize = Vector3.Distance(_base.position, tip.position);
    }

    void Update()
    {
        if (!emit)
        {
            lastFrameEnabled = false;
            return;
        }

        vertices.Add(_base.position);
        vertices.Add(tip.position);

        if (vertices.Count <= 2)
            return;

        if (!lastFrameEnabled)
        {
            lastFrameEnabled = true;
        }
        else
        {
            triangles.Add(vertices.Count - 1);
            triangles.Add(vertices.Count - 2);
            triangles.Add(vertices.Count - 3);

            triangles.Add(vertices.Count - 2);
            triangles.Add(vertices.Count - 4);
            triangles.Add(vertices.Count - 3);
        }

        UpdateMesh();
        StartCoroutine("WaitForRemoveTrail");

        ResetPosition();
    }

    void ResetPosition()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
    }

    IEnumerator WaitForRemoveTrail()
    {
        yield return new WaitForSeconds(lifeTime);

        vertices.RemoveRange(0, 2);

        if (triangles.Count >= 6)
            triangles.RemoveRange(0, 6);

        for (int i = 0; i < triangles.Count; i++)
        {
            triangles[i] -= 2;
        }

        UpdateMesh();
    }

    // void AnimateTrail()
    // {
    //     var distance = (Time.deltaTime / lifeTime) * (swordSize / 2);

    //     for (int i = 0; i < vertices.Count; i += 2)
    //     {
    //         vertices[i] += (vertices[i + 1] - vertices[i]).normalized * distance;
    //         vertices[i + 1] += (vertices[i] - vertices[i + 1]).normalized * distance;
    //     }
    // }
}
