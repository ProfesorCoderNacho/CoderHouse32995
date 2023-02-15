using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class SaveKeys
{
    public static string REMAINING_HEALTH_KEY = "TotalHealth";
    public static string X_POSITION_KEY = "XPosition";
    public static string Y_POSITION_KEY = "YPosition";
    public static string Z_POSITION_KEY = "ZPosition";
    public static string CAN_SPRINT_KEY = "CanSprint";
    public static string CHARACTER_NAME_KEY = "CharacterName";
    public static string POSITION_KEY = "CharacterPosition";
}

public static class SaveDataHelper
{
    public static void SaveBool(bool p_boolState, string p_key)
    {
        PlayerPrefs.SetInt(p_key, p_boolState ? 1 : 0);
    }

    public static bool GetBool(string p_key, bool p_defaultValue)
    {
        var l_value = PlayerPrefs.GetInt(p_key, p_defaultValue ? 1 : 0);
        return l_value != 0;
    }

    public static void SaveVector3(string p_key, Vector3 p_vector)
    {
        var l_xKey = p_key + "x";
        var l_yKey = p_key + "y";
        var l_zKey = p_key + "z";

        PlayerPrefs.SetFloat(l_xKey, p_vector.x);
        PlayerPrefs.SetFloat(l_yKey, p_vector.y);
        PlayerPrefs.SetFloat(l_zKey, p_vector.z);
    }

    public static Vector3 GetVector3(string p_key, Vector3 p_defaultVector)
    {
        var l_xKey = p_key + "x";
        var l_yKey = p_key + "y";
        var l_zKey = p_key + "z";

        var l_x = PlayerPrefs.GetFloat(l_xKey, p_defaultVector.x);
        var l_y = PlayerPrefs.GetFloat(l_yKey, p_defaultVector.y);
        var l_z = PlayerPrefs.GetFloat(l_zKey, p_defaultVector.z);

        return new Vector3(l_x, l_y, l_z);
    }

    public static string SaveDataName = "/SaveData.json";
}

//
// public class SaveData
// {
//     public Vector3 LastCharacterPosition;
//     public bool CanSprint;
//     public float Health;
//     public string CharacterName;
// }

[Serializable]
public struct LevelSaveData
{
    public int LastLevel;
    public int LastWorld;
}

[Serializable]
public struct SkinData
{
    public string NameID;
    public Material MaterialToApply;
}

[Serializable]
public struct SavedSkinData
{
    public List<SkinData> AcquiredSkinsList;
}

[Serializable]
public struct SaveDataArray
{
    public List<SaveData> SaveSlots;
}

[Serializable]
public struct SaveData
{
    public Vector3 LastCharacterPosition;
    public bool CanSprint;
    public float Health;
    public string CharacterName;
    public List<SuperPower> Superpowers;
    public LevelSaveData LevelSaveData;
}

[Serializable]
public struct SuperPower
{
    public string SuperPowerName;
    public float SuperPowerStrength;
    public bool SuperPowerActivated;
}

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
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.Confined : CursorLockMode.None;
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