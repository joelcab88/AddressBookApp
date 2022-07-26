using AddressBookApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookApp.Interface
{
    public interface IContactServices
    {
        /// <summary>
        /// Obtiene información de todos los contactos.
        /// </summary>
        /// <returns>información de contactos</returns>
        ContactDTO GetAllContacts();
        /// <summary>
        /// Obtiene la información de un contacto dado un id.
        /// </summary>
        /// <param name="iIdContacto_">Id del contacto a consulta.</param>
        /// <returns>información de contacto.</returns>
        ContactDTO GetContactById(int iIdContacto_);
        /// <summary>
        /// Elimina información de contacto
        /// </summary>
        /// <param name="iIdContacto_">Id del contacto a consulta.</param>
        /// <returns>true en caso de que el registro haya sido eliminado, caso contario = false</returns>
        bool DeleteContact(int iIdContacto_);
    }
}
