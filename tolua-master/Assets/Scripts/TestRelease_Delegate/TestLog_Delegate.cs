using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLog_Delegate : TestLogBase
{
    public GameObject m_TestGo;
    public int m_Index = -1;
    public TestRelease_Delegate m_Test;

    // Start is called before the first frame update
    void Start()
    {
        AddFunc("创建GameObject Test", Action1);
        AddFunc("销毁GameObject Test", Action2);
        AddFunc("释放LuaTable", Action3);
    }
    
    private void Action1()
    {
        if (m_TestGo != null)
        {
            var test = Instantiate(m_TestGo);
            m_Test = test.GetComponent<TestRelease_Delegate>();
            LuaClient.GetMainState().translator.Getudata(test, out m_Index);
            Debug.Log("GameObject Test udata = " + m_Index);
        }
    }

    private void Action2()
    {
        if (m_Test != null)
        {
            Destroy(m_Test.gameObject);
            m_Test = null;
        }
    }

    private void Action3()
    {
        if (m_Test != null)
        {
            m_Test.Dispose();
        }
    }
}
