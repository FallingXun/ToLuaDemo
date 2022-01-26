local Test1_1Injector = {}

Test1_1Injector.Test = function()
	return function (table)
		print("Lua Inject Test1_1 Test :" .. tostring(table))
	end, LuaInterface.InjectType.Replace
end

Test1_1Injector.Awake = function()
	return function (self)
		print("Lua Inject Test1_1 Awake :")
	end, LuaInterface.InjectType.After
end


InjectByModule(Test1_1, Test1_1Injector)