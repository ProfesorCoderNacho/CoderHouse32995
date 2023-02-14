using UnityEngine;

public class PointsGeneratorArea : MonoBehaviour
{
    [SerializeField] private int m_pointsToAdd;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoints(m_pointsToAdd);
        }
    }
}