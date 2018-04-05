﻿using Lykke.Service.RaiblocksApi.Core.Domain.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Core.Repositories.Transactions
{
    public interface ITransactionBodyRepository<TTransactionBody> : IRepository<TTransactionBody>
        where TTransactionBody : ITransactionBody
    {
    }
}