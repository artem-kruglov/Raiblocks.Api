﻿using Lykke.Service.RaiblocksApi.Core.Domain.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Core.Services
{
    public interface IHistoryService<TAddressHistory, TAddressObservation, TAddressOperation>
    {
        /// <summary>
        /// Check is address history already observed
        /// </summary>
        /// <param name="addressObservation">Address observation entity</param>
        /// <returns>true if already observed</returns>
        Task<bool> IsAddressObservedAsync(TAddressObservation addressObservation);

        /// <summary>
        /// Observe address history
        /// </summary>
        /// <param name="addressObservation">Address observation entity</param>
        /// <returns>true if created, false if existed before</returns>
        Task<bool> AddAddressObservationAsync(TAddressObservation addressObservation);

        /// <summary>
        /// Stop observe address history
        /// </summary>
        /// <param name="addressObservation"></param>
        /// <returns>A Task object that represents the asynchronous operation.</returns>
        Task<bool> RemoveAddressObservationAsync(TAddressObservation addressObservation);

        /// <summary>
        /// Get observed addresses
        /// </summary>
        /// <param name="pageSize">Amount of address observation</param>
        /// <param name="continuation">continuation data</param>
        /// <param name="partitionKey">partition key for azure storage</param>
        /// <returns>continuation data and observerd addresses</returns>
        Task<(string continuation, IEnumerable<TAddressObservation> items)> GetAddressObservationAsync(int pageSize, string continuation = null, string partitionKey = null);

        /// <summary>
        /// Get stored address history after specific hash
        /// </summary>
        /// <param name="take">Amount of history entries</param>
        /// <param name="partitionKey">partition key for azure storage</param>
        /// <param name="address">Address</param>
        /// <param name="afterHash">Block hash</param>
        /// <returns>Address history</returns>
        Task<IEnumerable<TAddressHistory>> GetAddressHistoryAsync(int take, string partitionKey, string address, string afterHash);
       
        /// <summary>
        /// Get stored address history
        /// </summary>
        /// <param name="take">Amount of history entries</param>
        /// <param name="continuation">continuation data</param>
        /// <param name="partitionKey">partition key for azure storage</param>
        /// <returns>Address history</returns>
        Task<(string continuation, IEnumerable<TAddressHistory> items)> GetAddressHistoryAsync(int take, string continuation, string partitionKey = null);

        /// <summary>
        /// Save address history entry
        /// </summary>
        /// <param name="addressHistoryEntry">Address history entry</param>
        /// <returns>A Task object that represents the asynchronous operation.</returns>
        Task<bool> InsertAddressHistoryAsync(TAddressHistory addressHistoryEntry);

        /// <summary>
        /// Get operation history
        /// </summary>
        /// <param name="take"></param>
        /// <param name="partitionKey"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        Task<IEnumerable<TAddressOperation>> GetAddressOperationHistoryAsync(int take, string partitionKey, string address);

        /// <summary>
        /// Save operation history entry
        /// </summary>
        /// <param name="operationHistoryEntry">Operation history entry</param>
        /// <returns>true if created, false if existed before</returns>
        Task<bool> AddAddressOperationHistoryAsync(TAddressOperation operationHistoryEntry);
    }
}
