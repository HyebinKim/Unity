using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wave : MonoBehaviour {

    public double w = 1.0;
    public double h = 0.3;

    private Vector3[] baseHeight;
    Mesh mesh;
    Vector3[] vertices;

    public Text w_text;

        

    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;
        vertices = new Vector3[baseHeight.Length];
        SetText();
    }
   

    // Update is called once per frame
    void Update () {

        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin(Time.time * (float)w + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z)* (float)h;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            h = h + 0.02;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (h  > 0.02)
            {
                h = h - 0.02;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (w > 0.05)
            {
                w = w - 0.05;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            w = w + 0.05;
        }

        SetText();
    }

    void SetText()
    {
        float ww = (float)w;
        float hh = (float)h;
        w_text.text = "w: " + ww.ToString()+",h: " + hh.ToString();
        w_text.text = "ver2";
    }
}
