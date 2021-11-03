local TestGenericLua = newClass("TestGenericLua")

int = tolua.findtype("System.Int32")
function TestGenericLua:Ctor(...)
    print("TestGenericLua.Ctor")
   
end

function TestGenericLua:Init()
    local list = System.Collections.Generic.List(typeof(UnityEngine.GameObject));
    list:Add(self.gameObject);
    self.TestGeneric:TestList(list);


    local dic = System.Collections.Generic.Dictionary(int,typeof(UnityEngine.GameObject))
    dic:Add(1,self.gameObject);
    self.TestGeneric:TestDictionary(dic);
end