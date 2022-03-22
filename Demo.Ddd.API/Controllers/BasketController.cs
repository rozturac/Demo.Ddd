using Demo.Ddd.Application.Baskets.AddItem;
using Demo.Ddd.Application.Baskets.AddItemCommand;
using Demo.Ddd.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Ddd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ISender _sender;
        public BasketController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<GenericResult<AddItemToBasketResultDto>> AddItem(AddItemToBasketCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
