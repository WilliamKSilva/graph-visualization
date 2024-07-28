using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    FunctionLibrary.FunctionName function;

    Transform[] points;

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            points[i] = point;
            position.x = (i + 0.5f) * step - 1f;

            point.localPosition = position;
            point.localScale = scale;

            point.SetParent(transform, false);
        }
    }

    void Update()
    {
        float time = Time.time;
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 position = points[i].localPosition;
            position.y = f(position.x, time);

            points[i].localPosition = position;
        }
    }
}
