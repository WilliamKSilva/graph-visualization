using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    bool sineWave = false;

    [SerializeField]
    bool multiWave = false;

    [SerializeField]
    bool ripple = false;

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
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 position = points[i].localPosition;
            if (sineWave)
            {
                position.y = FunctionLibrary.Wave(position.x, time);
            }

            if (multiWave)
            {
                position.y = FunctionLibrary.MultiWave(position.x, time);
            }

            if (ripple)
            {
                position.y = FunctionLibrary.Ripple(position.x, time);
            }

            points[i].localPosition = position;
        }
    }
}
