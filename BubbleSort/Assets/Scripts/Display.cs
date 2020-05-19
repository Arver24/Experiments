using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer lineRenderer;
    GameObject[] lines;
    Vector3[] points = new Vector3[2];
    float initialpos = -8.55f;
    Sort sort;
    float[] heights;
    Color startCol=new Color(66f / 256f,111f / 256f, 166f / 256f, 150f / 256f);
    void Start()
    {
        sort = new Sort();
        lines = new GameObject[70];
        heights = new float[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = new GameObject("line" + i);
            lineRenderer = lines[i].AddComponent<LineRenderer>();
            lineRenderer.sharedMaterial = new Material(Shader.Find("Sprites/Default"));
            points[0] = new Vector3(initialpos + (i * 0.25f), -5f);
            points[1]= new Vector3(initialpos + (i *0.25f), UnityEngine.Random.Range(-4f,5f));
            heights[i] = points[1].y;
            lineRenderer.startWidth = 0.25f;
            lineRenderer.startColor = startCol;
            lineRenderer.endColor = startCol;
            lineRenderer.endWidth = 0.25f;
            lineRenderer.SetPositions(points);

        }
        StartCoroutine(Sorter(heights));
    }

    // Update is called once per frame
    

    IEnumerator Sorter(float[] inputs)
    {
        
        sort.Sorter(inputs);
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].GetComponent<LineRenderer>().SetPosition(1,new Vector3(initialpos + (i * 0.25f),inputs[i]));
            yield return new WaitForSeconds(0.04f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
        
    }
}
