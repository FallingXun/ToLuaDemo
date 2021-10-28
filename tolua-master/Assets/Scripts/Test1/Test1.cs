using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class Test1 : MonoBehaviour
{
    private LuaTable m_LuaTable;
    //private LuaFunction m_LuaFunction;

    // Start is called before the first frame update
    void Awake()
    {
        m_LuaTable = LuaClient.GetMainState().GetFunction("CreateLua").Invoke<string, LuaTable>("Test1");
        m_LuaTable.SetTable("gameObject", gameObject);
        //m_LuaFunction = m_LuaTable.GetLuaFunction("Update");
        Debug.Log("table reference = " + m_LuaTable.GetReference());
    }

    //private void Update()
    //{
    //    if (m_LuaFunction != null)
    //    {
    //        m_LuaFunction.Call(m_LuaTable);
    //    }
    //}

    public void Dispose()
    {
        if (m_LuaTable != null)
        {
            m_LuaTable.Dispose();
            m_LuaTable = null;

            Debug.Log("LuaTable Dispose");
        }
    }

    void OnDestroy()
    {
        Dispose();
    }
}
