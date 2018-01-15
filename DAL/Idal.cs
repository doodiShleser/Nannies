using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl
{
    public interface Idal
    {
        void AddNanny(Nanny n);
        bool RemoveNanny(int id);
        void UpdateNanny(Nanny n);

        void AddMother(Mother m);
        bool RemoveMother(int id);
        void UpdateMother(Mother m);

        void AddChild(Child c);
        bool RemoveChild(int id);
        void UpdateChild(Child c);

        void AddContract(Contract c);
        bool RemoveContract(int code);
        void UpdateContract(Contract c);

        List<Nanny> NannyList();
        List<Mother> MotherList();
        List<Child> ChildList();
        List<Contract> ContractList();
    }
}