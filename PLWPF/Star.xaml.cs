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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Star.xaml
    /// </summary>
    public partial class Star : UserControl
    {
        int idChild;
        public Star()
        {
            InitializeComponent();
        }
        /// <summary>
        /// CTOR for star
        /// </summary>
        /// <param name="r">1 0r 0 for brush.color of star</param>
        /// <param name="id">0 for just present status of rating, not play as button </param>
        public Star(int r, int id=0)
            //to seperate between mother with function to nanny just with presentation 
        {
            InitializeComponent();
            if (r == 1)
                myStar.Background = Brushes.Yellow;
            idChild = id;
            if (id == 0)
                myStar.IsEnabled = false;
        } 
        private void myStar_Click(object sender, RoutedEventArgs e)
        {
            Child c = new Child();
            if(idChild != 0)
                c = BL_imp.GetInstance().getChild().Find(x=>x.ID == idChild);
            if (myStar.Background==Brushes.Yellow)
            {
                myStar.Background = Brushes.White;
                c.stars--;
                BL_imp.GetInstance().updateChild(c);
            }
            else
            {
                myStar.Background = Brushes.Yellow;
                c.stars++;
                BL_imp.GetInstance().updateChild(c);
            }
        }
    }
}
