using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {

        private readonly ILogger<BankingController> _logger;
        private readonly IAccountServices _accountService;

        public BankingController(ILogger<BankingController> logger,IAccountServices accountServices)
        {
            _logger = logger;
            _accountService = accountServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccount());
        }
    }
}
