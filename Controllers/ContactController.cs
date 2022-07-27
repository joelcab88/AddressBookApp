using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookApp.Interface;
using System.ComponentModel;

namespace AddressBookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly IContactServices _contactServices;
        public ContactController(IContactServices contactServices_)
        {
            _contactServices = contactServices_;
        }
        [HttpGet("getallcontacts/{name?}")]
        public async Task<IActionResult> GetAllContacts(string name)
        {
            var response = await Task.Run<IActionResult>(() => {
                var result = _contactServices.GetAllContacts(name);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }).ContinueWith(ex =>
            {
                if (ex.Exception != null)
                    return BadRequest(ex.Exception);
                return ex.Result;
            });
            return response;
        }

        [HttpGet("getcontactbyid/{id_}")]
        public async Task<IActionResult> GetContactById(string id_)
        {
            var response = await Task.Run<IActionResult>(() => {
                var result = _contactServices.GetContactById(id_);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }).ContinueWith(ex =>
            {
                if (ex.Exception != null)
                    return BadRequest(ex.Exception);
                return ex.Result;
            });
            return response;
        }
        [HttpDelete("deletecontactbyid/{id_}")]
        public async Task<IActionResult> DeleteContactById(string id_)
        {
            var response = await Task.Run<IActionResult>(() => {
                var result = _contactServices.DeleteContact(id_);
                if (!result)
                    return NotFound();

                return NoContent();
            }).ContinueWith(ex =>
            {
                if (ex.Exception != null)
                    return BadRequest(ex.Exception);
                return ex.Result;
            });
            return response;
        }
    }
}
