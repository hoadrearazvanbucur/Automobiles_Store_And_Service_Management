using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Permission : IComparable<Permission>
    {
        private int id, role_id;
        private string title, module, description;
        

        public Permission(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.role_id = int.Parse(dataSplit[1]);
            this.title = dataSplit[2];
            this.module = dataSplit[3];
            this.description = dataSplit[4];
        }
        public override string ToString() => this.id + "," + this.role_id + "," + this.title + "," + this.module + "," + this.description;
        public override bool Equals(object obj)
        {
            Permission p = obj as Permission;
            return true;
        }
        public int CompareTo([AllowNull] Permission other)
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
        public string Title
        {
            get => this.title;
            set => this.title = value;
        }
        public string Module
        {
            get => this.module;
            set => this.module = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
    }
}
