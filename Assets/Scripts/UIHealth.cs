using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI title;

    [SerializeField]
    public Slider slider;

    [SerializeField]
    public HealthController healthManager;

    [SerializeField]
    float health;

    // Start is called before the first frame update
    void Awake()
    {
        //slider.minValue = 0;
        //slider.maxValue = 1;

        if (healthManager) {
            healthManager.HealthValueChanged += OnHealthChanged;
        }
    }

    void OnHealthChanged(int newHealthValue, int newMaxHealthValue)
    {
        health = (float)newHealthValue / (float)newMaxHealthValue;
        slider.value = health;
        title.text = $"Health {newHealthValue}/{newMaxHealthValue}";
    }
}
