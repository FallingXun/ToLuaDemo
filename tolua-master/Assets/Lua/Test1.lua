local Test1 = newClass("Test1")

function Test1:Ctor(...)
    print("Test1.Ctor")
    self.key = ""
    self.count = 10
end

function Test1:Init()

end

-- function Test1:Update()
--     -- print("Update")
--     for index = 1, 100 do
--         self.key = self.key .. tostring(index)
--     end
--     self.count = self.count - 1
--     if self.count <= 0 then
--         self.count = 10
--         self.key = ""
--     end
-- end

function Test1:Dispose()

end
