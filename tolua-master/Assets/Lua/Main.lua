collectgarbage("setpause", 100)
collectgarbage("setstepmul", 5000)


--主入口函数。从这里开始lua逻辑
function Main()					
	print("logic start")	 		

end

function CreateLua(luaType)
	local ltype;
	if(type(luaType) == "string") then
		ltype = _G[luaType];
	else
		ltype = luaType;
	end
	if(ltype == nil) then
		error("类型不存在 " .. tostring(luaType))
	end
	
	local tmp = ltype.New();
	return tmp;
end

function newClass(luaType)
	local cls = cls or {};

	function cls.New(...)
		local instance = setmetatable({}, cls)
		instance.class = cls
		instance:Ctor(...)
		return instance
	end
	cls.__index = cls
	_G[luaType] = cls;
	return cls;
end


require("Test1")

-- --场景切换通知
-- function OnLevelWasLoaded(level)
-- 	collectgarbage("collect")
-- 	Time.timeSinceLevelLoad = 0
-- end

function OnApplicationQuit()
end