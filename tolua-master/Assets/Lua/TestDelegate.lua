local TestDelegate = newClass("TestDelegate")

function TestDelegate:Ctor(...)
    print("TestDelegate.Ctor")
   
end

function TestDelegate:Init()
    self.del.m_Action = function()
        print("TestDelegate gameObject = " .. self.gameObject.name);
    end
end