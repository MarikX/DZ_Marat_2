using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement myPerson = new XElement("Person");
            Console.Write("Введите имя клиента: ");
            XAttribute xPerson = new XAttribute("Name", Console.ReadLine());
            myPerson.Add(xPerson);

            XElement myAddres = new XElement("Addres");

            XElement myStreet = new XElement("Street");
            Console.Write("Введите улицу проживания: ");
            myStreet.Add(Console.ReadLine());

            XElement myHouseNumber = new XElement("HouseNumber");
            Console.Write("Введите номер дома: ");
            myHouseNumber.Add(Console.ReadLine());

            XElement myFlatNumber = new XElement("FlatNumber");
            Console.Write("Введите номер квартиры: ");
            myFlatNumber.Add(Console.ReadLine());

            XElement myPhones = new XElement("Phones");

            XElement myMobilePhone = new XElement("MobilePhone");
            Console.Write("Введите мобильный номер телефона: ");
            myMobilePhone.Add(Console.ReadLine());

            XElement myFlatPhone = new XElement("FlatPhone");
            Console.Write("Введите домашний номер телефона: ");
            myFlatPhone.Add(Console.ReadLine());

            myPerson.Add(myAddres);
            myAddres.Add(myStreet);
            myAddres.Add(myHouseNumber);
            myAddres.Add(myFlatNumber);

            myPerson.Add(myPhones);
            myPhones.Add(myMobilePhone);
            myPhones.Add(myFlatPhone);


            myPerson.Save("_Person.xml");
        }
    }
}
