using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    bool linear = false;

    [SerializeField]
    bool parabola = false;

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            if (linear) {
                // Linear = Y equals X
                position.y = position.x;
            }

            if (parabola) {
                // Parabola = Y equals X²
                position.y = position.x * position.x;
            }
            
            point.localPosition = position;
            point.localScale = scale;

            point.SetParent(transform, false);
        }
    }
}
