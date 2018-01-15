﻿using BE;
using DAl;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void addNanny(Nanny n);
        void removeNanny(int id);
        void updateNanny(Nanny n,UpdateNanny update);
        void updateNanny(Nanny n);
        List<Nanny> getNanny();

        void addMother(Mother m);
        void removeMother(int id);
        void updateMother(Mother m, UpdateMother update);
        List<Mother> getMother();

        void addChild(Child c);
        void removeChild(int id);
        void updateChild(Child c, UpdateChild update);
        void updateChild(Child c);
        List<Child> getChild();

        bool addContract(Contract c);
        void removeContract(int code);
        void updateContract(Contract c, UpdateContract update);
        List<Contract> getContract();


        int CalculateDistance(string source, string dest);
        //void doGoogleMapsWork(object sender,DoWorkEventArgs e);
        //void doGoogleMapsWorkCompleted(object sender, RunWorkerCompletedEventArgs e);
        //List<Nanny> Nanny_In_Range(Mother m);
        void AddRecommendation(int id, string r);
    }
}