using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Automobiles : IComparable<Automobiles>
    {
        private int id, customer_id;
        private string description, type, number;

        public Automobiles(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.customer_id = int.Parse(dataSplit[1]);
            this.description = dataSplit[2];
            this.type = dataSplit[3];
            this.number = dataSplit[4];
        }

        public override string ToString() => this.id + "," + this.customer_id + "," + this.description + "," + this.type + "," + this.number;
        public override bool Equals(object obj)
        {
            Automobiles a = obj as Automobiles;
            return true;
        }
        public int CompareTo([AllowNull] Automobiles other)
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
            get => this.id;
            set => this.id = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
        public string Type
        {
            get => this.type;
            set => this.type = value;
        }
        public string Number
        {
            get => this.number;
            set => this.number = value;
        }
    }
}
