using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class LinkController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_maxHealth;
    [SerializeField] private float m_currentHealth;
    [SerializeField] private bool m_canSprint;
    [SerializeField] private string m_characterName;
    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");


    private void OnApplicationFocus(bool hasFocus)
    {
        //     Cursor.visible = !hasFocus;
        //   Cursor.lockState = hasFocus ? CursorLockMode.Confined : CursorLockMode.None;
    }

    [ContextMenu("Test receive damage")]
    private void ReceiveDamage()
    {
        m_currentHealth -= 1;
    }

    private void Awake()
    {
        m_currentHealth = m_maxHealth;
    }

    private void SaveData()
    {
        //Save data
        PlayerPrefs.SetFloat(SaveKeys.REMAINING_HEALTH_KEY, m_currentHealth);
        SaveDataHelper.SaveVector3(SaveKeys.POSITION_KEY, transform.position);
        SaveDataHelper.SaveBool(m_canSprint, SaveKeys.CAN_SPRINT_KEY);
        PlayerPrefs.SetString(SaveKeys.CHARACTER_NAME_KEY, m_characterName);
    }

    private void LoadData()
    {
        //Load data
        m_currentHealth = PlayerPrefs.GetFloat(SaveKeys.REMAINING_HEALTH_KEY, m_maxHealth);
        transform.position = SaveDataHelper.GetVector3(SaveKeys.POSITION_KEY, transform.position);
        m_canSprint = SaveDataHelper.GetBool(SaveKeys.CAN_SPRINT_KEY, false);
        m_characterName = PlayerPrefs.GetString(SaveKeys.CHARACTER_NAME_KEY, string.Empty);
    }

    private void LoadDataJSON()
    {
        var l_saveDataJson = File.ReadAllText(Application.dataPath + SaveDataHelper.SaveDataName);
        var l_saveData = JsonUtility.FromJson<SaveData>(l_saveDataJson);

        m_characterName = l_saveData.CharacterName;
        m_currentHealth = l_saveData.Health;
        m_canSprint = l_saveData.CanSprint;
        transform.position = l_saveData.LastCharacterPosition;
        Debug.Log("Data loaded");
    }

    public void PrintMyName()
    {
        Debug.Log(m_characterName);
    }

    private void SaveDataJSON()
    {
        var l_newSaveData = new SaveData();
        l_newSaveData.Health = m_currentHealth;
        l_newSaveData.CanSprint = m_canSprint;
        l_newSaveData.CharacterName = m_characterName;
        l_newSaveData.LastCharacterPosition = transform.position;
        var l_superpowersList = new List<SuperPower>();
        l_superpowersList.Add(new SuperPower()
        {
            SuperPowerName = "Nombre1",
            SuperPowerActivated = true,
            SuperPowerStrength = 10
        });

        l_superpowersList.Add(new SuperPower()
        {
            SuperPowerName = "Nombre2",
            SuperPowerActivated = false,
            SuperPowerStrength = 43f
        });
        l_newSaveData.Superpowers = l_superpowersList;

        var stringjson = JsonUtility.ToJson(l_newSaveData);
        File.WriteAllText(Application.dataPath + SaveDataHelper.SaveDataName, stringjson);
        print("Saving");
    }

    private void Update()
    {
        Move(GetMoveVector());
        RotateCharacter(GetRotationAmount());

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveDataJSON();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadDataJSON();
        }
    }


    private void Move(Vector3 moveDir)
    {
        var transform1 = transform;
        var l_speedMultiplier = m_canSprint ? 2 : 1;
        transform1.position +=
            (moveDir.x * transform1.right + moveDir.z * transform1.forward) *
            (speed * Time.deltaTime * l_speedMultiplier);
        m_animator.SetFloat(MoveSpeed, moveDir.magnitude * speed);
    }

    private void RotateCharacter(float rotateAmount)
    {
        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime * rotationSpeed, Space.Self);
    }

    private float GetRotationAmount()
    {
        return Input.GetAxis("Mouse X");
    }

    private Vector3 GetMoveVector()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");

        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }
}