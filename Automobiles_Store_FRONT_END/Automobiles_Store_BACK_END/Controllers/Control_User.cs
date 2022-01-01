using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GENERIC_COLLECTIONS;
using Automobiles_Store_BACK_END.Models;

namespace Automobiles_Store_BACK_END.Controllers
{
    public class Control_User
    {
        private ILista<User> lista;

        public Control_User()
        {
            this.lista = new Lista<User>();
        }

        public void load()
        {
            this.clear();
            StreamReader file = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resorces\Users_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                lista.adaugareSfarsit(new User(line));
            file.Close();
        }
        public void save()
        {
            StreamWriter file = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resorces\Users_File.txt");
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
            this.lista.adaugareSfarsit(new User(data));
        }
        public void removal(User user)
        {
            this.lista.stergere(user);
        }

        public void changeId(int id, int newId)
        {
            this.lista.obtine(this.positionId(id)).Data.Id = newId;
        }
        public void changeAdmin(int id, int newAdmin)
        {
            this.lista.obtine(this.positionId(id)).Data.Admin = newAdmin;
        }
        public void changeName(int id, string newName)
        {
            this.lista.obtine(this.positionId(id)).Data.Name = newName;
        }
        public void changePassword(int id, string newPassword)
        {
            this.lista.obtine(this.positionId(id)).Data.Password = newPassword;
        }

        public void makeRemoveAdmin(int id, int adminIndex)
        {
            if (adminIndex == 1)
                this.lista.obtine(this.positionId(id)).Data.Admin = 0;
            else
                this.lista.obtine(this.positionId(id)).Data.Admin = 1;
        }
        public int getId(string name,string password)
        {
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Name == name && this.lista.obtine(i).Data.Password == password)
                    return this.lista.obtine(i).Data.Id;
            return -1;
        }
        public int getAdmin(string name, string password)
        {
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Name == name && this.lista.obtine(i).Data.Password == password)
                    return this.lista.obtine(i).Data.Admin;
            return -1;
        }
        public bool login_exist(string name,string password)
        {
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Name == name && this.lista.obtine(i).Data.Password == password)
                    return true;
            return false;
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

        public ILista<User> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
        public bool exist_Test(string text)
        {
            string[] textSplit = text.Split('|');
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id == int.Parse(textSplit[0]) && this.lista.obtine(i).Data.Admin == int.Parse(textSplit[1]) && this.lista.obtine(i).Data.Name == textSplit[2] && this.lista.obtine(i).Data.Password == textSplit[3])
                    return true;
            return false;
        }
    }
}
