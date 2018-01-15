using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ContractDetailes.xaml
    /// </summary>
    public partial class ContractDetailes : Window
    {
        public ContractDetailes()
        {
            InitializeComponent();
        }
        public ContractDetailes(Contract c)
        {
            InitializeComponent();
            Contract_Detailes.DataContext = c;
            for (int i = 0; i < 6; i++)
                Days.Items.Add(new
                {
                    day = c.wh.days[i],
                    work = c.wh.DayThatIWork[i],
                    begin = c.wh.WorkHours[i].begin,
                    end = c.wh.WorkHours[i].end
                });
        }
    }
}
