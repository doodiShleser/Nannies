using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NannyDetailes: UserControl
    {
        public NannyDetailes()
        {
            InitializeComponent();
        }

        private void Recommendations_Click(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
            Grid g = (b.Parent as Grid);
            List<Label> t = g.Children.OfType<Label>().ToList();
            int id = int.Parse(t.Find(x => x.Name.ToString() == "ID").Content.ToString());
            Nanny forMore = BL_imp.GetInstance().getNanny().Find(x => x.ID == id);
            Window recommendations = new Recommendations(forMore);
            recommendations.Show();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
            Grid g = (b.Parent as Grid);
            List<Label> t = g.Children.OfType<Label>().ToList();
            int id =int.Parse(t.Find(x => x.Name.ToString() == "ID").Content.ToString());
            Nanny forMore = BL_imp.GetInstance().getNanny().Find(x => x.ID == id); 
            Window more = new MoreNannyDetailes(forMore);
            more.Show();
        }
        public NannyDetailes AddNannyDetailesGrid(Nanny n)
        {
            double rat;
            if (n.peopleThatRating != 0)
                rat = n.Stars / n.peopleThatRating;
            else rat = 0;
            var myGrid = new NannyDetailes();
            myGrid.ID.Content = n.ID;
            myGrid.Nanny_Name.Content = String.Format(n.name.FirstName + " " + n.name.LastName);
            myGrid.Nanny_Address.Content = n.address +"; Floor " +n.floor.ToString();
            myGrid.Nanny_Detailes.Text += n.print();
            myGrid.Price.Text += String.Format("Price Per Months: " + n.SallaryPerMonth);
            myGrid.Number_Recommendations.Content = String.Format(n.numberRecommendations + " Recommendations");
            myGrid.Rating.Text += rat; 
            for (int i = 0; i < rat; i++)
                myGrid.rating.Children.Add(new Star(1,0));
            for (int i = Convert.ToInt32(rat); i < 5; i++)
                myGrid.rating.Children.Add(new Star(0,0));
            return myGrid;
        }

    }
}
