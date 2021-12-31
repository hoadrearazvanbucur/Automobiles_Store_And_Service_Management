using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END.Models
{
    public class Automobile : IComparable<Automobile>
    {
        private int id, km, amount;
        private double price;
        private string brand, model, color;

        public Automobile(string data)
        {
            string[] dataSplit = data.Split('|');
            this.id = int.Parse(dataSplit[0]);
            this.km = int.Parse(dataSplit[1]);
            this.amount = int.Parse(dataSplit[2]);
            this.price = double.Parse(dataSplit[3]);
            this.brand = dataSplit[4];
            this.model = dataSplit[5];
            this.color = dataSplit[6];
        }

        public override string ToString() => this.id + "|" + this.km + "|" + this.amount + "|" + this.price + "|" + this.brand + "|" + this.model + "|" + this.color;
        public override bool Equals(object obj) => (obj as Automobile).ToString() == this.ToString();
        public int CompareTo(Automobile other)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Km
        {
            get => this.km;
            set => this.km = value;
        }
        public int Amount
        {
            get => this.amount;
            set => this.amount = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
        public string Brand
        {
            get => this.brand;
            set => this.brand = value;
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }
        public string Color
        {
            get => this.color;
            set => this.color = value;
        }
    }
}
