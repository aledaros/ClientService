using Gruppo3.ClientiDTO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo3.Clienti.Domain.DTO
{
    public class InsertClientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Piva { get; set; }
        public string Businessname { get; set; }
        public string CF { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }

        public static InsertClientDTO ConvertClientToInsertClientDTO(Client client)
        {
            return new InsertClientDTO
            {
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Piva = client.Piva,
                Businessname = client.Businessname,
                CF = client.CF,
                Address = client.Address,
                Year = client.Year
            };
        }

        public static Client ConvertInsertClientDTOTOClient(InsertClientDTO insertClient)
        {
            return new Client
            {
                Name = insertClient.Name,
                Surname = insertClient.Surname,
                Email = insertClient.Email,
                Piva = insertClient.Piva,
                Businessname = insertClient.Businessname,
                CF = insertClient.CF,
                Address = insertClient.Address,
                Year = insertClient.Year
            };
        }
    }
}
