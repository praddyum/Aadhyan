using UnityEngine;

[ExecuteInEditMode]
public class FaceCamera : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    Vector3 targetAngle = Vector3.zero;
    [SerializeField]
    float InitX, InitY;
    private void Update()
    {
        transform.LookAt(cam);
        targetAngle = transform.localEulerAngles;
        targetAngle.x = InitX;
        targetAngle.z = InitY;
        transform.localEulerAngles = targetAngle;
    }
}
