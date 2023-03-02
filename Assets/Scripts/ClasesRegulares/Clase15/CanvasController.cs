using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    // [SerializeField] private TMP_Text m_characterNameDisplay;
    // [SerializeField] private TMP_InputField m_inputField;


    [SerializeField] private float m_maxHealth;
    private float m_currentHealth;

    [SerializeField] private Button m_damageButton;
    [SerializeField] private Button m_healButton;
    [SerializeField] private Image m_healthMeter;
    [SerializeField] private Sprite m_healthySprite, m_damagedSprite;
    [SerializeField] private Toggle m_toggle;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private Slider m_volumeSlider;
    [SerializeField] private Slider m_pitchSlider;
    private LinkController m_linkController;

    private void Awake()
    {
        // m_inputField.onValueChanged.AddListener(OnValueChangedHandler);
        m_currentHealth = m_maxHealth;
        UpdateHealthBar(m_currentHealth);
        m_damageButton.onClick.AddListener(DamageButtonHandler);
        m_healButton.onClick.AddListener(HealButtonHandler);
        m_volumeSlider.onValueChanged.AddListener(ChangeVolume);
        m_pitchSlider.maxValue = 3;
        m_pitchSlider.minValue = -3;
        m_pitchSlider.onValueChanged.AddListener(ChangePitch);
    }

    private void Update()
    {
      
    }

    private void ChangePitch(float p_newPitch)
    {
        m_audioSource.pitch = p_newPitch;
    }

    private void ChangeVolume(float p_newVolume)
    {
        m_audioSource.volume = p_newVolume;
    }

    private void DamageButtonHandler()
    {
        m_currentHealth--;
        if (m_currentHealth < 0)
        {
            m_currentHealth = 0;
        }

        UpdateHealthBar(m_currentHealth);
    }

    private void HealButtonHandler()
    {
        m_currentHealth++;
        if (m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }

        UpdateHealthBar(m_currentHealth);
    }

    private void UpdateHealthBar(float p_currentHealth)
    {
        /*
         VERSION FEITA
        Sprite l_spriteToChange;
        
        if (m_currentHealth >= m_maxHealth / 2)
        {
            l_spriteToChange = m_healthySprite;
        }
        else
        {
            l_spriteToChange = m_damagedSprite;
        }

        m_healthMeter.sprite = l_spriteToChange;
        */
        var l_isHealthy = m_currentHealth >= m_maxHealth / 2;
        var l_currentHealthPercentage = m_currentHealth / m_maxHealth;
        m_healthMeter.sprite = l_isHealthy ? m_healthySprite : m_damagedSprite;
        var l_currColor = m_healthMeter.color;
        l_currColor.a = l_currentHealthPercentage;
        m_healthMeter.color = l_currColor;
    }

    private void OnValueChangedHandler(string p_newName)
    {
        // m_characterNameDisplay.text = p_newName;
        // m_characterNameDisplay.fontStyle = FontStyles.Bold;
        // m_characterNameDisplay.color = Color.blue;
    }

    public void UpdateCurrentHealth(float mCurrentHealth)
    {
    }
}