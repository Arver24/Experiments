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
    Color startCol=new Color(1,1,1);
    Color sortCol = new Color(0, 0.5f, 0, 0.25f);
    public GameObject transition;
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

    private void Update()
    {
        
    }
    IEnumerator Sorter(float[] inputs)
    {
        
        while (!sort.isSorted())
        {
            sort.Sorter(inputs);
            for (int i = 0; i < lines.Length; i++)
            {
                /*float pos = lines[i].GetComponent<LineRenderer>().GetPosition(0).x;*/

                lines[i].GetComponent<LineRenderer>().SetPosition(1, new Vector3(initialpos + (i * 0.25f), inputs[i]));
                lines[i].GetComponent<LineRenderer>().startColor = sortCol;
                lines[i].GetComponent<LineRenderer>().endColor = sortCol;
                yield return new WaitForSeconds(0.01f);
                lines[i].GetComponent<LineRenderer>().startColor = startCol;
                lines[i].GetComponent<LineRenderer>().endColor = startCol;
            }
        }
        transition.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(2);
        
    }
}
