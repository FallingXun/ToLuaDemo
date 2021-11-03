using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLog_Generic : TestLogBase
{
    public GameObject m_TestGo;
    public int m_Index = -1;
    public TestGeneric m_Test;

    // Start is called before the first frame update
    void Start()
    {
        AddFunc("´´½¨GameObject Test", Action1);
    }

    private void Action1()
    {
        if (m_TestGo != null)
        {
            var test = Instantiate(m_TestGo);
            m_Test = test.GetComponent<TestGeneric>();
        }
    }
}
