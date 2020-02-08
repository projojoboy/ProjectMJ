using UnityEngine;
using TMPro;

public class StaminaManager : MonoBehaviour
{
    private float _MaxStamina;
    private float _Timer;
    private float _TimerTime = 1;

    private bool _IsUsingStamina = false;

    public float CurrentStamina { get; private set; }

    [SerializeField] private TextMeshProUGUI STAMINADEBUG = null;

    private void Start()
    {
        _Timer = _TimerTime;

        _MaxStamina = GetComponent<PlayerManager>().GetMaxStamina();

        SetupDefaultValues();
    }

    private void Update()
    {
        if (_Timer > 0)
            _Timer -= Time.deltaTime;
        else
            _IsUsingStamina = false;

        STAMINADEBUG.text = CurrentStamina.ToString("f0");
    }

    public void StaminaController(bool add, float value)
    {
        if (add)
        {
            if (CurrentStamina + value <= _MaxStamina)
                CurrentStamina += value;
            else
                CurrentStamina = _MaxStamina;
        }
        else
        {
            CurrentStamina -= value;
            _IsUsingStamina = true;
            _Timer = _TimerTime;
        }
    }

    public void RegenerateStamina(float value)
    {
        if (_IsUsingStamina)
            return;

        StaminaController(true, value * Time.deltaTime);
    }

    private void SetupDefaultValues()
    {
        CurrentStamina = _MaxStamina;
    }
}
