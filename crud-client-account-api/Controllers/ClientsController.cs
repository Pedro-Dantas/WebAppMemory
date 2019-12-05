using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        // GET api/clients
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            List<string> readLoaded = ClientRepository.GetClientes();
            List<string> NamesLoaded = new List<string>();

            if (readLoaded == null)
            {
                return null;
            }
            else
            {
                foreach (var item in readLoaded)
                {
                    NamesLoaded.Add(item);
                }
            }
            return NamesLoaded;


        }

        // GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                List<Client> ClientsLoadead = Client.GetClients();

                foreach (var client in ClientsLoadead)
                {
                    if (client.Id == id)
                    {
                       return "Id: " + client.Id + ", Nome: " + client.Nome + ", Cpf: " + client.Cpf;
                    }
                }
                return "Cliente não encontrado!";
            }
            catch(Exception ex)
            {
                return  "Ocorreu o seguinte erro: " + ex;
            }
            
        }

        // POST api/clients
        [HttpPost]
        public string Post([FromBody] Client client)
        {
            try
            {
                Client.AddClient(client);
                return "Cliente adicionado com sucesso!";
            }
            catch(Exception ex)
            {
                return "Cliente não adicionado! Ocorreu o seguinte erro: " + ex.Message;
            }
            
        }

        // PUT api/clients/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Client clientBody)
        {
            try
            {
                List<Client> ClientsLoadead = Client.GetClients();

                foreach (var client in ClientsLoadead)
                {
                    if (client.Id == id)
                    {
                        client.Nome = clientBody.Nome;
                        client.Cpf = clientBody.Cpf;
                    }
                }
                return "Cliente alterado com sucesso!";
            }
            catch(Exception ex)
            {
                return "Não foi possivel alterar o cliente! Ocorreu o seguinte erro: " + ex;
            }
        }

        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                Client.RemoveClient(id);
                return "Cliente removido com sucesso!";
            }
            catch(Exception ex)
            {
                return "Ocorreu o seguinte erro: " + ex.Message;
            }
        }
    }
    
}
