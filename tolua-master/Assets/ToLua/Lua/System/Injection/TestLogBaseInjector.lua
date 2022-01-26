local TestLogBaseInjector = {}

TestLogBaseInjector.AddFunc = function()
	return function (self, name, action)
		print("Lua Inject TestLogBase AddFunc :" .. name)
		print(self.m_Width)
	end, LuaInterface.InjectType.Replace
end

TestLogBaseInjector.Awake = function()
	return function (self)
		print("Lua Inject TestLogBase Awake :")
	end, LuaInterface.InjectType.After
end


InjectByName("TestLogBase", TestLogBaseInjector)