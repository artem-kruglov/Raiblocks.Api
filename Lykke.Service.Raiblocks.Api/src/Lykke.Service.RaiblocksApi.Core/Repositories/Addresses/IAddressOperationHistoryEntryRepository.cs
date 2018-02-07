﻿using Lykke.Service.RaiblocksApi.Core.Domain.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Core.Repositories.Addresses
{
    public interface IAddressOperationHistoryEntryRepository<OperationHistoryEntry> : IRepository<OperationHistoryEntry>
        where OperationHistoryEntry: IAddressOperationHistoryEntry
    {
        Task<IEnumerable<OperationHistoryEntry>> GetByAddressAsync(int take, string partitionKey, string address);
    }
}
