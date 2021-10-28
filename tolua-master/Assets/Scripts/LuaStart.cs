using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaStart : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitLua()
    {
        GameObject go = new GameObject("LuaClient");
        go.AddComponent<LuaClient>();
        DontDestroyOnLoad(go);
        go.AddComponent<Tools>();
        var util = new CustomLuaFileUtil();
    }

}
