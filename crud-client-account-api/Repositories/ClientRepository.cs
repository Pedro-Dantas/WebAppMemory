using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project.Repositories
{
    public class ClientRepository
    {
        private static readonly string ConnectionString = "Data Source=BRRIOWN022117\\SQLEXPRESS;Initial Catalog=ProjetoPai;Integrated Security=False;User Id=sa;Password=sa;Persist Security Info=True;MultipleActiveResultSets=True";

        public static List<string> GetClientes()
        {
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            string query = "SELECT Id, Nome, Cpf FROM Clientes";

            try
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand(query, SQLConnection);
                SqlDataReader ReadQuery = command.ExecuteReader();

                List<string> ReadAllNamesLoaded = new List<string>();
                
                if (ReadQuery.HasRows)
                {
                    while (ReadQuery.Read())
                    {
                        ReadAllNamesLoaded.Add(ReadQuery["Nome"].ToString() + "-" + ReadQuery["Cpf"].ToString());
                    }
                }

                if (ReadQuery == null)
                {
                    ReadQuery.Close();
                }

                return ReadAllNamesLoaded;
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro resultado: " + ex);
                Console.ResetColor();
                return null;
            }
        }
    }





}
