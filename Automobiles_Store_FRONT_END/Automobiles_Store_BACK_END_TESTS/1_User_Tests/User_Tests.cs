using Automobiles_Store_BACK_END.Controllers;
using Automobiles_Store_BACK_END.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Automobiles_Store_BACK_END_TESTS._1_User_Tests
{
    public class User_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Control_User control;

        public User_Tests(ITestOutputHelper outputHelper)
        {
            this.control = new Control_User();
            this.outputHelper = outputHelper;
        }


    }
}
