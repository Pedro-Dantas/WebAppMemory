using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public static List<Client> Clients = new List<Client>
        {
            new Client {Id = 1, Nome = "Pedro", Cpf = "70411533045"},
            new Client {Id = 2, Nome = "Paulo", Cpf = "54766777042"},
            new Client {Id = 3, Nome = "Cristiano", Cpf = "17843902082"},
            new Client {Id = 4, Nome = "Sandro", Cpf = "16748352053"},
            new Client {Id = 5, Nome = "Fernando", Cpf = "98409938014"},
            new Client {Id = 6, Nome = "Deive", Cpf = "23537337000"},
            new Client {Id = 7, Nome = "Peter", Cpf = "06323401002"},
            new Client {Id = 8, Nome = "Romário", Cpf = "57798076042"},
            new Client {Id = 9, Nome = "Carlos", Cpf = "10549220046"},
            new Client {Id = 10, Nome = "Andre", Cpf = "92366498071"},
        };

        public static List<Client> GetClients()
        {
            return Clients;
        }
         
        public static void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public static void RemoveClient(int id)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Id == id)
                {
                    Clients.RemoveAt(i);
                }
            }
        }

    }
}