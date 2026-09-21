using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Stuff")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _maxSpeed = 6f;
    [SerializeField] private float _friction = 2f;
    [SerializeField] private float _turnAroundSpeed = 3.5f;

    private PlayerInput _playerInput;
    private InputAction _move;

    [SerializeField] [ReadOnly] private Vector2 vel;
    
    void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("InputManager").GetComponent<PlayerInput>();
        _move = _playerInput.actions["Move"];
    }

    void Update()
    {
        Vector2 move = _move.ReadValue<Vector2>();

        vel += move * (_moveSpeed * Time.deltaTime);

        vel.x = Mathf.Clamp(vel.x, -_maxSpeed, _maxSpeed);
        vel.y = Mathf.Clamp(vel.y, -_maxSpeed, _maxSpeed);

        if (Mathf.Abs(move.x) <= 0.25)
        {
            if (vel.x > 0.01) vel.x -= _friction * Time.deltaTime;
            else if (vel.x < -0.01) vel.x += _friction * Time.deltaTime;
            else vel.x = 0;
        }

        if (Mathf.Abs(move.y) <= 0.25)
        {
            if (vel.y > 0.01) vel.y -= _friction * Time.deltaTime;
            else if (vel.y < -0.01) vel.y += _friction * Time.deltaTime;
            else vel.y = 0;
        }

        transform.position = (Vector2) transform.position + (vel * Time.deltaTime);
    }
}
