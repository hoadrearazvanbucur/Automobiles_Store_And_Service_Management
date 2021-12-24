using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Payment : IComparable<Payment>
    {
        private int id, customer_id;
        private string bill, type, date, description;


        public Payment(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.customer_id = int.Parse(dataSplit[1]);
            this.bill = dataSplit[2];
            this.type= dataSplit[3];
            this.date= dataSplit[4];
            this.description= dataSplit[5];
        }
        public override string ToString() => this.id + "," + this.customer_id + "," + this.bill + "," + this.type + "," + this.date + "," + this.description;
        public override bool Equals(object obj)
        {
            Payment p = obj as Payment;
            return true;
        }
        public int CompareTo([AllowNull] Payment other)
        {
            throw new NotImplementedException();
        }


        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Customer_id
        {
            get => this.customer_id;
            set => this.customer_id = value;
        }
        public string Bill
        {
            get => this.bill;
            set => this.bill = value;
        }
        public string Type
        {
            get => this.type;
            set => this.type = value;
        }
        public string Date
        {
            get => this.date;
            set => this.date = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
    }
}
