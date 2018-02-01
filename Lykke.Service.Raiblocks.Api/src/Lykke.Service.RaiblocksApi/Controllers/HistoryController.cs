﻿using Lykke.Common.Api.Contract.Responses;
using Lykke.Service.BlockchainApi.Contract.Transactions;
using Lykke.Service.RaiblocksApi.AzureRepositories.Entities.Addresses;
using Lykke.Service.RaiblocksApi.Core.Domain.Entities.Addresses;
using Lykke.Service.RaiblocksApi.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Controllers
{
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService<AddressHistoryEntry, AddressObservation> _historyService;
        private readonly IAssetService _assetService;

        public HistoryController(IHistoryService<AddressHistoryEntry, AddressObservation> historyService, IAssetService assetService)
        {
            _historyService = historyService;
            _assetService = assetService;
        }

        /// <summary>
        /// Start observation of the transactions that transfer fund from the address
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost("from/{address}/observation")]
        [SwaggerOperation("AddHistoryObservationFrom")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> AddHistoryObservationFrom(string address)
        {
            AddressObservation addressObservation = new AddressObservation
            {
                Address = address,
                Type = AddressObservationType.From
            };
            if (!await _historyService.IsAddressObserved(addressObservation) && await _historyService.AddAddressObservation(addressObservation))
                return Ok();
            else
                return StatusCode((int)HttpStatusCode.Conflict, ErrorResponse.Create("Transactions from the address are already observed"));
        }

        /// <summary>
        /// Start observation of the transactions that transfer fund to the address
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost("to/{address}/observation")]
        [SwaggerOperation("AddHistoryObservationFrom")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> AddHistoryObservationTo(string address)
        {
            AddressObservation addressObservation = new AddressObservation
            {
                Address = address,
                Type = AddressObservationType.To
            };
            if (!await _historyService.IsAddressObserved(addressObservation) && await _historyService.AddAddressObservation(addressObservation))
                return Ok();
            else
                return StatusCode((int)HttpStatusCode.Conflict, ErrorResponse.Create("Transactions to the address are already observed"));
        }

        /// <summary>
        /// Get completed transactions that transfer fund from the address 
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <param name="take">Amount of the returned transactions should not exceed take</param>
        /// <param name="afterHash">Transaction hash</param>
        /// <returns>Historical transaction contract</returns>
        [HttpGet("from/{address}")]
        [SwaggerOperation("GetHistoryFrom")]
        [ProducesResponseType(typeof(IEnumerable<HistoricalTransactionContract>), (int)HttpStatusCode.OK)]
        public IEnumerable<HistoricalTransactionContract> GetHistoryFrom(string address, [FromQuery]int take = 100, [FromQuery]string afterHash = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get completed transactions that transfer fund to the address
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <param name="take">Amount of the returned transactions should not exceed take</param>
        /// <param name="afterHash">Transaction hash</param>
        /// <returns>Historical transaction contract</returns>
        [HttpGet("to/{address}")]
        [SwaggerOperation("GetHistoryTo")]
        [ProducesResponseType(typeof(IEnumerable<HistoricalTransactionContract>), (int)HttpStatusCode.OK)]
        public IEnumerable<HistoricalTransactionContract> GetHistoryTo(string address, [FromQuery]int take = 100, [FromQuery]string afterHash = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop observation of the transactions that transfer fund from the address
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Status code</returns>
        [HttpDelete("from/{address}/observation")]
        [SwaggerOperation("DeleteHistoryFrom")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NoContent)]
        public IEnumerable<HistoricalTransactionContract> DeleteHistoryFrom(string address)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop observation of the transactions that transfer fund to the address
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Status code</returns>
        [HttpDelete("to/{address}/observation")]
        [SwaggerOperation("DeleteHistoryTo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NoContent)]
        public IEnumerable<HistoricalTransactionContract> DeleteHistoryTo(string address)
        {
            throw new NotImplementedException();
        }
    }
}
