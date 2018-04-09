using GT86Registry.Core.Entities;
using System.Collections.Generic;

namespace GT86Registry.Core.Interfaces
{
    public interface ITransmissionService
    {
        IEnumerable<Transmission> GetTransmissionOptionsForModel(int year, string model);

        IEnumerable<Transmission> GetTransmissionOptionsForModel(Model model);
    }
}