using EnergyCompany.Domain.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyCompany.Domain.Models
{
    public class Endpoint : IEndpoint
    {
        #region Constructor
        public Endpoint() { }
        #endregion

        #region Properties
        public string EndpointSerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public int SwitchState { get; set; }

        public static List<Endpoint> endpoints = new List<Endpoint>();
        #endregion

        #region Methods
        public bool EndpointAlreadyExists(string serialNumber)
        {
            var serialNumberList = endpoints.Find(x => x.EndpointSerialNumber == serialNumber);
            if (serialNumberList == null)
                return true;
            else
                return false;

        }
        public bool Save(Endpoint endpoint)
        {
            var serialNumber = EndpointAlreadyExists(endpoint.EndpointSerialNumber);
            if (serialNumber)
            {
                endpoints.Add(endpoint);
                return true;
            }
            else
            {
                throw new Exception("There is already an endpoint registered with this Serial Number " + '\u0022' + endpoint.EndpointSerialNumber + '\u0022');
            }
        }
        public List<Endpoint> ListAll()
        {
            return endpoints;
        }
        public IEnumerable<Endpoint> ListOneBySerialNumber(string serialNumber)
        {
            return endpoints.Where(x => x.EndpointSerialNumber.Equals(serialNumber));
        }
        public bool Delete(string serialNumber)
        {
            if (endpoints.Exists(x => x.EndpointSerialNumber.Equals(serialNumber)))
            {
                endpoints.RemoveAll(x => x.EndpointSerialNumber.Equals(serialNumber));
                return true;
            }
            else
                return false;
        }
        public bool Update(string serialNumber, int switchState)
        {
            if (endpoints.Exists(x => x.EndpointSerialNumber.Equals(serialNumber)))
            {
                var choosenEndpoint = endpoints.Where(x => x.EndpointSerialNumber.Equals(serialNumber));
                foreach (var item in choosenEndpoint)
                    item.SwitchState = switchState;

                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
