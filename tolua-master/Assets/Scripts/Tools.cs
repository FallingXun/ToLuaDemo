using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using UnityEngine.SceneManagement;

public class Tools : MonoBehaviour
{
    private int m_Width = 100;
    private int m_Height = 40;
    private int m_Space = 60;
    private int m_StartX = 10;
    private int m_StartY = 10;

    private int m_Memory = 0;
    private float m_Time = TimeStep;
    private const float TimeStep = 1f;

    private void OnGUI()
    {
        int i = 0;
        if (GUI.Button(new Rect(m_StartX, m_StartY + m_Space * i++, m_Width, m_Height), "Lua Memory"))
        {
            var count = LuaClient.GetMainState().LuaGC(LuaGCOptions.LUA_GCCOUNT);
            Debug.Log("Lua Memory = " + count);
        }
        else if (GUI.Button(new Rect(m_StartX, m_StartY + m_Space * i++, m_Width, m_Height), "Lua GC"))
        {
            LuaClient.GetMainState().LuaGC(LuaGCOptions.LUA_GCCOLLECT);
            Debug.Log("Call Lua GC");
        }
        else if (GUI.Button(new Rect(m_StartX, m_StartY + m_Space * i++, m_Width, m_Height), "C# GC"))
        {
            System.GC.Collect();
            Debug.Log("Call C# GC");
        }
        else if (GUI.Button(new Rect(m_StartX, m_StartY + m_Space * i++, m_Width, m_Height), "Load Scene"))
        {
            SceneManager.LoadSceneAsync("Empty");
            Debug.Log("Load Scene Empty");
        }
    }

    private void Update()
    {
        if (m_Time > 0f)
        {
            m_Time -= Time.deltaTime;
        }
        else
        {
            m_Time = TimeStep;
            var memory = LuaClient.GetMainState().LuaGC(LuaGCOptions.LUA_GCCOUNT);
            if (memory < m_Memory)
            {
                Debug.LogFormat("Lua collectgarbage call, from {0} to {1}", m_Memory, memory);
            }
            m_Memory = memory;
        }
    }
}
