﻿using Lykke.Service.RaiblocksApi.Core.Domain.Entities.Balances;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Core.Repositories.Balances
{
    public interface IAddressBalanceRepository<TAddressBalance> : IRepository<TAddressBalance>
        where TAddressBalance : IAddressBalance
    {
    }
}