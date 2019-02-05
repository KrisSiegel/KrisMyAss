using KrisMyAss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrisMyAss.Commands
{
    public interface ICommand
    {
        Task Execute(MessageEnvelope env);
    }
}
