using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class User : IComparable<User>
    {
        private int id, role_id;
        private string name, email, dob,address;

        public User(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.role_id = int.Parse(dataSplit[1]);
            this.name = dataSplit[2];
            this.email = dataSplit[3];
            this.dob = dataSplit[4];
            this.address = dataSplit[5];
        }

        public override string ToString() => this.id + "," + this.role_id + "," + this.name + "," + this.email + "," + this.dob + "," + this.address;
        public override bool Equals(object obj)
        {
            User u = obj as User;
            return true;
        }
        public int CompareTo([AllowNull] User other)
        {
            throw new NotImplementedException();
        }


        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Role_id
        {
            get => this.role_id;
            set => this.role_id = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
        public string Dob
        {
            get => this.dob;
            set => this.dob = value;
        }
        public string Address
        {
            get => this.address;
            set => this.address = value;
        }
    }
}
