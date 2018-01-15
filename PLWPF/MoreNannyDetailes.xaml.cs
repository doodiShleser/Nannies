using BE;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MoreNannyDetailes.xaml
    /// </summary>
    public partial class MoreNannyDetailes : Window
    {
        public MoreNannyDetailes()
        {
            InitializeComponent();
        }
        public MoreNannyDetailes(Nanny n)
        {
            InitializeComponent();
            More.DataContext = n;
            for (int i = 0; i < 6; i++)
                Days.Items.Add(new
                {
                    day = n.wh.days[i],
                    work = n.wh.DayThatIWork[i],
                    begin = n.wh.WorkHours[i].begin,
                    end = n.wh.WorkHours[i].end
                });
            Name.Content += String.Format(n.name.FirstName + " " + n.name.LastName);    
        }
    }
}
