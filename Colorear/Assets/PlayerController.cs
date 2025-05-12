using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controls.IPlayerActions {
    public float speed = 5f;
    private Controls input;
    private Vector2 dir;

    void Awake() {
        input = new Controls();
        input.Player.SetCallbacks(this);    // conecta la interfaz
    }
    void OnEnable()  => input.Enable();
    void OnDisable() => input.Disable();

    // esto te lee el Vector2 de W/A/S/D
    public void OnMovement(InputAction.CallbackContext ctx) {
        dir = ctx.ReadValue<Vector2>();
    }

    void Update() {
        Vector3 m = new Vector3(dir.x, 0, dir.y) * speed * Time.deltaTime;
        transform.Translate(m, Space.World);
    }
}

