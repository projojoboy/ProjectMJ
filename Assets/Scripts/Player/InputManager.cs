using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Axis Values
    [Header("Debug Axis Values")]
    [SerializeField] private float _HorizontalAxis;
    [SerializeField] private float _VerticalAxis;

    [SerializeField] private KeyCode _SprintingButton = KeyCode.LeftShift;

    //Public Axis values for calling
    public float _P_HorizontalAxis { get { return _HorizontalAxis; } }
    public float _P_VerticalAxis { get { return _VerticalAxis; } }

    public KeyCode _P_SprintingButton { get { return _SprintingButton; } }

    private void Update()
    {
        UpdateAxisValues();
    }

    private void UpdateAxisValues()
    {
        _HorizontalAxis = Input.GetAxis("Horizontal");
        _VerticalAxis = Input.GetAxis("Vertical");
    }

    private void UpdateButtonValues()
    {

    }
}
