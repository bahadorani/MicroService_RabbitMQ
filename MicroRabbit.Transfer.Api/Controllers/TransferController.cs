using MicroService.Transfer.Application.Interfaces;
using MicroService.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        private readonly ILogger<TransferController> _logger;
        public TransferController(ITransferService transferService, ILogger<TransferController> logger)
        {
            _transferService = transferService;
            _logger = logger;
        }

      [HttpGet]
      public ActionResult<IEnumerable<TransferLog>> GetLogs()
        {
            return Ok(_transferService.GetTransferLogs());
        }

       
    }
}
