using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public CompositeCollider2D mapCollider;
    new private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        float cameraHeight = camera.orthographicSize;
        float cameraWidth = cameraHeight * camera.aspect;

        float xMax = mapCollider.bounds.max.x - cameraWidth;
        float xMin = mapCollider.bounds.min.x + cameraWidth;
        float yMax = mapCollider.bounds.max.y - cameraHeight;
        float yMin = mapCollider.bounds.min.y + cameraHeight;

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, xMin, xMax);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, yMin, yMax);
        transform.position = cameraPosition;
    }
}
