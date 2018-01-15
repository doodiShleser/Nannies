using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum UpdateNanny
    {
        exit, name, cellPhone, address, elevator, floor, MaxChildren, MinAge, MaxAge,
        PerHour, SallaryPerHour, SallaryPerMonths, WeeklyHours, DaysOff, Stars, PeopleThatRating, Recommendations
    }
    public enum UpdateMother { exit, name, cellPhone, address, location, WeeklyHours, remarks }
    public enum UpdateChild { exit, FirstName, special, specialNeeds }
    public enum UpdateContract { exit, meeting, signed, WeeklyHours, PMorPH, SallaryPerHour, SallaryPerMonths }
    public enum TypeObject { exit, mannager, nanny, mother, child }

}