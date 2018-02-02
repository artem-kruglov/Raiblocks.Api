﻿using Common.Log;
using Lykke.JobTriggers.Triggers.Attributes;
using Lykke.Service.RaiblocksApi.AzureRepositories.Entities.Balances;
using Lykke.Service.RaiblocksApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Jobs
{
    public class BalanceRefreshJob
    {
        private readonly ILog _log;
        private readonly IBlockchainService _blockchainService;
        private readonly IBalanceService<BalanceObservation, AddressBalance> _balanceService;

        private const int pageSize = 10;

        public BalanceRefreshJob(ILog log, IBlockchainService blockchainService, IBalanceService<BalanceObservation, AddressBalance> balanceService)
        {
            _log = log;
            _blockchainService = blockchainService;
            _balanceService = balanceService;
        }

        [TimerTrigger("00:00:10")]
        public async Task RefreshBalances()
        {
            await _log.WriteInfoAsync(nameof(BalanceRefreshJob), $"Env: {Program.EnvInfo}", "Refresh balances start", DateTime.Now);
            (string continuation, IEnumerable<BalanceObservation> items) balancesObservation;
            string continuation = null;

            do
            {
                balancesObservation = await _balanceService.GetBalancesObservation(pageSize, continuation);

                continuation = balancesObservation.continuation;

                foreach (KeyValuePair<string, string> balance in await _blockchainService.GetAddressBalances(balancesObservation.items.Select(x => x.Address)))
                {
                    await _balanceService.AddBalance(new AddressBalance {
                        Address = balance.Key,
                        Balance = balance.Value
                    });
                };
            } while (continuation != null);
            await _log.WriteInfoAsync(nameof(BalanceRefreshJob), $"Env: {Program.EnvInfo}", "Refresh balances finished", DateTime.Now);
        }
    }
}
