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
using BE;
using BL;
using System.Windows.Controls.Primitives;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildDetailes.xaml
    /// </summary>
    public partial class ChildDetailes : Window
    { 
        int BeforeUpdate;//number of stars of nanny before the new rating
        int childStars; // number of Stars that specific mother rating her before this event 
        public ChildDetailes()
        {
            InitializeComponent();
        }
        public ChildDetailes(Child c)
        {
            InitializeComponent();
            Detailes.DataContext = c;
            if (c.special)
                Needs.Visibility = Visibility.Visible;
            else
                Needs.Visibility =Visibility.Hidden;
            Needs.Text += c.specialNeeds;
            List<Contract> t = BL_imp.GetInstance().getContract();
            Contract con = t.Find(x => x.idChild == c.ID);
            Nanny n = BL_imp.GetInstance().getNanny().Find(x => x.ID == con.idNanny);
            if (n != null)
            {
                his_Nanny.Name = String.Format("ID" + con.idNanny);
                his_Nanny.Content = n.name.ToString();
            }
            for (int i = 0; i < c.stars; i++)
                Rating.Children.Add(new Star(1,c.ID));
            for (int i = c.stars; i < 5; i++)
                Rating.Children.Add(new Star(0,c.ID));
            childStars = c.stars;
            BeforeUpdate = n.Stars - c.stars;
        }

        private void his_Nanny_Click(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
            Contract con = BL_imp.GetInstance().getContract().Find(x => x.idNanny == int.Parse(b.Name.Substring(2)));
            Window ContractDetailes = new ContractDetailes(con);
            ContractDetailes.Show();
        }

        private void AddRecommendation_Click(object sender, RoutedEventArgs e)
        {
            ToAdd.Visibility = Visibility.Visible;
            Title.Visibility = Visibility.Visible;
            Recommend.Visibility = Visibility.Visible;
            Finish.Visibility = Visibility.Visible;
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Child c = (Detailes.DataContext as Child);
            Contract con = BL_imp.GetInstance().getContract().Find(x => x.idChild == c.ID);
            Nanny n = BL_imp.GetInstance().getNanny().Find(x => x.ID == con.idNanny);
            Mother m = BL_imp.GetInstance().getMother().Find(x => x.ID == c.idMother);
            n.Recommendations += String.Format(m.name.ToString()+": " +Recommend.Text);
            n.numberRecommendations++;
            BL_imp.GetInstance().updateNanny(n);
            ToAdd.Visibility = Visibility.Collapsed;
            Title.Visibility = Visibility.Collapsed;
            Recommend.Visibility = Visibility.Collapsed;
            Finish.Visibility = Visibility.Collapsed;
        }
        protected override void OnClosed(EventArgs e)
        {
            Child c =BL_imp.GetInstance().getChild().Find(x=>x.ID==(Detailes.DataContext as Child).ID);
            List<Contract> t = BL_imp.GetInstance().getContract();
            Contract con = t.Find(x => x.idChild == c.ID);
            Mother m = BL_imp.GetInstance().getMother().Find(x => x.ID == c.idMother);
            Nanny n = BL_imp.GetInstance().getNanny().Find(x => x.ID == con.idNanny);
            n.Stars = BeforeUpdate + c.stars;
            if (c.stars > 0 && childStars == 0)
                n.peopleThatRating++;
            if (c.stars == 0 && childStars != 0)
                n.peopleThatRating--;
            BL_imp.GetInstance().updateNanny(n);
            BL_imp.GetInstance().updateChild(c);
            Window w = Application.Current.Windows.OfType<MotherOptions>().First();
            Application.Current.Windows.OfType<DetailesWindow>().First().Close();
            Application.Current.Windows.OfType<MotherOptions>().First().Close();
            Window MotherOptions = new MotherOptions(m.ID);
            MotherOptions.Show();
            Window DetailesWindow = new DetailesWindow(m);
            DetailesWindow.Show();

        }

    }

}
