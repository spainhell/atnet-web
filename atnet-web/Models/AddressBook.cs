using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace atnet_web.Models
{
    public class AddressBook
    {
        private List<Address> _addresses;
        private static AddressBook Instance;
        private AddressBook()
        {
            LoadXml();
        }

        public static AddressBook GetInstance()
        {
            if (Instance == null) Instance = new AddressBook();
            return Instance;
        }
        public List<Address> GetAddresses()
        {
            return _addresses;
        }
        public void AddAddress(Address address)
        {
            _addresses.Add(address);
            SaveXml();
        }

        public void DeleteAddress(int index)
        {
            _addresses.RemoveAt(index);
            SaveXml();
        }

        public void EditAddress(Address address, int index)
        {
            _addresses[index] = address;
            SaveXml();
        }

        public void SaveXml()
        {
            var xmlDocument = new XDocument();
            var root = new XElement("root");
            xmlDocument.Add(root);

            foreach (Address address in _addresses)
            {
                var xmlAddress = new XElement("address");
                xmlAddress.Add(new XElement("Name", address.Name));
                xmlAddress.Add(new XElement("Street", address.Street));
                xmlAddress.Add(new XElement("City", address.City));
                xmlAddress.Add(new XElement("ZipCode", address.ZipCode));
                root.Add(xmlAddress);
            }

            xmlDocument.Save("addressbook.xml");
        }

        public void LoadXml()
        {
            _addresses = new List<Address>();
            try
            {
                var xmlDocument = XDocument.Load("addressbook.xml");
                foreach (XElement address in xmlDocument.Root.Nodes())
                {
                    try
                    {
                        Address newAddress = new Address()
                        {
                            Name = address.Element("Name").Value,
                            Street = address.Element("Street").Value,
                            City = address.Element("City").Value,
                            ZipCode = address.Element("ZipCode").Value
                        };
                        _addresses.Add(newAddress);
                    }
                    catch (NullReferenceException nre)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                // zaloguj ex
            }

        }
    }
}
