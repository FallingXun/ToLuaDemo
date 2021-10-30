local TestLua1 = newClass("TestLua1")

function TestLua1:Ctor(...)
    print("TestLua1.Ctor")
    self:Init();
end

function TestLua1:Init()
    Test1_1.Test(self);
end
