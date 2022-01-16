using EnergyCompany.Domain.Models;
using System.Collections.Generic;

namespace EnergyCompany.Domain.InterfacesRepository
{
    public interface IEndpoint
    {
        bool Save(Endpoint endpoint);
        List<Endpoint> ListAll();
        IEnumerable<Endpoint> ListOneBySerialNumber(string serialNumber);
        bool Delete(string serialNumber);
        bool Update(string serialNumber, int switchState);
    }
}
