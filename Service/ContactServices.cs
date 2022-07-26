using AddressBookApp.DTO;
using AddressBookApp.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookApp.Service
{
    public class ContactServices : IContactServices
    {
        public bool DeleteContact(string iIdContacto_)
        {
            var data = GetDataJson();
            if (!data.Where(x => x.id == iIdContacto_).Any())
                return false;

            data.Remove(data.Where(x => x.id == iIdContacto_).FirstOrDefault());
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

            using (StreamWriter newTask = new StreamWriter($"{Directory.GetCurrentDirectory()}/backend test/fakedatabase.js", false))
            {
                newTask.WriteLine(jsonData);
            }
            return true;
        }

        public List<ContactDTO> GetAllContacts(string name_)
        {
            var data = name_==null ? GetDataJson().OrderBy(x => x.name).ToList() : GetDataJson().Where(x => x.name.Contains(name_)).OrderBy(x => x.name).ToList();
            return data;
        }

        public ContactDTO GetContactById(string iIdContacto_)
        {
            var data = GetDataJson().OrderBy(x => x.id).Where(x => x.id == iIdContacto_).FirstOrDefault();
            return data;
        }
        /// <summary>
        /// Deserializa la información json del archivo fakedatabase.
        /// </summary>
        /// <returns>Lista de contactos.</returns>
        private static List<ContactDTO> GetDataJson()
        {
            var json = JsonConvert.DeserializeObject<List<ContactDTO>>(File.ReadAllText($"{Directory.GetCurrentDirectory()}/backend test/fakedatabase.js"));
            return json;
        }
    }
}
