using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class flipNormals : MonoBehaviour
{

    public Mesh mesh;
/*
    Color color;

    [MenuItem("Window/FlipNormals")]
    public static void ShowWindow()
    {
        GetWindow<flipNormals>("FlipNormals");
    }

    private void OnGUI()
    {
        GUILayout.Label("flipNormal", EditorStyles.boldLabel);

        mesh = (Mesh)EditorGUILayout.ObjectField(mesh, typeof(Mesh), true);

        if (GUILayout.Button("flipNormal"))
        {
            FlipNormals();
        }

    }

*/
    void Start()
    {
        Mesh mesh = this.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;

        Vector3[] normals = mesh.normals;
        for(int i = 0; i < normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }
        mesh.normals = normals;


        for(int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);
            for(int j = 0; j<tris.Length; j += 3)
            {
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }
            mesh.SetTriangles(tris, i);
        }
    }
}
