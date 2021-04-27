using Lolaflora.Baskets.Application.Baskets.AddItem;
using Lolaflora.Baskets.Application.Baskets.AddItemCommand;
using Lolaflora.Baskets.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lolaflora.Basket.API.Controllers
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
