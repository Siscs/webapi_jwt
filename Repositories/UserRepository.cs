using System.Collections.Generic;
using lxwebapi.Models;
using System.Linq;

namespace lxwebapi.Repositories
{
    public class UserRepository
    {

        public static Usuario Get(string nome, string password) 
        {
            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new Usuario() { Id = 1, Nome = "Cesar", Password = "Cesar123", Role = "Director"});
            usuarios.Add(new Usuario() { Id = 2, Nome = "Ryan", Password = "Ryan123", Role = "Manager"});
            usuarios.Add(new Usuario() { Id = 3, Nome = "Adriana", Password = "Dri123", Role = "Employee"});
            usuarios.Add(new Usuario() { Id = 4, Nome = "Titi", Password = "Titi123", Role = "Supervisor"});

            return usuarios.Where(x => x.Nome == nome && x.Password == password).FirstOrDefault();


        }

    }
}