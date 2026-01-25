using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 3.0f;
    [SerializeField] float _mouseSpeed = 0.3f;
    [SerializeField] float _mouseSteps = 5;
    [SerializeField] float _mouseAngle = 30;

    Vector3 _rotation;


    InputSystem_Actions action;
    Vector2 _lastMousePosition;

    void Start()
    {
        action = new InputSystem_Actions();
        action.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 movement = action.Player.Move.ReadValue<Vector2>();
        movement = movement.Rotate(-transform.localEulerAngles.y);
        transform.position = transform.position +  new Vector3(movement.x, 0, movement.y) * Time.deltaTime * _moveSpeed;


        _rotation += new Vector3(-Mouse.current.delta.value.y,         Mouse.current.delta.value.x, 0) * _mouseSpeed;
        _rotation = new Vector3(Mathf.Clamp(_rotation.x , - _mouseAngle, _mouseAngle), _rotation.y, 0);
        transform.localEulerAngles = new Vector3(Mathf.Floor(_rotation.x / _mouseSteps) * _mouseSteps, Mathf.Floor(_rotation.y / _mouseSteps) * _mouseSteps, Mathf.Floor(_rotation.z / _mouseSteps) * _mouseSteps);
        _lastMousePosition = Mouse.current.position.value;

    }
}
