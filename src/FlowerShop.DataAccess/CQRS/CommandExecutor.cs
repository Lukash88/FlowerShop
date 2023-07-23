using FlowerShop.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly FlowerShopStorageContext context;

        public CommandExecutor(FlowerShopStorageContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
