using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetPlayer;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    private Vector3 veolcity = Vector3.zero;
    public float smoothTime = 0.3f;
    // Update is called once per frame
    void LateUpdate()
    {
        targetedPosition = targetPlayer.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref veolcity, smoothTime);
    }
}
