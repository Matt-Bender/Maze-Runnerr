using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject targetPlayer;
    private Rigidbody playerRB;

    [Header("Cam")]
    [SerializeField] private float smoothTime;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        playerRB = targetPlayer.GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = targetPlayer.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }


}
