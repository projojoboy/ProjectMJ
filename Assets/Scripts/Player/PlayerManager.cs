using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(StaminaManager))]
public class PlayerManager : MonoBehaviour
{
    private PlayerController _PC;
    private InputManager _IM;
    private StaminaManager _SM;

    [Header("Movement Settings")]
    [SerializeField] private float _WalkingSpeed = 0;
    [SerializeField] private float _RunningSpeed = 0;
    [SerializeField] private float _MaxWalkingSpeed = 0;
    [SerializeField] private float _MaxRunningSpeed = 0;

    [Header("Stamina Settings")]
    [Tooltip("Stamina gain per second")]
    [SerializeField] private float _StaminaRegenerationValue = 0;
    [SerializeField] private float _MaxStamina = 0;
    [SerializeField] private float _SprintingStaminaDrain = 0;

    private void Awake()
    {
        _PC = GetComponent<PlayerController>();
        _IM = GetComponent<InputManager>();
        _SM = GetComponent<StaminaManager>();
    }

    private void Update()
    {
        if(_SM.CurrentStamina < _MaxStamina)
            _SM.RegenerateStamina(_StaminaRegenerationValue);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(_IM._P_SprintingButton) && _SM.CurrentStamina > 0)
        {
            _PC.Move(_RunningSpeed, _MaxRunningSpeed);

            if(_IM._P_VerticalAxis != 0 || _IM._P_HorizontalAxis != 0)
                _SM.StaminaController(false, _SprintingStaminaDrain * Time.deltaTime);
        }
        else
        {
            _PC.Move(_WalkingSpeed, _MaxWalkingSpeed);
        }
    }

    public float GetMaxStamina() { return _MaxStamina; }
    public float GetStaminaRegenerationSpeed() { return _StaminaRegenerationValue; }
}
