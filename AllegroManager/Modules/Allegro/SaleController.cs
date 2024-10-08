﻿using AllegroConnector.Application.AllegroApi.Queries;
using AllegroConnector.Application.Contracts;
using AllegroConnector.Application.Imports.ImportOffers;
using AllegroManager.Modules.Allegro.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllegroManager.Modules.Allegro
{
    [ApiController]
    [Route("api/myallegro/[controller]")]
    [Authorize]
    public class SaleController(IAllegroModule allegroModule) : ControllerBase
    {

        [HttpGet("categories")]
        public async Task<IActionResult> Categories()
        {
            var response = await allegroModule.ExecuteQueryAsync(new CategoriesQuery());

            return Ok(response);
        }

        [HttpGet("saleOffers")]
        public async Task<IActionResult> SaleOffers([FromQuery] string limit, string offset)
        {
            var response = await allegroModule.ExecuteQueryAsync(new SaleOffersQuery(limit, offset));

            return Ok(response);
        }

        [HttpGet("offers")]
        public async Task<IActionResult> Offers(string offerId)
        {
            var response = await allegroModule.ExecuteQueryAsync(new OfferQuery(offerId));

            return Ok(response);
        }

        [HttpGet("calculateFee")]
        public async Task<IActionResult> CalculateFeeForOffer([FromQuery] string offerId)
        {
            var response = await allegroModule.ExecuteQueryAsync(new CalculateOfferFeeQuery(offerId));
            return Ok(response);
        }


        [HttpGet("incomes")]
        public async Task<IActionResult> Incomes([FromQuery] DateTime from, DateTime to)
        {
            var response = await allegroModule.ExecuteQueryAsync(new IncomesQuery(from, to));
            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportOffers([FromBody] PlainOffers offers)
        {
            var response = await allegroModule.ExecuteCommandAsync(new ImportOffersCommand(offers.Offers));
            return Ok(response);
        }
    }
}
