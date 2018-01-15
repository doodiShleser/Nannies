using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using System.IO;

namespace DAl
{
    public class DAL_imp_XML : Idal
    {
        XElement NannyRoot;
        string NannyPath = @"NannyXml.xml";
        XElement MotherRoot;
        string MotherPath = @"MotherXml.xml";
        XElement ChildRoot;
        string ChildPath = @"ChildXml.xml";
        XElement ContractRoot;
        string ContractPath = @"ContractXml.xml";
        public DAL_imp_XML()
        {
            if (!File.Exists(MotherPath))
                MCreateFiles();
            else
                MLoadData();
            if (!File.Exists(NannyPath))
                NCreateFiles();
            else
                NLoadData();
            if (!File.Exists(ChildPath))
                CCreateFiles();
            else
                CLoadData();
            if (!File.Exists(ContractPath))
                ConCreateFiles();
            else
                ConLoadData();
        }

        private void MCreateFiles()
        {
            MotherRoot = new XElement("mothers");
            MotherRoot.Save(MotherPath);
        }
        private void MLoadData()
        {
            try
            {
                MotherRoot = XElement.Load(MotherPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        private void NCreateFiles()
        {
            NannyRoot = new XElement("nannies");
            NannyRoot.Save(NannyPath);
        }
        private void NLoadData()
        {
            try
            {
                NannyRoot = XElement.Load(NannyPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        private void CLoadData()
        {
            try
            {
                ChildRoot = XElement.Load(ChildPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private void CCreateFiles()
        {
            ChildRoot = new XElement("childs");
            ChildRoot.Save(ChildPath);
        }

        private void ConCreateFiles()
        {
            ContractRoot = new XElement("contracts");
            ContractRoot.Save(ContractPath);
        }
        private void ConLoadData()
        {
            try
            {
                ContractRoot = XElement.Load(ContractPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }



        public List<Nanny> NannyList()
        {
            NLoadData();
            List<Nanny> Nannies;
            try
            {

                Nannies = (from p in NannyRoot.Elements()
                           select new Nanny()
                           {
                               ID = Convert.ToInt32(p.Element("id").Value),
                               name = new Name(p.Element("name").Element("FirstName").Value,
                                               p.Element("name").Element("LastName").Value),
                               address = p.Element("address").Value,
                               birthday = new DateTime(Convert.ToInt32(p.Element("birthday").Element("year").Value),
                                                       Convert.ToInt32(p.Element("birthday").Element("month").Value),
                                                       Convert.ToInt32(p.Element("birthday").Element("day").Value)),
                               cellPhone = Convert.ToInt32(p.Element("cellPhone").Value),
                               elevator = Convert.ToBoolean(p.Element("elevator").Value),
                               floor = Convert.ToInt32(p.Element("floor").Value),
                               Expirence = Convert.ToInt32(p.Element("Expirence").Value),
                               MinAge = Convert.ToInt32(p.Element("MinAge").Value),
                               MaxAge = Convert.ToInt32(p.Element("MaxAge").Value),
                               MaxChildren = Convert.ToInt32(p.Element("MaxChildren").Value),
                               PerHour = Convert.ToBoolean(p.Element("PerHour").Value),
                               SallaryPerHour = Convert.ToInt32(p.Element("SallaryPerHour").Value),
                               SallaryPerMonth = Convert.ToInt32(p.Element("SallaryPerMonth").Value),
                               DaysOff = Convert.ToBoolean(p.Element("DatsOff").Value),
                               Recommendations = p.Element("Recommendations").Value,
                               Stars = Convert.ToInt32(p.Element("Stars").Value),
                               peopleThatRating = Convert.ToInt32(p.Element("PeopleThatRating").Value),
                               wh = new WeeklyHours(new DayWork[]
                               {
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("end").Value))
                             }),
                           }).ToList();
            }
            catch
            {
                Nannies = null;
            }
            return Nannies;
        }
        public Nanny FindNanny(int id)
        {
            NLoadData();
            Nanny nanny;
            try
            {
                nanny = (from p in NannyRoot.Elements()
                         where Convert.ToInt32(p.Element("id").Value) == id
                         select new Nanny()
                         {
                             ID = Convert.ToInt32(p.Element("id").Value),
                             name = new Name(p.Element("name").Element("FirstName").Value,
                                               p.Element("name").Element("LastName").Value),
                             address = p.Element("address").Value,
                             birthday = new DateTime(Convert.ToInt32(p.Element("birthday").Element("year").Value),
                                                       Convert.ToInt32(p.Element("birthday").Element("month").Value),
                                                       Convert.ToInt32(p.Element("birthday").Element("day").Value)),
                             cellPhone = Convert.ToInt32(p.Element("cellPhone").Value),
                             elevator = Convert.ToBoolean(p.Element("elevator").Value),
                             floor = Convert.ToInt32(p.Element("floor").Value),
                             Expirence = Convert.ToInt32(p.Element("Expirence").Value),
                             MinAge = Convert.ToInt32(p.Element("MinAge").Value),
                             MaxAge = Convert.ToInt32(p.Element("MaxAge").Value),
                             MaxChildren = Convert.ToInt32(p.Element("MaxChildren").Value),
                             PerHour = Convert.ToBoolean(p.Element("PerHour").Value),
                             SallaryPerHour = Convert.ToInt32(p.Element("SallaryPerHour").Value),
                             SallaryPerMonth = Convert.ToInt32(p.Element("SallaryPerMonth").Value),
                             DaysOff = Convert.ToBoolean(p.Element("DatsOff").Value),
                             Stars = Convert.ToInt32(p.Element("Stars").Value),
                             peopleThatRating = Convert.ToInt32(p.Element("PeopleThatRating").Value),
                             Recommendations = p.Element("Recommendations").Value,
                             wh = new WeeklyHours(new DayWork[]
                               {
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("end").Value))
                             }),
                         }).FirstOrDefault();
            }
            catch
            {
                nanny = null;
            }
            return nanny;
        }
        public void AddNanny(Nanny nnn)
        {
            Nanny n = nnn;
            XElement id = new XElement("id", n.ID);
            XElement name = new XElement(new XElement("name", new XElement("FirstName", n.name.FirstName),
                                                              new XElement("LastName", n.name.LastName)));
            XElement birthday = new XElement("birthday", new XElement("year", n.birthday.Year),
                                                         new XElement("month", n.birthday.Month),
                                                         new XElement("day", n.birthday.Day));
            XElement address = new XElement("address", n.address);
            XElement cellPhone = new XElement("cellPhone", n.cellPhone);
            XElement elevator = new XElement("elevator", n.elevator);
            XElement floor = new XElement("floor", n.floor);
            XElement Expirence = new XElement("Expirence", n.Expirence);
            XElement MinAge = new XElement("MinAge", n.MinAge);
            XElement MaxAge = new XElement("MaxAge", n.MaxAge);
            XElement MaxChildren = new XElement("MaxChildren", n.MaxChildren);
            XElement PerHour = new XElement("PerHour", n.PerHour);
            XElement SallaryPerHour = new XElement("SallaryPerHour", n.SallaryPerHour);
            XElement SallaryPerMonth = new XElement("SallaryPerMonth", n.SallaryPerMonth);
            XElement DaysOff = new XElement("DatsOff", n.DaysOff);
            XElement Stars = new XElement("Stars", n.Stars);
            XElement PeopleThatRating = new XElement("PeopleThatRating", n.peopleThatRating);
            XElement Recommendations = new XElement("Recommendations", n.Recommendations);
            XElement dayWork1 = new XElement("DayWork1", new XElement("begin", n.wh.WorkHours[0].begin),
                                                       new XElement("end", n.wh.WorkHours[0].end));
            XElement dayWork2 = new XElement("DayWork2", new XElement("begin", n.wh.WorkHours[1].begin),
                                                      new XElement("end", n.wh.WorkHours[1].end));
            XElement dayWork3 = new XElement("DayWork3", new XElement("begin", n.wh.WorkHours[2].begin),
                                                      new XElement("end", n.wh.WorkHours[2].end));
            XElement dayWork4 = new XElement("DayWork4", new XElement("begin", n.wh.WorkHours[3].begin),
                                                      new XElement("end", n.wh.WorkHours[3].end));
            XElement dayWork5 = new XElement("DayWork5", new XElement("begin", n.wh.WorkHours[4].begin),
                                                   new XElement("end", n.wh.WorkHours[4].end));
            XElement dayWork6 = new XElement("DayWork6", new XElement("begin", n.wh.WorkHours[5].begin),
                                                   new XElement("end", n.wh.WorkHours[5].end));
            XElement wh = new XElement("WeeklyHours", new XElement[]{
            new XElement("DayWork1", dayWork1),
            new XElement("DayWork2", dayWork2),
            new XElement("DayWork3", dayWork3),
            new XElement("DayWork4", dayWork4),
            new XElement("DayWork5", dayWork5),
            new XElement("DayWork6", dayWork6)
        });
            NannyRoot.Add(new XElement("nanny", id, name, birthday, address, cellPhone, elevator, floor, Expirence, MinAge, MaxAge, MaxChildren,
                PerHour, SallaryPerHour, SallaryPerMonth, DaysOff, Recommendations, wh, PeopleThatRating, Stars));
            NannyRoot.Save(NannyPath);
        }
        public bool RemoveNanny(int id)
        {
            XElement NannyElement;
            try
            {
                NannyElement = (from p in NannyRoot.Elements()
                                where Convert.ToInt32(p.Element("id").Value) == id
                                select p).FirstOrDefault();
                NannyElement.Remove();
                NannyRoot.Save(NannyPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void UpdateNanny(Nanny n)
        {
            XElement NannyElement = (from p in NannyRoot.Elements()
                                     where Convert.ToInt32(p.Element("id").Value) == n.ID
                                     select p).FirstOrDefault();
            NannyElement.Element("name").Element("FirstName").Value = n.name.FirstName;
            NannyElement.Element("name").Element("LastName").Value = n.name.LastName;
            NannyElement.Element("address").Value = n.address;
            NannyElement.Element("birthday").Element("year").Value = n.birthday.Year.ToString();
            NannyElement.Element("birthday").Element("month").Value = n.birthday.Month.ToString();
            NannyElement.Element("birthday").Element("day").Value = n.birthday.Day.ToString();
            NannyElement.Element("cellPhone").Value = n.cellPhone.ToString();
            NannyElement.Element("elevator").Value = n.elevator.ToString();
            NannyElement.Element("floor").Value = n.floor.ToString();
            NannyElement.Element("Expirence").Value = n.Expirence.ToString();
            NannyElement.Element("MinAge").Value = n.MinAge.ToString();
            NannyElement.Element("MaxAge").Value = n.MaxAge.ToString();
            NannyElement.Element("MaxChildren").Value = n.MaxChildren.ToString();
            NannyElement.Element("PerHour").Value = n.PerHour.ToString();
            NannyElement.Element("SallaryPerHour").Value = n.SallaryPerHour.ToString();
            NannyElement.Element("SallaryPerMonth").Value = n.SallaryPerMonth.ToString();
            NannyElement.Element("DatsOff").Value = n.DaysOff.ToString();
            NannyElement.Element("Stars").Value = n.Stars.ToString();
            NannyElement.Element("PeopleThatRating").Value = n.peopleThatRating.ToString();
            NannyElement.Element("Recommendations").Value = n.Recommendations;
            for (int i = 1; i <= 6; i++)
            {
                NannyElement.Element("WeeklyHours").Element("DayWork" + i).Element("DayWork" + i).Element("begin").Value = n.wh.WorkHours[i - 1].begin.ToString();
                NannyElement.Element("WeeklyHours").Element("DayWork" + i).Element("DayWork" + i).Element("end").Value = n.wh.WorkHours[i - 1].end.ToString();
            }

            NannyRoot.Save(NannyPath);
        }

        public List<Mother> MotherList()
        {
            MLoadData();
            List<Mother> Mothers;
            try
            {

                Mothers = (from p in MotherRoot.Elements()
                           select new Mother()
                           {
                               ID = Convert.ToInt32(p.Element("id").Value),
                               name = new Name(p.Element("name").Element("FirstName").Value,
                                               p.Element("name").Element("LastName").Value),
                               address = p.Element("address").Value,
                               location = p.Element("Location").Value,
                               cellPhone = Convert.ToInt32(p.Element("cellPhone").Value),
                               remarks = p.Element("Remarks").Value,
                               wh = new WeeklyHours(new DayWork[]
                               {
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("end").Value)),
                                    new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("begin").Value),
                                                Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("end").Value))
                             }),
                           }).ToList();
            }
            catch
            {
                Mothers = null;
            }
            return Mothers;
        }
        public void AddMother(Mother mm)
        {
            Mother m = mm;
            XElement id = new XElement("id", m.ID);
            XElement name = new XElement(new XElement("name", new XElement("FirstName", m.name.FirstName),
                                                              new XElement("LastName", m.name.LastName)));
            XElement address = new XElement("address", m.address);
            XElement location = new XElement("Location", m.address);
            XElement cellPhone = new XElement("cellPhone", m.cellPhone);
            XElement remarks = new XElement("Remarks", m.remarks);
            XElement dayWork1 = new XElement("DayWork1", new XElement("begin", m.wh.WorkHours[0].begin),
                                                       new XElement("end", m.wh.WorkHours[0].end));
            XElement dayWork2 = new XElement("DayWork2", new XElement("begin", m.wh.WorkHours[1].begin),
                                                      new XElement("end", m.wh.WorkHours[1].end));
            XElement dayWork3 = new XElement("DayWork3", new XElement("begin", m.wh.WorkHours[2].begin),
                                                      new XElement("end", m.wh.WorkHours[2].end));
            XElement dayWork4 = new XElement("DayWork4", new XElement("begin", m.wh.WorkHours[3].begin),
                                                      new XElement("end", m.wh.WorkHours[3].end));
            XElement dayWork5 = new XElement("DayWork5", new XElement("begin", m.wh.WorkHours[4].begin),
                                                   new XElement("end", m.wh.WorkHours[4].end));
            XElement dayWork6 = new XElement("DayWork6", new XElement("begin", m.wh.WorkHours[5].begin),
                                                   new XElement("end", m.wh.WorkHours[5].end));
            XElement wh = new XElement("WeeklyHours", new XElement[]{
            new XElement("DayWork1", dayWork1),
            new XElement("DayWork2", dayWork2),
            new XElement("DayWork3", dayWork3),
            new XElement("DayWork4", dayWork4),
            new XElement("DayWork5", dayWork5),
            new XElement("DayWork6", dayWork6)
        });
            MotherRoot.Add(new XElement("mother", id, name, location, address, cellPhone, remarks, wh));
            MotherRoot.Save(MotherPath);
        }
        public bool RemoveMother(int id)
        {
            XElement NannyElement;
            try
            {
                NannyElement = (from p in MotherRoot.Elements()
                                where Convert.ToInt32(p.Element("id").Value) == id
                                select p).FirstOrDefault();
                NannyElement.Remove();
                MotherRoot.Save(MotherPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void UpdateMother(Mother m)
        {
            XElement NannyElement = (from p in MotherRoot.Elements()
                                     where Convert.ToInt32(p.Element("id").Value) == m.ID
                                     select p).FirstOrDefault();
            NannyElement.Element("name").Element("FirstName").Value = m.name.FirstName;
            NannyElement.Element("name").Element("LastName").Value = m.name.LastName;
            NannyElement.Element("address").Value = m.address;
            NannyElement.Element("Location").Value = m.location;
            NannyElement.Element("Remarks").Value = m.remarks;
            for (int i = 1; i <= 6; i++)
            {
                NannyElement.Element("WeeklyHours").Element("DayWork" + i).Element("DayWork" + i).Element("begin").Value = m.wh.WorkHours[i - 1].begin.ToString();
                NannyElement.Element("WeeklyHours").Element("DayWork" + i).Element("DayWork" + i).Element("end").Value = m.wh.WorkHours[i - 1].end.ToString();
            }

            MotherRoot.Save(MotherPath);
        }

        public List<Child> ChildList()
        {
            CLoadData();
            List<Child> Childs;
            try
            {
                Childs = (from p in ChildRoot.Elements()
                          select new Child()
                          {
                              ID = Convert.ToInt32(p.Element("id").Value),
                              idMother = Convert.ToInt32(p.Element("idMother").Value),
                              FirstName = p.Element("FirstName").Value,
                              birthday = new DateTime(Convert.ToInt32(p.Element("birthday").Element("year").Value),
                                                      Convert.ToInt32(p.Element("birthday").Element("month").Value),
                                                      Convert.ToInt32(p.Element("birthday").Element("day").Value)),
                              special = Convert.ToBoolean(p.Element("Special").Value),
                              specialNeeds = p.Element("SpecialNeeds").Value,
                              stars = Convert.ToInt32(p.Element("Stars").Value),
                              recomendationsNanny = p.Element("RecomendationsNanny").Value,
                          }).ToList();
            }
            catch
            {
                Childs = null;
            }
            return Childs;
        }
        public void AddChild(Child cc)
        {
            Child c = cc;
            XElement id = new XElement("id", c.ID);
            XElement idMother = new XElement("idMother", c.idMother);
            XElement FirstName = new XElement("FirstName", c.FirstName);
            XElement birthday = new XElement("birthday", new XElement("year", c.birthday.Year),
                                                         new XElement("month", c.birthday.Month),
                                                         new XElement("day", c.birthday.Day));
            XElement special = new XElement("Special", c.special);
            XElement specialNeeds = new XElement("SpecialNeeds", c.specialNeeds);
            XElement stars = new XElement("Stars", c.stars);
            XElement recomendationsNanny = new XElement("RecomendationsNanny", c.recomendationsNanny);
            ChildRoot.Add(new XElement("child", id, idMother, birthday, FirstName, special, specialNeeds, recomendationsNanny,stars));
            ChildRoot.Save(ChildPath);
        }
        public bool RemoveChild(int id)
        {
            XElement ChildElement;
            try
            {
                ChildElement = (from p in ChildRoot.Elements()
                                where Convert.ToInt32(p.Element("id").Value) == id
                                select p).FirstOrDefault();
                ChildElement.Remove();
                ChildRoot.Save(ChildPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void UpdateChild(Child c)
        {
            XElement ChildElement = (from p in ChildRoot.Elements()
                                     where Convert.ToInt32(p.Element("id").Value) == c.ID
                                     select p).FirstOrDefault();
            ChildElement.Element("FirstName").Value = c.FirstName;
            ChildElement.Element("birthday").Element("year").Value = c.birthday.Year.ToString();
            ChildElement.Element("birthday").Element("month").Value = c.birthday.Month.ToString();
            ChildElement.Element("birthday").Element("day").Value = c.birthday.Day.ToString();
            ChildElement.Element("Special").Value = c.special.ToString();
            ChildElement.Element("SpecialNeeds").Value = c.specialNeeds;
            ChildElement.Element("Stars").Value = c.stars.ToString();
            ChildElement.Element("RecomendationsNanny").Value = c.recomendationsNanny;
            ChildRoot.Save(ChildPath);
        }

        public List<Contract> ContractList()
        {
            ConLoadData();
            List<Contract> Contracts;
            try
            {

                Contracts = (from p in ContractRoot.Elements()
                             select new Contract()
                             {
                                 code = Convert.ToInt32(p.Element("Code").Value),
                                 NameNanny = new Name(p.Element("nameNanny").Element("FirstName").Value,
                                                 p.Element("nameNanny").Element("LastName").Value),
                                 idNanny = Convert.ToInt32(p.Element("idNanny").Value),
                                 idChild = Convert.ToInt32(p.Element("idChild").Value),
                                 beginDeal = new DateTime(Convert.ToInt32(p.Element("beginDeal").Element("year").Value),
                                                         Convert.ToInt32(p.Element("beginDeal").Element("month").Value),
                                                         Convert.ToInt32(p.Element("beginDeal").Element("day").Value)),
                                 endDeal = new DateTime(Convert.ToInt32(p.Element("endDeal").Element("year").Value),
                                                         Convert.ToInt32(p.Element("endDeal").Element("month").Value),
                                                         Convert.ToInt32(p.Element("endDeal").Element("day").Value)),
                                 signed = Convert.ToBoolean(p.Element("signed").Value),
                                 IntroductoryMeeting = Convert.ToBoolean(p.Element("IntroductoryMeeting").Value),
                                 PMorPH = Convert.ToBoolean(p.Element("PMorPH").Value),
                                 SallaryPerHour = Convert.ToDouble(p.Element("SallaryPerHour").Value),
                                 SallaryPerMonth = Convert.ToDouble(p.Element("SallaryPerMonth").Value),
                                 wh = new WeeklyHours(new DayWork[]
                                   {
                                      new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("begin").Value),
                                                  Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork1").Element("DayWork1").Element("end").Value)),
                                      new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("begin").Value),
                                                  Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork2").Element("DayWork2").Element("end").Value)),
                                      new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("begin").Value),
                                                  Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork3").Element("DayWork3").Element("end").Value)),
                                      new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("begin").Value),
                                                  Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork4").Element("DayWork4").Element("end").Value)),
                                      new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("begin").Value),
                                                  Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork5").Element("DayWork5").Element("end").Value)),
                                      new DayWork(Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("begin").Value),
                                                  Clock.ConvertToClock(p.Element("WeeklyHours").Element("DayWork6").Element("DayWork6").Element("end").Value))
                                 }),
                             }).ToList();
            }
            catch
            {
                Contracts = null;
            }
            return Contracts;
        }

        public void AddContract(Contract cc)
        {
            Contract c = cc;
            XElement code = new XElement("Code", c.code);
            XElement beginDeal = new XElement("beginDeal", new XElement("year", c.beginDeal.Year),
                                                         new XElement("month", c.beginDeal.Month),
                                                         new XElement("day", c.beginDeal.Day));
            XElement endDeal = new XElement("endDeal", new XElement("year", c.endDeal.Year),
                                                 new XElement("month", c.endDeal.Month),
                                                 new XElement("day", c.endDeal.Day));
            XElement idChild = new XElement("idChild", c.idChild);
            XElement idNanny = new XElement("idNanny", c.idNanny);
            XElement IntroductoryMeeting = new XElement("IntroductoryMeeting", c.IntroductoryMeeting);
            XElement signed = new XElement("signed", c.signed);
            XElement nameNanny = new XElement("nameNanny", new XElement("FirstName", c.NameNanny.FirstName),
                                                          new XElement("LastName", c.NameNanny.LastName));
            XElement PMorPH = new XElement("PMorPH", c.PMorPH);
            XElement SallaryPerMonth = new XElement("SallaryPerMonth", c.SallaryPerMonth);
            XElement SallaryPerHour = new XElement("SallaryPerHour", c.SallaryPerHour);
            XElement dayWork1 = new XElement("DayWork1", new XElement("begin", c.wh.WorkHours[0].begin),
                                                       new XElement("end", c.wh.WorkHours[0].end));
            XElement dayWork2 = new XElement("DayWork2", new XElement("begin", c.wh.WorkHours[1].begin),
                                                      new XElement("end", c.wh.WorkHours[1].end));
            XElement dayWork3 = new XElement("DayWork3", new XElement("begin", c.wh.WorkHours[2].begin),
                                                      new XElement("end", c.wh.WorkHours[2].end));
            XElement dayWork4 = new XElement("DayWork4", new XElement("begin", c.wh.WorkHours[3].begin),
                                                      new XElement("end", c.wh.WorkHours[3].end));
            XElement dayWork5 = new XElement("DayWork5", new XElement("begin", c.wh.WorkHours[4].begin),
                                                   new XElement("end", c.wh.WorkHours[4].end));
            XElement dayWork6 = new XElement("DayWork6", new XElement("begin", c.wh.WorkHours[5].begin),
                                                   new XElement("end", c.wh.WorkHours[5].end));
            XElement wh = new XElement("WeeklyHours", new XElement[]{
            new XElement("DayWork1", dayWork1),
            new XElement("DayWork2", dayWork2),
            new XElement("DayWork3", dayWork3),
            new XElement("DayWork4", dayWork4),
            new XElement("DayWork5", dayWork5),
            new XElement("DayWork6", dayWork6)
        });
            ContractRoot.Add(new XElement("contract", code, idChild, idNanny, nameNanny, signed,
                IntroductoryMeeting, beginDeal, endDeal, PMorPH, SallaryPerHour, SallaryPerMonth, wh));
            ContractRoot.Save(ContractPath);
        }
        public bool RemoveContract(int code)
        {
            XElement ContractElement;
            try
            {
                ContractElement = (from p in ContractRoot.Elements()
                                   where Convert.ToInt32(p.Element("Code").Value) == code
                                   select p).FirstOrDefault();
                ContractElement.Remove();
                ContractRoot.Save(ContractPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void UpdateContract(Contract c)
        {
            XElement ContractElement = (from p in ContractRoot.Elements()
                                        where Convert.ToInt32(p.Element("id").Value) == c.code
                                        select p).FirstOrDefault();
            ContractElement.Element("NameNanny").Element("FirstName").Value = c.NameNanny.FirstName;
            ContractElement.Element("NameNanny").Element("LastName").Value = c.NameNanny.LastName;
            ContractElement.Element("idChild").Value = c.idChild.ToString();
            ContractElement.Element("idNanny").Value = c.idNanny.ToString();
            ContractElement.Element("beginDeal").Element("year").Value = c.beginDeal.Year.ToString();
            ContractElement.Element("beginDeal").Element("month").Value = c.beginDeal.Month.ToString();
            ContractElement.Element("beginDeal").Element("day").Value = c.beginDeal.Day.ToString();
            ContractElement.Element("endDeal").Element("year").Value = c.endDeal.Year.ToString();
            ContractElement.Element("endDeal").Element("month").Value = c.endDeal.Month.ToString();
            ContractElement.Element("endDeal").Element("day").Value = c.endDeal.Day.ToString();
            ContractElement.Element("signed").Value = c.signed.ToString();
            ContractElement.Element("IntroductoryMeeting").Value = c.IntroductoryMeeting.ToString();
            ContractElement.Element("PMorPH").Value = c.PMorPH.ToString();
            ContractElement.Element("SallaryPerHour").Value = c.SallaryPerHour.ToString();
            ContractElement.Element("SallaryPerMonth").Value = c.SallaryPerMonth.ToString();
            for (int i = 1; i <= 6; i++)
            {
                ContractElement.Element("WeeklyHours").Element("DayWork" + i).Element("DayWork" + i).Element("begin").Value = c.wh.WorkHours[i - 1].begin.ToString();
                ContractElement.Element("WeeklyHours").Element("DayWork" + i).Element("DayWork" + i).Element("end").Value = c.wh.WorkHours[i - 1].end.ToString();
            }

            ContractRoot.Save(ContractPath);
        }

    
    }
}

