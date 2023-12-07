using UnityEngine;

public class SwingScript : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 2.5f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        Vector3 newPosition = initialPosition + new Vector3(0f, 0f, offset);

        transform.position = newPosition;
    }
}
