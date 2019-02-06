using KrisMyAss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrisMyAss.Processors
{
    public interface IProcessor
    {
        Task Process(MessageEnvelope env);
    }
}
