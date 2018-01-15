using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAl;
using System.Reflection;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System.ComponentModel;

namespace BL
{
    public class BL_imp : IBL
    {
        protected BL_imp() { }
        protected static BL_imp BLinstance = null;
        public static BL_imp GetInstance()
        {
            if (BLinstance == null)
                BLinstance = new BL_imp();
            return BLinstance;
        }
        static Idal instance = new DAL_imp_XML();
        #region Nanny Fonctions

        public void addNanny(Nanny n)
        {
            if (instance.NannyList().Exists(x => x.ID == n.ID))
                return;
            DateTime t = n.birthday;
            t.AddYears(18);
            if (DateTime.Compare(DateTime.Today, t) >= 0)
                instance.AddNanny(n);
            else
                throw new Exception("you are enter a low age");
        }
        public void removeNanny(int id)
        {
            Nanny toRemove = getNanny().Find(x => x.ID == id);
            if (toRemove != null)
                instance.RemoveNanny(toRemove.ID);
        }
        public void updateNanny(Nanny n, UpdateNanny update)
        {
            Nanny newNanny = n;
            bool b;
            switch (update)
            {
                case UpdateNanny.name:
                    Console.WriteLine("enter your new first name ");
                    string Fname = Console.ReadLine();
                    Console.WriteLine("enter your new Last name ");
                    string Lname = Console.ReadLine();
                    newNanny.name = new Name(Fname, Lname);
                    break;
                case UpdateNanny.cellPhone:
                    Console.WriteLine("enter your new number");
                    int newNumber = int.Parse(Console.ReadLine());
                    newNanny.cellPhone = newNumber;
                    break;
                case UpdateNanny.address:
                    Console.WriteLine("enter your new Address");
                    string newAddress = Console.ReadLine();
                    newNanny.address = newAddress;//Warning. its possible enter address that not correctly in GoogleMaps
                    break;
                case UpdateNanny.elevator:
                    //aytomotic change
                    b = newNanny.elevator;
                    newNanny.elevator = false == b;
                    break;
                case UpdateNanny.floor:
                    Console.WriteLine("enter your floor");
                    int newFloor = int.Parse(Console.ReadLine());
                    newNanny.floor = newFloor;
                    break;
                case UpdateNanny.MinAge:
                    Console.WriteLine("enter update");
                    int minAge = int.Parse(Console.ReadLine());
                    newNanny.MinAge = minAge;
                    break;
                case UpdateNanny.MaxAge:
                    Console.WriteLine("enter update");
                    int maxAge = int.Parse(Console.ReadLine());
                    newNanny.MaxAge = maxAge;
                    break;
                case UpdateNanny.PerHour:
                    //automotic change
                    b = newNanny.PerHour;
                    newNanny.PerHour = false == b;
                    break;
                case UpdateNanny.SallaryPerHour:
                    Console.WriteLine("enter your new Sallary");
                    int sallary = int.Parse(Console.ReadLine());
                    newNanny.SallaryPerHour = sallary;
                    break;
                case UpdateNanny.WeeklyHours:
                    //do something
                    break;
                case UpdateNanny.DaysOff:
                    //aytomotic change
                    b = newNanny.DaysOff;
                    newNanny.DaysOff = false == b;
                    break;
                case UpdateNanny.Recommendations:
                    Console.WriteLine("enter your new Recommendation ");
                    string Rec = Console.ReadLine();
                    newNanny.Recommendations = Rec;
                    break;
            }
            instance.UpdateNanny(newNanny);
        }
        public void updateNanny(Nanny n)
        {
            removeNanny(n.ID);
            addNanny(n);
        }

