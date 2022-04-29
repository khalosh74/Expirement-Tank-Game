using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    [SerializeField] private List<MeshFilter> sourceMeshFilter;
    [SerializeField] private MeshFilter targetMeshFilter;
    [ContextMenu("Combine Meshes")]
    private void CombineMeshes()
    {
        var combine = new CombineInstance[sourceMeshFilter.Count];

        for(var i=0; i<sourceMeshFilter.Count; i++)
        {
            combine[i].mesh = sourceMeshFilter[i].sharedMesh;
            combine[i].transform = sourceMeshFilter[i].transform.localToWorldMatrix;
        }
        var mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.CombineMeshes(combine);
        targetMeshFilter.mesh = mesh;

    }
}
