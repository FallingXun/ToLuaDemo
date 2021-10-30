using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class Test1 : MonoBehaviour
{
    private LuaTable m_LuaTable;

    // Start is called before the first frame update
    void Awake()
    {
        // ������ʱ����������������
        var function = LuaClient.GetMainState().GetFunction("CreateLua");
        Debug.Log("Test1 ��ʱ���� function reference = " + function.GetReference());
        m_LuaTable = function.Invoke<string, LuaTable>("Test1");
        m_LuaTable.SetTable("gameObject", gameObject);
        Debug.Log("Test1 ��Ա���� table reference = " + m_LuaTable.GetReference());
        var tb = function.Invoke<string, LuaTable>("TestLua1");
        tb.SetTable("gameObject", gameObject);
        Debug.Log("Test1 ��ʱ���� table reference = " + tb.GetReference());
    }


    public void Dispose()
    {
        if (m_LuaTable != null)
        {
            m_LuaTable.Dispose();
            m_LuaTable = null;

            Debug.Log("Test1 LuaTable Dispose");
        }
    }

    void OnDestroy()
    {
        //Dispose();
    }
}
