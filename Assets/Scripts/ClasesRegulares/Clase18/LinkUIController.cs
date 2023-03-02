using System;
using ClasesRegulares.Clase18;
using TMPro;
using UnityEngine;

public class LinkUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text m_currentHealthText;
    [SerializeField] private TMP_Text m_enemiesKilled;
    [SerializeField] private TMP_Text m_totalScore;
    [SerializeField] private LinkController m_linkController;
    private float m_totalPoints;
    private int m_killedEnemies;

    private void Start()
    {
        var l_healthController = m_linkController.GetHealthController();
        l_healthController.OnHealthChange += UpdateHealthUI;
        l_healthController.OnHealthChange += UpdateSounds;
        m_linkController.OnLinkMoved.AddListener(UpdateVisualFaceRepresentationUI);
        // m_linkController.OnLinkMoved += UpdateVisualFaceRepresentationUI;

        TinyEnemy.OnEnemyDied += EnemiesKilledUpdate;
    }

    private void UpdateVisualFaceRepresentationUI(bool p_isMoving)
    {
        m_linkController.OnLinkMoved.RemoveListener(UpdateVisualFaceRepresentationUI);
        Debug.Log("Moved");
    }

    private void UpdateHealthUI(float p_currentHealth)
    {
        Debug.Log("Received OnHealthChange, from HealthController, to LinkUIController");
        m_currentHealthText.text = $"Health: {p_currentHealth}";
    }

    private void UpdateSounds(float p_currentHealth)
    {
        Debug.Log("Updating sounds");
    }


    private void EnemiesKilledUpdate(float p_pointsToAdd)
    {
        m_totalPoints += p_pointsToAdd;
        m_totalScore.text = m_totalPoints.ToString();
        m_killedEnemies++;
        m_enemiesKilled.text = $"Killed enemies {m_killedEnemies}";
    }
}