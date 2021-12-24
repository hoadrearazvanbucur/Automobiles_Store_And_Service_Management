using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Customer : IComparable<Customer>
    {
        private int id;
        private string name, mobile, email, password, address, username;

        public Customer(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id= int.Parse(dataSplit[0]);
            this.name= dataSplit[1];
            this.mobile= dataSplit[2];
            this.email= dataSplit[3];
            this.password= dataSplit[4];
            this.address= dataSplit[5];
            this.username= dataSplit[6];
        }

        public override string ToString() => this.id + "," + this.name + "," + this.mobile + "," + this.email + "," + this.password + "," + this.address + "," + this.username;
        public override bool Equals(object obj)
        {
            Customer c = obj as Customer;
            return true;
        }
        public int CompareTo([AllowNull] Customer other)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Mobile
        {
            get => this.mobile;
            set => this.mobile = value;
        }
        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public string Address
        {
            get => this.address;
            set => this.address = value;
        }
        public string Username
        {
            get => this.username;
            set => this.username = value;
        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
    }
}
