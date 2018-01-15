using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public class DefaultInitilize
    {
        static Random r = new Random();
        public DefaultInitilize()
        {
            initilizeArray();
           NannyInitilize();
            MotherInitilize();
            ChildInitilize();
            ContractInitilize();
        }
        static int[] idMotherArray = new int[21];
        static int[] idNannyArray = new int[20];
        static int[] idChildArray = new int[30];

        /// <summary>
        /// initilize 3 araays of id 
        /// </summary>
        void initilizeArray()
        {
            for (int i = 0; i < 30; i++)
                idChildArray[i] = IDCreator(TypeObject.child);
            for (int i = 0; i < 20; i++)
                idNannyArray[i] = IDCreator(TypeObject.nanny);
            for (int i = 0; i < 21; i++)
                idMotherArray[i] = IDCreator(TypeObject.mother);
        }
        /// <summary>
        /// create id for objects ranomaly, 
        /// TypeObject options: nanny,mother,child
        /// </summary>
        int IDCreator(TypeObject type)
        {
            int id = 0;
            switch (type)
            {
                case TypeObject.nanny:
                    do
                    {
                        id = r.Next(200000000, 299999999);
                    } while (Array.Exists(idNannyArray, x => x == id));
                    break;
                case TypeObject.mother:
                    do
                    {
                        id = r.Next(300000000, 399999999);
                    } while (Array.Exists(idMotherArray, x => x == id));
                    break;
                case TypeObject.child:
                    do
                    {
                        id = r.Next(400000000, 499999999);
                    } while (Array.Exists(idChildArray, x => x == id));
                    break;
            }
            return id;
        }

        static IBL instance = BL_imp.GetInstance();//singelton

        /// <summary>
        /// Initilize & addtion to list 20 nannies
        /// </summary>
        void NannyInitilize()
        {
            Nanny Ayala_Zehavi = new Nanny
            {
                ID = idNannyArray[0],
                name = new Name("Ayala", "zehavi"),
                birthday = new DateTime(1980, 5, 19),
                address = "Beit Ha-Defus St 21, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0523433333,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 800,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,15),new Clock(16,20)),
                    new DayWork(new Clock(7,45), new Clock(16,30)),
                    new DayWork(new Clock(7,50),new Clock(15,10)),
                    new DayWork(new Clock(8,30),new Clock(14,30)),
                    new DayWork(new Clock(8,30),new Clock(15,45)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Moria_schneider = new Nanny
            {
                ID = idNannyArray[1],
                name = new Name("Moria", "schneider"),
                birthday = new DateTime(1980, 5, 19),
                address = "Shakhal St 15, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0523433333,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 800,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,0),new Clock(17,30)),
                    new DayWork(new Clock(7,00), new Clock(17,30)),
                    new DayWork(new Clock(7,0),new Clock(17,45)),
                    new DayWork(new Clock(7,0),new Clock(17,30)),
                    new DayWork(new Clock(7,0),new Clock(17,30)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny malki_fishman = new Nanny
            {
                ID = idNannyArray[2],
                name = new Name("malki", "fishman"),
                birthday = new DateTime(1992, 4, 9),
                address = "Bar Ilan St 15, Jerusalem",
                elevator = false,
                floor = 1,
                Expirence = 5,
                cellPhone = 0525633333,
                MaxAge = 17,
                MinAge = 1,
                MaxChildren = 7,
                PerHour = false,
                SallaryPerMonth = 1200,
                DaysOff = true,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(8,00),new Clock(16,45)),
                    new DayWork(new Clock(7,0), new Clock(17,30)),
                    new DayWork(new Clock(7,45),new Clock(16,15)),
                    new DayWork(new Clock(7,30),new Clock(15,30)),
                    new DayWork(new Clock(7,30),new Clock(15,45)),
                    new DayWork(new Clock(8,0),new Clock(12,0))
                }),
                Recommendations = "",
            };
            Nanny Elisheva_Shaked = new Nanny
            {
                ID = idNannyArray[3],
                name = new Name("Elisheva", "Shaked"),
                birthday = new DateTime(1990, 5, 29),
                address = "Amram Gaon St 15, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0523433333,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 800,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(15,40)),
                    new DayWork(new Clock(7,20), new Clock(15,30)),
                    new DayWork(new Clock(7,50),new Clock(15,10)),
                    new DayWork(new Clock(7,40),new Clock(16,30)),
                    new DayWork(new Clock(7,30),new Clock(15,35)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Yafi_Shtain = new Nanny
            {
                ID = idNannyArray[4],
                name = new Name("Yafi", "Shtain"),
                birthday = new DateTime(1995, 1, 8),
                address = "Ha-Rav Pinkhas Kehati St 5, Jerusalem",
                elevator = true,
                floor = 4,
                Expirence = 1,
                cellPhone = 0526754123,
                MaxAge = 18,
                MinAge = 2,
                MaxChildren = 6,
                PerHour = true,
                SallaryPerHour = 12,
                SallaryPerMonth = 800,
                DaysOff = true,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,15),new Clock(16,15)),
                    new DayWork(new Clock(7,30), new Clock(17,0)),
                    new DayWork(new Clock(7,30),new Clock(16,30)),
                    new DayWork(new Clock(7,0),new Clock(16,0)),
                    new DayWork(new Clock(8,0),new Clock(16,30)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Hila_Sharabi = new Nanny
            {
                ID = idNannyArray[5],
                name = new Name("Hila", "Sharabi"),
                birthday = new DateTime(1990, 5, 19),
                address = "Eli'ezrov St 15, Jerusalem",
                elevator = false,
                floor = 0,
                Expirence = 6,
                cellPhone = 0509856634,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonth = 950,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,30)),
                    new DayWork(new Clock(7,30),new Clock(16,30)),
                    new DayWork(new Clock(7,45),new Clock(17,00)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(7,30),new Clock(16,30)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Adi_Shushan = new Nanny
            {
                ID = idNannyArray[6],
                name = new Name("Adi", "Shushan"),
                birthday = new DateTime(1970, 5, 14),
                address = "Ha-Yehudim St 4, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 30,
                cellPhone = 0548435465,
                MaxAge = 24,
                MinAge = 1,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 800,
                DaysOff = false,
                 Stars = 0,
                peopleThatRating=0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,00),new Clock(16,30)),
                    new DayWork(new Clock(7,00),new Clock(16,30)),
                    new DayWork(new Clock(7,00),new Clock(16,30)),
                    new DayWork(new Clock(7,00),new Clock(16,30)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(7,00),new Clock(13,30))
                }),
                Recommendations = "",
            };
            Nanny Chavi_Horen = new Nanny
            {
                ID = idNannyArray[7],
                name = new Name("Chavi", "Horen"),
                birthday = new DateTime(1994, 5, 9),
                address = "Me'a She'arim St 8, Jerusalem",
                elevator = false,
                floor = 2,
                Expirence = 3,
                cellPhone = 0573124354,
                MaxAge = 12,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 11,
                SallaryPerMonth = 1100,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,15),new Clock(15,45)),
                    new DayWork(new Clock(7,30),new Clock(17,30)),
                    new DayWork(new Clock(8,00),new Clock(17,30)),
                    new DayWork(new Clock(7,00),new Clock(17,30)),
                    new DayWork(new Clock(7,00),new Clock(11,30))
                }),
                Recommendations = "",
            };
            Nanny Diti_Farkash = new Nanny
            {
                ID = idNannyArray[8],
                name = new Name("Diti", "Farkash"),
                birthday = new DateTime(1987, 3, 19),
                address = "Ha-Mekhanekhet St 8, Jerusalem",
                elevator = false,
                floor = 2,
                Expirence = 8,
                cellPhone = 0526785431,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 8,
                SallaryPerMonth = 800,
                DaysOff = true,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
               {
                    new DayWork(new Clock(7,30),new Clock(17,00)),
                    new DayWork(new Clock(7,45),new Clock(14,30)),
                    new DayWork(new Clock(8,30),new Clock(17,00)),
                    new DayWork(new Clock(8,00),new Clock(15,00)),
                    new DayWork(new Clock(8,00),new Clock(17,00)),
                    new DayWork(new Clock(7,00),new Clock(12,30))
               }),
                Recommendations = "",
            };
            Nanny noa_Karlibach = new Nanny
            {
                ID = idNannyArray[9],
                name = new Name("noa", "Karlibach"),
                birthday = new DateTime(1984, 8, 19),
                address = "Sulam Ya'akov St 18, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 10,
                cellPhone = 0527612345,
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonth = 1000,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(7,30),new Clock(15,45)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(7,30),new Clock(15,45)),
                    new DayWork(new Clock(7,30),new Clock(15,45)),
                    new DayWork(new Clock(7,00),new Clock(12,30))
                }),
                Recommendations = "",
            };
            Nanny batSheva_Choen = new Nanny
            {
                ID = idNannyArray[10],
                name = new Name("bat-Sheva", "Choen"),
                birthday = new DateTime(1996, 5, 19),
                address = "Yitzchak Mirsky St 8, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 0,
                cellPhone = 0526872034,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 9,
                SallaryPerMonth = 800,
                DaysOff = false,
                 Stars = 0,
                peopleThatRating=0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,00)),
                    new DayWork(new Clock(7,00), new Clock(16,00)),
                    new DayWork(new Clock(7,30),new Clock(17,15)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(7,30),new Clock(16,00)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Mehira_Shulman = new Nanny
            {
                ID = idNannyArray[11],
                name = new Name("Mehira", "Shulman"),
                birthday = new DateTime(1990, 1, 1),
                address = "Bar Ilan St 32, Jerusalem",
                elevator = true,
                floor = 1,
                Expirence = 3,
                cellPhone = 0523421347,
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonth = 900,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(17,0)),
                    new DayWork(new Clock(7,15), new Clock(16,0)),
                    new DayWork(new Clock(7,30),new Clock(16,30)),
                    new DayWork(new Clock(7,15),new Clock(16,0)),
                    new DayWork(new Clock(7,0),new Clock(16,30)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Avigail_Kuk = new Nanny
            {
                ID = idNannyArray[12],
                name = new Name("Avigail", "Kuk"),
                birthday = new DateTime(1990, 5, 12),
                address = "Rabenu Gershom St 32, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0523908761,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 950,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,45)),
                    new DayWork(new Clock(7,15), new Clock(17,0)),
                    new DayWork(new Clock(7,0),new Clock(16,30)),
                    new DayWork(new Clock(7,0),new Clock(16,0)),
                    new DayWork(new Clock(7,0),new Clock(15,30)),
                    new DayWork(new Clock(),new Clock())
                }),
                Recommendations = "",
            };
            Nanny Chani_Yosef = new Nanny
            {
                ID = idNannyArray[13],
                name = new Name("Chani", "Yosef"),
                birthday = new DateTime(1994, 2, 19),
                address = "Sulam Ya'akov St 12, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0526545524,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 800,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(8,0),new Clock(16,0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 30)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0), new Clock(12,30))
                }),
                Recommendations = "",
            };
            Nanny Batya_Adler = new Nanny
            {
                //v
                ID = idNannyArray[14],
                name = new Name("Batya", "Adler"),
                birthday = new DateTime(1990, 7, 13),
                address = "Shakhal St 17, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0525476532,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonth = 650,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(7, 0), new Clock(16, 15)),
                    new DayWork(new Clock(7, 45), new Clock(15, 30)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny lea_Gans = new Nanny
            {
                ID = idNannyArray[15],
                name = new Name("lea", "Gans"),
                birthday = new DateTime(1990, 9, 30),
                address = "Rabenu Gershom St 4, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0527832415,
                MaxAge = 14,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 1000,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(15, 30)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny Miryam_BenHamu = new Nanny
            {
                ID = idNannyArray[16],
                name = new Name("Miryam", "Ben-Hamu"),
                birthday = new DateTime(1985, 5, 19),
                address = "Shmu'el ha-Navi St 17, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 8,
                cellPhone = 0521234983,
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 12,
                SallaryPerMonth = 900,
                DaysOff = false,
                Stars = 0,
                peopleThatRating = 0,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7, 30), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(15, 45)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny Gila_Elmagor = new Nanny
            {
                ID = idNannyArray[17],
                name = new Name("Gila", "Elmagor"),
                birthday = new DateTime(1977, 10, 16),
                address = "Shmu'el ha-Navi St 5, Jerusalem",
                elevator = true,
                floor = 6,
                Expirence = 3,
                cellPhone = 0529876543,
                MaxAge = 12,
                MinAge = 2,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerHour = 10,
                SallaryPerMonth = 800,
                DaysOff = false,
                Stars = 18,
                peopleThatRating = 5,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7, 30), new Clock(16, 0)),
                    new DayWork(new Clock(7, 0), new Clock(17, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0), new Clock(13,00))
                }),
                Recommendations = "",
            };
            Nanny Tsipi_Hotoveli = new Nanny
            {
                ID = idNannyArray[18],
                name = new Name("Tsipi", "Hotoveli"),
                birthday = new DateTime(1989, 3, 29),
                address = "HaRav Kuk St 8, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0521001001,
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = true,
                SallaryPerHour = 10,
                SallaryPerMonth = 900,
                DaysOff = false,
                Stars = 10,
                peopleThatRating = 4,
                wh = new WeeklyHours(new DayWork[]
                {
            new DayWork(new Clock(7,00),new Clock(16,0)),
                    new DayWork(new Clock(7, 15), new Clock(16, 0)),
                    new DayWork(new Clock(8,0), new Clock(14,00)),
                    new DayWork(new Clock(8,15), new Clock(14,30)),
                    new DayWork(new Clock(8,00), new Clock(16,00)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };
            Nanny Shifi_Aizen = new Nanny
            {
                ID = idNannyArray[19],
                name = new Name("Shifi", "Aizen"),
                birthday = new DateTime(1980, 5, 19),
                address = "HaRav Shalom Shabazi St 12, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                cellPhone = 0529344513,
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                PerHour = false,
                SallaryPerMonth = 900,
                DaysOff = false,
                Stars = 12,
                peopleThatRating = 3,
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(7,30),new Clock(16,0)),
                    new DayWork(new Clock(7,45), new Clock(15,45)),
                    new DayWork(new Clock(7, 0), new Clock(14, 0)),
                    new DayWork(new Clock(7, 0), new Clock(16, 0)),
                    new DayWork(new Clock(7, 30), new Clock(15, 30)),
                    new DayWork(new Clock(), new Clock())
                }),
                Recommendations = "",
            };

            instance.addNanny(malki_fishman);
            instance.addNanny(Moria_schneider);
            instance.addNanny(Ayala_Zehavi);
            instance.addNanny(Yafi_Shtain);
            instance.addNanny(Hila_Sharabi);
            instance.addNanny(Adi_Shushan);
            instance.addNanny(Chavi_Horen);
            instance.addNanny(Shifi_Aizen);
            instance.addNanny(Tsipi_Hotoveli);
            instance.addNanny(Gila_Elmagor);
            instance.addNanny(Miryam_BenHamu);
            instance.addNanny(lea_Gans);
            instance.addNanny(Batya_Adler);
            instance.addNanny(Chani_Yosef);
            instance.addNanny(Avigail_Kuk);
            instance.addNanny(Mehira_Shulman);
            instance.addNanny(batSheva_Choen);
            instance.addNanny(noa_Karlibach);
            instance.addNanny(Diti_Farkash);
            instance.addNanny(Elisheva_Shaked);
        }

        /// <summary>
        /// Initilize & addtion to list 21 Mothers
        /// </summary>
        void MotherInitilize()
        {

            Mother Bracha_Polak = new Mother
            {
                ID = idMotherArray[0],
                name = new Name("Bracha", "Polak"),
                address = "HaRav Herzog St 12, Jerusalem",
                cellPhone = 0526874352,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                    {
                    new DayWork(new Clock(8,30),new Clock(16,30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,0),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Oshrat_Levi = new Mother
            {
                ID = idMotherArray[1],
                name = new Name("Oshrat", "Levi"),
                address = "Ha-'va'ad haleumi St 21,Jerusalem",
                cellPhone = 0526943451,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(9,0), new Clock(17,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,0),new Clock(16,30)),
                    new DayWork(new Clock(8,0),new Clock(13,30)),
                    new DayWork(new Clock(8,0),new Clock(12,0))
                    }),
                remarks = "",
            };
            Mother Ayelt_Shaked = new Mother
            {
                ID = idMotherArray[2],
                name = new Name("Ayelt", "Shaked"),
                address = "Shakhal St 23,Jerusalem",
                cellPhone = 0521234566,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                 {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,0), new Clock(13,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,0),new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(16,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Gilat_Benet = new Mother
            {
                ID = idMotherArray[3],
                name = new Name("Gilat", "Benet"),
                address = "HaMem Gimel St 4, Jerusalem",
                cellPhone = 0527668451,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,0),new Clock(16,30)),
                    new DayWork(new Clock(7,45),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Esti_Kopshitz = new Mother
            {
                ID = idMotherArray[4],
                name = new Name("Esti", "Kopshitz"),
                address = "Haham Shmuel Bruchim St 5, Jerusalem",
                cellPhone = 0523154634,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(7,45),new Clock(15,45)),
                    new DayWork(new Clock(7,45),new Clock(15,45)),
                    new DayWork(new Clock(7,45),new Clock(15,45)),
                    new DayWork(new Clock(7,45),new Clock(15,45)),
                    new DayWork(new Clock(7,45),new Clock(15,45)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Irena_Gavrielov = new Mother
            {
                ID = idMotherArray[5],
                name = new Name("Irena", "Gavrielov"),
                address = "Arzei ha-Bira St 6, Jerusalem",
                cellPhone = 0523756345,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                 {
                    new DayWork(new Clock(8,15),new Clock(14,15)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,15),new Clock(14,15)),
                    new DayWork(new Clock(8,15),new Clock(14,15)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,0),new Clock(12,0))
                    }),
                remarks = "",
            };
            Mother Tovi_Shachak = new Mother
            {
                ID = idMotherArray[6],
                name = new Name("Tovi", "Shachak"),
                address = "Kav Venaki St 6, Jerusalem",
                cellPhone = 0527156743,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,0),new Clock(13,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(9,0),new Clock(12,30)),
                    new DayWork(new Clock(8,0),new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(16,00)),
                    new DayWork(new Clock(8,0),new Clock(12,30))
                    }),
                remarks = "",
            };
            Mother Sheindi_Lider = new Mother
            {
                ID = idMotherArray[7],
                name = new Name("Sheindi", "Lider"),
                address = "Yosef Ben Matityahu St 28, Jerusalem",
                cellPhone = 0548456654,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(7,45),new Clock(13,30)),
                    new DayWork(new Clock(8,15),new Clock(16,30)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Beili_Yudkevitz = new Mother
            {
                ID = idMotherArray[8],
                name = new Name("Beili", "Yudkevitz"),
                address = "HaRav Shalom Shabazi St 4, Jerusalem",
                cellPhone = 0509998881,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(7,45),new Clock(14,30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(7,45),new Clock(15,30)),
                    new DayWork(new Clock(7,45),new Clock(15,30)),
                    new DayWork(new Clock(7,45),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Malki_Orbach = new Mother
            {
                ID = idMotherArray[9],
                name = new Name("Malki", "Orbach"),
                address = "HaRav Kuk St 12, Jerusalem",
                cellPhone = 0571114444,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(8,30),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Yuti_Ashlag = new Mother
            {
                ID = idMotherArray[10],
                name = new Name("Yuti", "Ashlag"),
                address = "HaRav Reines St 5, Jerusalem",
                cellPhone = 0528989897,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(8,0),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Sara_Landau = new Mother
            {
                ID = idMotherArray[11],
                name = new Name("Sara", "Landau"),
                address = "Sderot Sarei Israel St 2 Jerusalem",
                cellPhone = 0527616509,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                 {
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(7,30),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Ruti_salomon = new Mother
            {
                ID = idMotherArray[12],
                name = new Name("Ruti", "salomon"),
                address = "Jaffa St 8, Jerusalem",
                cellPhone = 0543331234,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                 {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(7,45),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Chani_Stern = new Mother
            {
                ID = idMotherArray[13],
                name = new Name("Chani", "Stern"),
                address = "Yafo St 222, Jerusalem",
                cellPhone = 0525555111,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Aliza_Sorotzkin = new Mother
            {
                ID = idMotherArray[14],
                name = new Name("Aliza", "Sorotzkin"),
                address = "Ha-Nevi'im St 4, Jerusalem",
                cellPhone = 0526870003,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(7,45),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Mina_Berkovitz = new Mother
            {
                ID = idMotherArray[15],
                name = new Name("Mina", "Berkovitz"),
                address = "Ha-Amarkalim St 4, Jerusalem",
                cellPhone = 056754312,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(7,30),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Shani_Hovav = new Mother
            {
                ID = idMotherArray[16],
                name = new Name("Shani", "Hovav"),
                address = "Sulam Ya'akov St 32, Jerusalem",
                cellPhone = 0520909091,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,0),new Clock(12,00))
                    }),
                remarks = "",
            };
            Mother Esti_Lerner = new Mother
            {
                ID = idMotherArray[17],
                name = new Name("Esti", "Lerner"),
                address = "Binyamin Minz St 7, Jerusalem",
                cellPhone = 0522020202,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                 {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(), new Clock()),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,45),new Clock(15,00)),
                    new DayWork(new Clock(8,0),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Rochi_Zaltz = new Mother
            {
                ID = idMotherArray[18],
                name = new Name("Rochi", "Zaltz"),
                address = "Panim Meirot St 14, Jerusalem",
                cellPhone = 0521313132,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,15),new Clock(13,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,45),new Clock(16,00)),
                    new DayWork(new Clock(7,45),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Faigi_toyb = new Mother
            {
                ID = idMotherArray[19],
                name = new Name("Faigi", "toyb"),
                address = "Ha-Yehudim St 2, Jerusalem",
                cellPhone = 0521001001,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,30),new Clock(13,30)),
                    new DayWork(new Clock(8,0), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(8,0),new Clock(13,30)),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            Mother Shiri_Hochman = new Mother
            {
                ID = idMotherArray[20],
                name = new Name("Shiri", "Hochman"),
                address = "Me'a She'arim St 1, Jerusalem",
                cellPhone = 0521818181,
                location = "Shakhal St 23,Jerusalem",
                wh = new WeeklyHours(new DayWork[]
                  {
                    new DayWork(new Clock(8,0),new Clock(14,30)),
                    new DayWork(new Clock(8,30), new Clock(15,30)),
                    new DayWork(new Clock(8,0),new Clock(12,30)),
                    new DayWork(new Clock(8,30),new Clock(16,00)),
                    new DayWork(new Clock(),new Clock()),
                    new DayWork(new Clock(),new Clock())
                    }),
                remarks = "",
            };
            instance.addMother(Bracha_Polak);
            instance.addMother(Shiri_Hochman);
            instance.addMother(Rochi_Zaltz);
            instance.addMother(Faigi_toyb);
            instance.addMother(Esti_Lerner);
            instance.addMother(Shani_Hovav);
            instance.addMother(Mina_Berkovitz);
            instance.addMother(Aliza_Sorotzkin);
            instance.addMother(Chani_Stern);
            instance.addMother(Ruti_salomon);
            instance.addMother(Sara_Landau);
            instance.addMother(Yuti_Ashlag);
            instance.addMother(Malki_Orbach);
            instance.addMother(Beili_Yudkevitz);
            instance.addMother(Bracha_Polak);
            instance.addMother(Ayelt_Shaked);
            instance.addMother(Oshrat_Levi);
            instance.addMother(Gilat_Benet);
            instance.addMother(Esti_Kopshitz);
            instance.addMother(Tovi_Shachak);
            instance.addMother(Irena_Gavrielov);
            instance.addMother(Sheindi_Lider);

        }

        /// <summary>
        /// Initilize & addtion to list 30 Childs
        /// </summary>
        void ChildInitilize()
        {
            Child nadav = new Child
            {
                ID = idChildArray[0],
                idMother = idMotherArray[0],
                FirstName = "nadav",
                birthday = new DateTime(2017, 8, 26),
                special = false,
            };
            Child moty = new Child
            {
                ID = idChildArray[1],
                idMother = idMotherArray[1],
                FirstName = "moty",
                birthday = new DateTime(2017, 9, 8),
                special = false,
            };
            Child eti = new Child
            {
                ID = idChildArray[2],
                idMother = idMotherArray[2],
                FirstName = "eti",
                birthday = new DateTime(2017, 5, 29),
                special = false,
            };
            Child miri = new Child
            {
                ID = idChildArray[3],
                idMother = idMotherArray[3],
                FirstName = "miri",
                birthday = new DateTime(2017, 1, 22),
                special = false,
            };
            Child david = new Child
            {
                ID = idChildArray[4],
                idMother = idMotherArray[4],
                FirstName = "david",
                birthday = new DateTime(2017, 2, 9),
                special = false,
            };
            Child yael = new Child
            {
                ID = idChildArray[5],
                idMother = idMotherArray[4],
                FirstName = "yael",
                birthday = new DateTime(2017, 2, 24),
                special = false,
            };
            Child naama = new Child
            {
                ID = idChildArray[6],
                idMother = idMotherArray[5],
                FirstName = "naama",
                birthday = new DateTime(2017, 3, 1),
                special = false,
            };
            Child hila = new Child
            {
                ID = idChildArray[7],
                idMother = idMotherArray[6],
                FirstName = "hila",
                birthday = new DateTime(2017, 2, 2),
                special = false,
            };
            Child michal = new Child
            {
                ID = idChildArray[8],
                idMother = idMotherArray[7],
                FirstName = "michal",
                birthday = new DateTime(2017, 5, 29),
                special = false,
            };
            Child adi = new Child
            {
                ID = idChildArray[9],
                idMother = idMotherArray[7],
                FirstName = "adi ",
                birthday = new DateTime(2017, 1, 9),
                special = false,
            };
            Child reut = new Child
            {
                ID = idChildArray[10],
                idMother = idMotherArray[7],
                FirstName = "reut",
                birthday = new DateTime(2017, 4, 2),
                special = false,
            };
            Child efrat = new Child
            {
                ID = idChildArray[11],
                idMother = idMotherArray[8],
                FirstName = "efrat",
                birthday = new DateTime(2017, 4, 12),
                special = false,
            };
            Child noa = new Child
            {
                ID = idChildArray[12],
                idMother = idMotherArray[8],
                FirstName = "noa",
                birthday = new DateTime(2017, 5, 1),
                special = false,
            };
            Child shira = new Child
            {
                ID = idChildArray[13],
                idMother = idMotherArray[9],
                FirstName = "shira",
                birthday = new DateTime(2017, 5, 29),
                special = false,
            };
            Child Moriya = new Child
            {
                ID = idChildArray[14],
                idMother = idMotherArray[10],
                FirstName = "Moriya",
                birthday = new DateTime(2017, 6, 2),
                special = false,
            };
            Child sari = new Child
            {
                ID = idChildArray[15],
                idMother = idMotherArray[10],
                FirstName = "sari",
                birthday = new DateTime(2017, 6, 9),
                special = false,
            };
            Child yehuda = new Child
            {
                ID = idChildArray[16],
                idMother = idMotherArray[11],
                FirstName = "yehuda",
                birthday = new DateTime(2017, 6, 29),
                special = false,
            };
            Child itsik = new Child
            {
                ID = idChildArray[17],
                idMother = idMotherArray[12],
                FirstName = "itsik",
                birthday = new DateTime(2017, 8, 11),
                special = false,
            };
            Child pinchas = new Child
            {
                ID = idChildArray[18],
                idMother = idMotherArray[13],
                FirstName = "pinchas",
                birthday = new DateTime(2017, 7, 3),
                special = false,
            };
            Child yanki = new Child
            {
                ID = idChildArray[19],
                idMother = idMotherArray[14],
                FirstName = "yanki",
                birthday = new DateTime(2017, 6, 2),
                special = false,
            };
            Child eliyau = new Child
            {
                ID = idChildArray[20],
                idMother = idMotherArray[15],
                FirstName = "eliyau",
                birthday = new DateTime(2017, 6, 2),
                special = false,
            };
            Child eli = new Child
            {
                ID = idChildArray[21],
                idMother = idMotherArray[15],
                FirstName = "eli",
                birthday = new DateTime(2017, 9, 9),
                special = false,
            };
            Child yosef = new Child
            {
                ID = idChildArray[22],
                idMother = idMotherArray[16],
                FirstName = "yosef",
                birthday = new DateTime(2017, 10, 22),
                special = false,
            };
            Child ari = new Child
            {
                ID = idChildArray[23],
                idMother = idMotherArray[17],
                FirstName = "ari",
                birthday = new DateTime(2017, 11, 29),
                special = false,
            };
            Child shuki = new Child
            {
                ID = idChildArray[24],
                idMother = idMotherArray[17],
                FirstName = "shuki",
                birthday = new DateTime(2017, 12, 2),
                special = false,
            };
            Child itamar = new Child
            {
                ID = idChildArray[25],
                idMother = idMotherArray[17],
                FirstName = "itamar",
                birthday = new DateTime(2017, 5, 2),
                special = false,
            };
            Child yoni = new Child
            {
                ID = idChildArray[26],
                idMother = idMotherArray[18],
                FirstName = "yoni",
                birthday = new DateTime(2017, 10, 14),
                special = false,
            };
            Child moishi = new Child
            {
                ID = idChildArray[27],
                idMother = idMotherArray[19],
                FirstName = "moishi",
                birthday = new DateTime(2017, 3, 19),
                special = false,
            };
            Child avreimi = new Child
            {
                ID = idChildArray[28],
                idMother = idMotherArray[19],
                FirstName = "avreimi",
                birthday = new DateTime(2017, 11, 9),
                special = false,
            };
            Child yosi = new Child
            {
                ID = idChildArray[29],
                idMother = idMotherArray[20],
                FirstName = "Yosi",
                birthday = new DateTime(2017, 12, 2),
                special = false,
            };
            instance.addChild(nadav);
            instance.addChild(moty);
            instance.addChild(eli);
            instance.addChild(yael);
            instance.addChild(yanki);
            instance.addChild(yehuda);
            instance.addChild(yoni);
            instance.addChild(yosef);
            instance.addChild(yosi);
            instance.addChild(michal);
            instance.addChild(miri);
            instance.addChild(moishi);
            instance.addChild(Moriya);
            instance.addChild(naama);
            instance.addChild(noa);
            instance.addChild(sari);
            instance.addChild(shira);
            instance.addChild(shuki);
            instance.addChild(efrat);
            instance.addChild(eliyau);
            instance.addChild(hila);
            instance.addChild(pinchas);
            instance.addChild(itsik);
            instance.addChild(itamar);
            instance.addChild(eti);
            instance.addChild(adi);
            instance.addChild(david);
            instance.addChild(ari);
            instance.addChild(avreimi);
            instance.addChild(reut);
        }

        /// <summary>
        /// find nanny that suitable with Current mom
        /// </summary>
        int FindNanny(Mother mom)
        {
            Nanny n = instance.getNanny().Find(x => x.wh.Possible(mom.wh));
            if (n!=null)
                return instance.getNanny().Find(x => x.wh.Possible(mom.wh)).ID;
            throw new Exception("sorry, no Nanny Exists to your needs");
        }

        /// <summary>
        /// Initilize & addtion to list of Contracts, Note! there are children that have no nanny
        /// </summary>
        void ContractInitilize()
        {
            int Count = 0;
            Contract con;
            for (int i = 0; i < 30; i++)
            {
                Child c = instance.getChild().Find(y => y.ID == idChildArray[i]);
                Mother m = instance.getMother().Find(x => x.ID == c.idMother);
                try
                {
                   int Nannyid = FindNanny(m);
                    con = new Contract
                    {
                        idChild = idChildArray[i],
                        idNanny = Nannyid,
                        NameNanny = instance.getNanny().Find(x => x.ID == Nannyid).name,
                        IntroductoryMeeting = true,//if its not, addContract will change it
                        signed = true,
                        beginDeal = DateTime.Today,
                        endDeal = new DateTime(2018, 6, 25),
                    };
                    if (instance.addContract(con))
                    //throw the nanny that get a child to the end of list, to distribute evenly
                    {
                        Nanny n = instance.getNanny().Find(x => x.ID == con.idNanny);
                        instance.removeNanny(con.idNanny);
                        instance.addNanny(n);
                        Count++;
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine(instance.getMother().Find(x => x.ID == instance.getChild().Find(y => y.ID == idChildArray[i]).idMother).name);
                    /* don't something*/
                }
            }
            //foreach (Nanny n in instance.getNanny())
            //    if (n.myChildren != null)
            //    {
            //        Console.WriteLine(n.name.ToString());
            //        Console.WriteLine(n.myChildren.Count);
            //    }
        }
    }
}