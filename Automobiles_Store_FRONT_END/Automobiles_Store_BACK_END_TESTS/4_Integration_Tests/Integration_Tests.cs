using Automobiles_Store_BACK_END.Controllers;
using Automobiles_Store_BACK_END.Models;
using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Automobiles_Store_BACK_END_TESTS._4_Integration_Tests
{
    public class Integration_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Control_User controlUser;
        private Control_Automobile controlAutomobile;
        private Control_Order controlOrder;

        public Integration_Tests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            this.controlUser = new Control_User();
            this.controlAutomobile = new Control_Automobile();
            this.controlOrder = new Control_Order();
        }

        [Fact]
        public void integration()
        {
            User user1 = new User("1|2|3|4");
            User user2 = new User("11|22|33|44");
            this.controlUser.adding(user1.ToString());
            this.controlUser.adding(user2.ToString());
            this.outputHelper.WriteLine(controlUser.show()+"\n\n");

            Automobile automobile1 = new Automobile("1|2|9|10|5|6|7");
            Automobile automobile2 = new Automobile("2|2|9|15|5|6|7");
            Automobile automobile3 = new Automobile("3|2|9|20|5|6|7");
            this.controlAutomobile.adding(automobile1.ToString());
            this.controlAutomobile.adding(automobile2.ToString());
            this.controlAutomobile.adding(automobile3.ToString());
            this.outputHelper.WriteLine(controlAutomobile.show() + "\n\n");

            Order order1 = new Order("1|1|2|1,2|2,2");
            Order order2 = new Order("2|11|1|3|3");
            this.controlOrder.adding(order1.ToString());
            this.controlOrder.adding(order2.ToString());
            this.outputHelper.WriteLine(controlOrder.show() + "\n\n");
            this.controlOrder.Lista.obtine(this.controlOrder.positionId(1)).Data.addAutomobile(9, 9);
            this.outputHelper.WriteLine(controlOrder.show() + "\n\n");
            this.controlOrder.Lista.obtine(this.controlOrder.positionId(1)).Data.delAutomobile(9);
            this.outputHelper.WriteLine(controlOrder.show() + "\n\n");

            this.controlUser.removal(new User("1|2|3|4"));
            this.outputHelper.WriteLine(controlUser.show() + "\n\n");
        }
    }
}