        public List<Nanny> getNanny()
        {
            return instance.NannyList();
        }
        #endregion Nanny Fonctions
        #region Mother fonctions
        public void addMother(Mother m)
        {
            instance.AddMother(m);
        }
        public void removeMother(int id)
        {
            Mother toRemove = getMother().Find(x => x.ID == id);
            if (toRemove != null)
                instance.RemoveMother(toRemove.ID);
        }
        public void updateMother(Mother m, UpdateMother update)
        {
            Mother newMother = m;
            bool b;
            switch (update)
            {
                case UpdateMother.name:
                    Console.WriteLine("enter your new first name ");
                    string Fname = Console.ReadLine();
                    Console.WriteLine("enter your new Last name ");
                    string Lname = Console.ReadLine();
                    newMother.name = new Name(Fname, Lname);
                    break;
                case UpdateMother.cellPhone:
                    Console.WriteLine("enter your new number");
                    int newNumber = int.Parse(Console.ReadLine());
                    newMother.cellPhone = newNumber;
                    break;
                case UpdateMother.address:
                    Console.WriteLine("enter your new Address");
                    string newAddress = Console.ReadLine();
                    newMother.address = newAddress;//Warning. its possible enter address that not correctly in GoogleMaps
                    break;
                case UpdateMother.location:
                    Console.WriteLine("enter your new location");
                    string newLocation = Console.ReadLine();
                    newMother.location = newLocation;//Warning. its possible enter address that not correctly in GoogleMaps
                    break;
                case UpdateMother.WeeklyHours:
                    //do something
                    break;
                case UpdateMother.remarks:
                    Console.WriteLine("enter your new Recommendation ");
                    string Rem = Console.ReadLine();
                    newMother.remarks = Rem;
                    break;
            }
            instance.UpdateMother(newMother);
        }
        public List<Mother> getMother()
        {
            return instance.MotherList(); ;
        }
        #endregion Mother fonctions
        #region child fonctions
        public void addChild(Child c)
        {
            instance.AddChild(c);
        }
        public void removeChild(int id)
        {
            Child toRemove = getChild().Find(x => x.ID == id);
            if (toRemove != null)
                instance.RemoveChild(toRemove.ID);
        }

        public void updateChild(Child c, UpdateChild update)
        {
            Child newChild = c;
            bool b;
            switch (update)
            {
                case UpdateChild.FirstName:
                    Console.WriteLine("enter new first name ");
                    newChild.FirstName = Console.ReadLine();
                    break;
                case UpdateChild.special:
                    //automotic change
                    b = newChild.special;
                    newChild.special = false == b;
                    break;
                case UpdateChild.specialNeeds:
                    Console.WriteLine("enter special needs ");
                    newChild.specialNeeds = Console.ReadLine();
                    break;
            }
            instance.UpdateChild(newChild);
        }
        public void updateChild(Child c)
        {
            removeChild(c.ID);
            addChild(c);
        }
        public List<Child> getChild()
        {
            return instance.ChildList();
        }
        #endregion child fonctions
        #region contract fonctions
        public bool addContract(Contract c)
        {
            DateTime t = instance.ChildList().Find(y => y.ID == c.idChild).birthday;
            Nanny temp = instance.NannyList().Find(y => y.ID == c.idNanny);
            Child ch = instance.ChildList().Find(y => y.ID == c.idChild);
            t.AddMonths(3);
            if (DateTime.Compare(DateTime.Today, t) >= 0 || temp.myChildren.Count < temp.MaxChildren)
            {
                //update sallary
                if (temp.PerHour)
                {
                    temp.SallaryPerMonth = temp.SallaryPerHour * 4 * temp.wh.sumOfHours;
                    c.PMorPH = false;
                }
                c.SallaryPerMonth = temp.SallaryPerMonth;
                if (temp.myChildren != null)
                {
                    IEnumerable<Child> arr1 = temp.myChildren;
                    IEnumerable<Child> arr2 = from Child item in arr1
                                              where item.idMother == ch.idMother
                                              select item;
                    foreach (var item in arr2)
                        c.SallaryPerMonth *= 0.98;
                }
                c.wh = getMother().Find(x => x.ID == ch.idMother).wh;
                Random r = new Random();
                int code = 0;
                do
                {
                    code = r.Next(500000000,599999999);
                } while (getContract().Exists(x => x.code == code));
                c.code = code;
                instance.AddContract(c);
                //update the changes
                if (temp.myChildren == null)
                    temp.myChildren = new List<Child>();
                temp.myChildren.Add(ch);
            }
            return true;
        }
        public void removeContract(int code)
        {
            Contract toRemove = getContract().Find(x => x.code == code);
            if (toRemove != null)
                instance.RemoveChild(toRemove.code);
        }

