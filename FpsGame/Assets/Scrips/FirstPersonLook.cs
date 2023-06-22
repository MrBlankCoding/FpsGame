using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2f;
    public float smoothing = 1.5f;
    public float minimumVerticalAngle = -90f;
    public float maximumVerticalAngle = 90f;

    private Vector2 velocity;
    private Vector2 frameVelocity;

    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1f / smoothing);
        velocity += frameVelocity;

        // Limit vertical rotation
        velocity.y = Mathf.Clamp(velocity.y, minimumVerticalAngle, maximumVerticalAngle);

        transform.localRotation = Quaternion.Euler(-velocity.y, 0f, 0f);
        character.localRotation = Quaternion.Euler(0f, velocity.x, 0f);
    }
}
