using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float lookSensitivity = 3;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Callculate movement velocity as a 3d vector
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        //final movement vector
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);

        //Calculate rotation : turning around
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation : turning around
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        //Apply rotation
        motor.RotateCamera(_cameraRotation);

    }
}