        public void updateContract(Contract c, UpdateContract update)
        {
            Contract newContract = c;
            bool b;
            switch (update)
            {
                case UpdateContract.meeting:
                    //automotic change
                    b = newContract.IntroductoryMeeting;
                    newContract.IntroductoryMeeting = false == b;
                    break;
                case UpdateContract.PMorPH:
                    //automotic change
                    b = newContract.PMorPH;
                    newContract.PMorPH = false == b;
                    break;
                case UpdateContract.signed:
                    //automotic change
                    b = newContract.signed;
                    newContract.signed = false == b;
                    break;
                case UpdateContract.SallaryPerHour:
                    Console.WriteLine("enter the new Salary per Hour");
                    newContract.SallaryPerHour = Convert.ToInt32(Console.ReadLine());
                    break;
                case UpdateContract.SallaryPerMonths:
                    Console.WriteLine("enter the new Salary per Months");
                    newContract.SallaryPerMonth = Convert.ToInt32(Console.ReadLine());
                    break;
                case UpdateContract.WeeklyHours:
                    //do something
                    break;
            }
            instance.UpdateContract(newContract);
        }
        public List<Contract> getContract()
        {
            return instance.ContractList();
        }



        #endregion contract fonctions   




        public void AddRecommendation(int id, string r)
        {
            Nanny yourNanny = instance.NannyList().Find(x => x.ID == id);
            if (yourNanny == null)
                throw new Exception("the name don't exsist");
            removeNanny(yourNanny.ID);
            yourNanny.Recommendations = r;
            addNanny(yourNanny);
        }
  




        public int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            // Console.WriteLine(source);
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);

            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        //private int getDistance(Nanny d, Mother s)
        //{
        //    // using backgroundworker to hold google maps ...
        //    // The parameters you want to pass to the do work event of the background worker.
        //    List<object> arguments = new List<object> { s, d };
        //    int result = 0;
        //    BackgroundWorker worker = new BackgroundWorker();
        //    worker.DoWork += doGoogleMapsWork;
        //    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(doGoogleMapsWorkCompleted);
        //    // This runs the event on new background worker thread.
        //    worker.RunWorkerAsync(arguments);
        //    return result;
        //}
        //public List<Nanny> Nanny_In_Range(Mother m)
        //{
        //    List<Nanny> ans = new List<Nanny>();
        //    string ad = m.address;
        //    //Console.WriteLine(ad);
        //    foreach (Nanny n in DataSource.NannyList)
        //    {
        //        string nan = n.address;
        //        // Console.WriteLine(nan);

        //        // using backgroundworker to hold google maps ...
        //        // The parameters you want to pass to the do work event of the background worker.
        //        List<String> arguments = new List<string> { ad, nan };

        //        BackgroundWorker worker = new BackgroundWorker();
        //        worker.DoWork += doGoogleMapsWork;
        //        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(doGoogleMapsWorkCompleted);
        //        //worker.
        //        // This runs the event on new background worker thread.
        //        worker.RunWorkerAsync(arguments);
        //        //if (this.nannyInRange <= m.Range)
        //        ans.Add(n);
        //    }
        //    return ans;
        //}

        //public void doGoogleMapsWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled == true)
        //    {
        //    }
        //    else if (e.Error != null)
        //    {
        //    }
        //    else
        //    {
        //        // e.ToString();
        //        Convert.ToInt32(e.Result);
        //        // nannyInRange = (float)result;
        //    }
        //}

        //public void doGoogleMapsWork(object sender, DoWorkEventArgs e)
        //{
        //    List<string> args = e.Argument as List<string>;

        //    var drivingDirectionRequest = new DirectionsRequest
        //    {
        //        TravelMode = TravelMode.Walking,
        //        Origin = args[0],
        //        Destination = args[1]
        //    };
        //    DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
        //    Route route = drivingDirections.Routes.First();
        //    Leg leg = route.Legs.First();
        //    e.Result = leg.Distance.Value;
        //}
    }
}