using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Role : IComparable<Role>
    {
        public int id;
        public string title, description;

        public Role(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.title= dataSplit[1];
            this.description= dataSplit[2];
        }
        public override string ToString() => this.id + "," + this.title + "," + this.description;
        public override bool Equals(object obj)
        {
            Role r = obj as Role;
            return true;
        }
        public int CompareTo([AllowNull] Role other)
        {
            throw new NotImplementedException();
        }


        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Title
        {
            get => this.title;
            set => this.title = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
    }
}
