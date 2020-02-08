using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _HorizontalAxis = 0;
    private float _VerticalAxis = 0;

    private InputManager _IM;
    private Rigidbody _RB;

    private void Awake()
    {
        _IM = GetComponent<InputManager>();
        _RB = GetComponent<Rigidbody>();
    }

    public void Move(float speed, float maxSpeed)
    {
        _HorizontalAxis = _IM._P_HorizontalAxis;
        _VerticalAxis = _IM._P_VerticalAxis;

        _RB.velocity = Vector3.ClampMagnitude(_RB.velocity, maxSpeed);
        _RB.AddForce(new Vector3(_HorizontalAxis * speed, 0, _VerticalAxis * speed));
    }
}
