using System.Collections.Generic;

namespace AddressBookApp.DTO
{
    public class ContactDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public List<string> addressLines { get; set; }
    }
}
