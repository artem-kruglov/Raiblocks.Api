﻿using AzureStorage;
using Common.Log;
using Lykke.AzureStorage.Tables.Paging;
using Lykke.Service.RaiblocksApi.AzureRepositories.Entities.Addresses;
using Lykke.Service.RaiblocksApi.Core.Domain.Entities.Addresses;
using Lykke.Service.RaiblocksApi.Core.Repositories.Addresses;
using Lykke.SettingsReader;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.AzureRepositories.Repositories.Addresses
{
    public class AddressHistoryEntryRepository : AzureRepository<AddressHistoryEntry>, IAddressHistoryEntryRepository<AddressHistoryEntry>
    {
        public AddressHistoryEntryRepository(IReloadingManager<string> connectionStringManager, ILog log) : base(connectionStringManager, log)
        {
        }

        public override string DefaultPartitionKey()
        {
            return null;
        }

        /// <summary>
        /// Return history entries for address after specific hash
        /// </summary>
        /// <param name="take">Amount of the returned history entry</param>
        /// <param name="partitionKey">PartitionKey for azure table storage</param>
        /// <param name="address">Address</param>
        /// <param name="afterBlockCount">Block hash</param>
        /// <returns>History entries for address after specific hash</returns>
        public async Task<(string continuation, IEnumerable<AddressHistoryEntry> items)> GetByAddressAsync(int take, string partitionKey, string address, long afterBlockCount = 0, string continuation = null)
        {
            var addressFieldName = partitionKey == Enum.GetName(typeof(AddressObservationType), AddressObservationType.From)
                ? nameof(AddressHistoryEntry.FromAddress) : nameof(AddressHistoryEntry.ToAddress);

            var page = new PagingInfo { ElementCount = take };

            page.Decode(continuation);

            var query = new TableQuery<AddressHistoryEntry>()
                 .Where(TableQuery.CombineFilters(
                     TableQuery.GenerateFilterCondition(nameof(AddressHistoryEntry.PartitionKey), QueryComparisons.Equal, partitionKey),
                     TableOperators.And,
                     TableQuery.CombineFilters(
                         TableQuery.GenerateFilterConditionForLong(nameof(AddressHistoryEntry.BlockCount), QueryComparisons.GreaterThan, afterBlockCount),
                         TableOperators.And,
                         TableQuery.GenerateFilterCondition(addressFieldName, QueryComparisons.Equal, address)
                     )));

            var items = await _tableStorage.ExecuteQueryWithPaginationAsync(query, page);

            return (items.PagingInfo.Encode(), items);
        }
    }
}
