using JetBrains.Annotations;
using Unity.Cinemachine;
using UnityEngine;
public class CameraScroll : MonoBehaviour
{

    public CinemachineCamera cinCamera;
    public float zoomMult = 10f;
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public float velocity = 0f;
    public float smoothTime = 0.25f;
    public float zoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoom = cinCamera.Lens.OrthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = UnityEngine.Input.GetAxis("Mouse ScrollWheel");

        zoom -= scrollInput * zoomMult;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        //cinCamera.Lens.OrthographicSize = zoom;
        cinCamera.Lens.OrthographicSize = Mathf.SmoothDamp(cinCamera.Lens.OrthographicSize, zoom, ref velocity, smoothTime);
    }

    public void Scroll()
    {

    }
}
