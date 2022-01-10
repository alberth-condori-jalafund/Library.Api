using Library.Api.Messages;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/v1/sales/[controller]")]
    public class TopsController : ControllerBase
    {
        private readonly IService<Book> service;
        public int top { get; set; } = 10;
        public TopsController(IService<Book> service)
        {
            this.service = service;
        }
        [ProducesResponseType(typeof(List<Book>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 204)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(typeof(ErrorMessage), 500)]
        [HttpGet]
        public IActionResult Top()
        {
            ObjectResult objectResult;
            try
            {
                if (top <= 0 || top > 100)
                    throw new ArgumentOutOfRangeException("Bad top entry");
                var list = service.GetTop(top);
                if (list == null || list.Count == 0)
                    throw new Exception("Nothing to show on top");
                objectResult = new ObjectResult(list) { StatusCode = 200 };

            }
            catch (ArgumentOutOfRangeException ex)
            {
                objectResult = new ObjectResult(new ErrorMessage(ex.Message)) { StatusCode = 400 };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    objectResult = new ObjectResult(new ErrorMessage(ex.Message)) { StatusCode = 500 };
                else
                    objectResult = new ObjectResult(new ErrorMessage(ex.Message)) { StatusCode = 204 };
            }
            return objectResult;
        }
    }
}
