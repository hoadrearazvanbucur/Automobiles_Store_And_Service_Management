using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GENERIC_COLLECTIONS;
using Automobiles_Store_BACK_END.Models;

namespace Automobiles_Store_BACK_END.Controllers
{
    public class Control_Automobile
    {
        private ILista<Automobile> lista;

        public Control_Automobile()
        {
            this.lista = new Lista<Automobile>();
        }

        public void load()
        {
            this.clear();
            StreamReader file = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resorces\Automobiles_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                lista.adaugareSfarsit(new Automobile(line));
            file.Close();
        }
        public void save()
        {
            StreamWriter file = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resorces\Automobiles_File.txt");
            for (int i = 0; i < this.lista.dimensiune(); i++)
                file.WriteLine(lista.obtine(i).Data.ToString());
            file.Close();
        }
        public void clear()
        {
            if (this.lista.listaGoala() != true)
                for (int i = this.lista.dimensiune() - 1; i >= 0; i--)
                    this.lista.stergere(this.lista.obtine(i).Data);
        }

        public string show()
        {
            string text = "";
            for (int i = 0; i < this.lista.dimensiune(); i++)
                text += this.lista.obtine(i).Data.ToString() + "\n";
            return text;
        }
        public void adding(string data)
        {
            this.lista.adaugareSfarsit(new Automobile(data));
        }
        public void removal(Automobile automobile)
        {
            this.lista.stergere(automobile);
        }

        public void changeId(int id, int newId)
        {
            this.lista.obtine(this.positionId(id)).Data.Id = newId;
        }
        public void changeKm(int id, int newKm)
        {
            this.lista.obtine(this.positionId(id)).Data.Km = newKm;
        }
        public void changeAmount(int id, int newAmount)
        {
            this.lista.obtine(this.positionId(id)).Data.Amount = newAmount;
        }
        public void changePrice(int id, double newPrice)
        {
            this.lista.obtine(this.positionId(id)).Data.Price = newPrice;
        }
        public void changeBrand(int id, string newBrand)
        {
            this.lista.obtine(this.positionId(id)).Data.Brand = newBrand;
        }
        public void changeModel(int id, string newModel)
        {
            this.lista.obtine(this.positionId(id)).Data.Model = newModel;
        }
        public void changeColor(int id, string newColor)
        {
            this.lista.obtine(this.positionId(id)).Data.Color = newColor;
        }

        public int positionId(int id)
        {
            int k = 0;
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id == id)
                    return k;
                else
                    k++;
            return -1;
        }
        public int generationId()
        {
            if (this.lista.listaGoala() != true)
                return this.lista.obtine(this.lista.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }

        public ILista<Automobile> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
        public bool exist_Test(string text)
        {
            string[] textSplit = text.Split('|');
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id == int.Parse(textSplit[0]) && this.lista.obtine(i).Data.Km == int.Parse(textSplit[1]) && this.lista.obtine(i).Data.Amount == int.Parse(textSplit[2]) && this.lista.obtine(i).Data.Price == double.Parse(textSplit[3]) && this.lista.obtine(i).Data.Brand == textSplit[4] && this.lista.obtine(i).Data.Model == textSplit[5] && this.lista.obtine(i).Data.Color == textSplit[6])
                    return true;
            return false;
        }
    }
}
