using System;
using System.Collections.Generic;
using System.Text;

namespace Leaf.Services.Demo
{
    public class TestService : ITest
    {
        public string GetStrTest()
        {
            return "成功返回字符串！";
        }
    }
}
