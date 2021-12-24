using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace automobiles_store_and_service_management_backend
{
    public class Services : IComparable<Services>
    {
        public int id, vehicle_id;
        private string charge, type, description;


        public Services(string data)
        {
            string[] dataSplit = data.Split(",");
            this.id = int.Parse(dataSplit[0]);
            this.vehicle_id = int.Parse(dataSplit[1]);
            this.charge= dataSplit[2];
            this.type= dataSplit[3];
            this.description= dataSplit[4];
        }
        public override string ToString() => this.id + "," + this.vehicle_id + "," + this.charge + "," + this.type + "," + this.description;
        public override bool Equals(object obj)
        {
            Services s = obj as Services;
            return true;
        }
        public int CompareTo([AllowNull] Services other)
        {
            throw new NotImplementedException();
        }


        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Vehicle_id
        {
            get => this.vehicle_id;
            set => this.vehicle_id = value;
        }
        public string Charge
        {
            get => this.charge;
            set => this.charge = value;
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
