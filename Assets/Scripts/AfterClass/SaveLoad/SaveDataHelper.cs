using UnityEngine;

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