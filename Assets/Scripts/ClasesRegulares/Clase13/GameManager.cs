using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int m_points;

    private HarryController m_harryController;


    public HarryController GetHarryController()
    {
        return m_harryController;
    }

    public void SetHarryController(HarryController p_harryController)
    {
        m_harryController = p_harryController;
    }

    private void Awake()
    {
        if (instance != null)
        {
            //Ya existe un GameManager
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    public void AddPoints(int p_newPointsToAdd)
    {
        m_points += p_newPointsToAdd;
    }

    public int GetTotalPoints()
    {
        return m_points;
    }
}