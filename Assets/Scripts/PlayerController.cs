using UnityEngine;

public class PlayerController : MonoBehaviour
{

    InputSystem_Actions action;

    void Start()
    {
        action = new InputSystem_Actions();
        action.Player.Enable();
    }

    void Update()
    {
        Vector2 movement = action.Player.Move.ReadValue<Vector2>();
        transform.position = transform.position +  new Vector3(movement.x, 0, movement.y) * Time.deltaTime;
    }
}
