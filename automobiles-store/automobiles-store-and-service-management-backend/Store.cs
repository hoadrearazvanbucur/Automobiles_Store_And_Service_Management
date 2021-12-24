using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Store : IComparable<Store>
    {
        private int id;
        private string title, type, description;


        public Store(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.title= dataSplit[1];
            this.type= dataSplit[2];
            this.description= dataSplit[3];
        }
        public override string ToString() => this.id + "," + this.title + "," + this.type + "," + this.description;
        public override bool Equals(object obj)
        {
            Store s = obj as Store;
            return true;
        }
        public int CompareTo([AllowNull] Store other)
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
        public string Type
        {
            get => this.type;
            set => this.type = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
    }
}
