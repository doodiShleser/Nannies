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
using System.ComponentModel;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MotherOptions.xaml
    /// </summary>
    public partial class MotherOptions : Window
    {
        static IBL instance;
        static Random r;
        static int idM;
        Mother tofunctions;
        List<Nanny> Selected;
        NannyDetailes Element_of_Nanny_Detailes;
        Button lastClicked; //the last sortButton that clicked

        public MotherOptions()
        {
            InitializeComponent();
            instance = BL_imp.GetInstance();//singelton
            r = new Random();
            tofunctions = instance.getMother()[r.Next(0, 20)];
            idM = tofunctions.ID;
            Selected = instance.getNanny();

            Element_of_Nanny_Detailes = new NannyDetailes();
            foreach (Nanny item in Selected)
                Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(item));

            Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
            lastClicked = new Button();

            detailes.Content = String.Format(tofunctions.name.FirstName + " " + tofunctions.name.LastName);
        }
        public MotherOptions(int id)
        {
            InitializeComponent();
            instance = BL_imp.GetInstance();//singelton
            r = new Random();
            tofunctions = instance.getMother().Find(x=>x.ID == id);
            idM = tofunctions.ID;
            Selected = instance.getNanny();

            Element_of_Nanny_Detailes = new NannyDetailes();
            foreach (Nanny item in Selected) 
                Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(item));

            Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
            lastClicked = new Button();

            detailes.Content = String.Format(tofunctions.name.FirstName + " " + tofunctions.name.LastName);
        }

        #region Sorting Buttons
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<MotherOptions>().First().Close();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
            switch (b.Name)
            {
                case "suitable":
                    lastClicked = b;
                    suitableSort();
                    break;
                case "price":
                    lastClicked = b;
                    priceSort();
                    break;
                case "distance":
                    lastClicked = b;
                    distanceSort();
                    break;
                case "rating":
                    lastClicked = b;
                    ratingSort();
                    break;
            }
        }
        private void suitableSort()
        {
            var toList = Grid_Detailes.Children.OfType<NannyDetailes>();
            Grid_Detailes.Children.RemoveRange(1, toList.Count());
            Number_of_nannies.ClearValue(TextBlock.TextProperty);
            if (Selected.Count != 0)
            {
                List<KeyValuePair<Nanny, int>> t = BLSorting.GetInstance().sortBySuitableDays(Selected, tofunctions);//why?
                Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
                for (int i = 0; i < t.Count; i++)
                    Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(t[i].Key));        
            }
            else
                Number_of_nannies.Text += String.Format("Sorry, but there no Nannies suit for you");
        }
        private void priceSort()
        {
            var toList = Grid_Detailes.Children.OfType<NannyDetailes>();
            Grid_Detailes.Children.RemoveRange(1, toList.Count());
            Number_of_nannies.ClearValue(TextBlock.TextProperty);
            Selected = BLSorting.GetInstance().sortByPrice(Selected);
            if (Selected.Count != 0)
            {          
                Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");

                foreach (Nanny item in Selected)
                    Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(item));
            }
            else
                Number_of_nannies.Text += String.Format("Sorry, but there no Nannies suit for you");
        }

        private void distanceSort()
        {
            var toList = Grid_Detailes.Children.OfType<NannyDetailes>();
            Grid_Detailes.Children.RemoveRange(1, toList.Count());
            Number_of_nannies.ClearValue(TextBlock.TextProperty);
            if (Selected.Count != 0)
            {
                Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
                List<KeyValuePair<Nanny, int>> t = BLSorting.GetInstance().sortByDistance(Selected, tofunctions);
                for (int i = 0; i < t.Count; i++)
                    Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(t[i].Key));
            }
            else
                Number_of_nannies.Text += String.Format("Sorry, but there no Nannies suit for you");
        }

        private void ratingSort()
        {
            var toList = Grid_Detailes.Children.OfType<NannyDetailes>();
            Grid_Detailes.Children.RemoveRange(1, toList.Count());
            Number_of_nannies.ClearValue(TextBlock.TextProperty);
            if (Selected.Count != 0)
            {
                Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
                Selected = BLSorting.GetInstance().sortByRating(Selected);
                foreach (Nanny item in Selected)
                    Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(item));
            }
            else
                Number_of_nannies.Text += String.Format("Sorry, but there no Nannies suit for you");
        }

        #endregion Sorting Buttons

        private void detailes_Click(object sender, RoutedEventArgs e)
        {
            Window DetailesWindow = new DetailesWindow(tofunctions);
            DetailesWindow.Show();
        }

        List<Nanny> groupingMin(List<Nanny> n, int setMin, int setMax)
        {
            List<Nanny> g = new List<Nanny>();
            List<Nanny>[] groupMin = BLGrouping.GetInstance().groupingByAge(n, true, false).ToArray();
            int low;
            if (setMin != -1)
                low = setMin;
            else
                low = 0;
            int high;
            if (setMax != -1 && setMax < groupMin.Length)
                high = setMax;
            else
                high = groupMin.Length;
            for (int i = low; i < high; i++)
                if (groupMin[i] != null)
                    foreach (Nanny item in groupMin[i])
                        g.Add(item);
            return g;
        }
        List<Nanny> groupingMax(List<Nanny> n, int setMin, int setMax)
        {
            List<Nanny> g = new List<Nanny>();

            List<Nanny>[] groupMax = BLGrouping.GetInstance().groupingByAge(n, false, false).ToArray();
            int low;
            if (setMin != -1)
                low = setMin;
            else
                low = 0;
            int high;
            if (setMax != -1)
                high = setMax;
            else
                high = groupMax.Length;
            for (int i = low; i < high; i++)
                if (groupMax[i] != null)
                    foreach (Nanny item in groupMax[i])
                        g.Add(item);
            return g;
        }

        private List<Nanny> Filter(CheckBox cb, List<Nanny> selectList)
        {
            List<Nanny> returnSelected = selectList;
            switch (cb.Content.ToString())
            {
                case "suitable Days":
                    returnSelected = MorBL.GetInstance().relevanceNannies(returnSelected, tofunctions);
                    break;
                case "free Space":
                    returnSelected = MorBL.GetInstance().freeSpace(returnSelected);
                    break;
                case "vacation by Ha-Tamat":
                    returnSelected = MorBL.GetInstance().accordingTHAMAT(returnSelected);
                    break;
                case "Elevator":
                    returnSelected = MorBL.GetInstance().Elevator(returnSelected);
                    break;
                case "Daily Payment option":
                    returnSelected = MorBL.GetInstance().DaylyPayment(returnSelected);
                    break;
                case "get Five Most Appropriate":
                    returnSelected = MorBL.GetInstance().FiveMostAppropriateNannies(returnSelected, tofunctions);
                    break;
            }
            return returnSelected;
        }
        private List<Nanny> FilterMinAge()
        {
            Selected = instance.getNanny();//begining the filtering from head
            List<Nanny> newSelected = new List<Nanny>();
            List<Nanny> t = new List<Nanny>();
            var cbList = MinAge.Children.OfType<CheckBox>();
            var checkedList = from item in cbList
                              where (bool)item.IsChecked
                              select item;
            if (checkedList.Count() > 0)
            {
                foreach (CheckBox item in checkedList)
                {
                    switch (item.Content.ToString())
                    {
                        case "1-3 month":
                            t = groupingMin(Selected, 1, 3);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                        case "3-6 month":
                            t = groupingMin(Selected, 3, 6);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                        case "above 6 month":
                            t = groupingMin(Selected, 6, -1);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                    }
                }
            }
            else
                newSelected = Selected;
            //now, again to Filter for all user choices. 
            foreach (CheckBox cBox in options.Children.OfType<CheckBox>())
                if ((bool)cBox.IsChecked)
                    newSelected = Filter(cBox, newSelected);
            return newSelected;

        }
        private List<Nanny> FilterMaxAge()
        {

            Selected = instance.getNanny();//begining the filtering from head
            List<Nanny> newSelected = new List<Nanny>();
            List<Nanny> t = new List<Nanny>();
            var cbList = MaxAge.Children.OfType<CheckBox>();
            var checkedList = from item in cbList
                              where (bool)item.IsChecked
                              select item;
            if (checkedList.Count() > 0)
            {
                foreach (CheckBox item in checkedList)
                {
                    switch (item.Content.ToString())
                    {
                        case "below 12 month":
                            t = groupingMax(Selected, -1, 12);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                        case "12-15 month":
                            t = groupingMax(Selected, 12, 15);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                        case "15-18 month":
                            t = groupingMax(Selected, 15, 18);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                        case "above 18 month":
                            t = groupingMax(Selected, 18, -1);
                            if (t != null)
                                foreach (Nanny nanny in Selected)
                                    if (t.Exists(x => x.ID == nanny.ID))
                                        newSelected.Add(nanny);
                            break;
                    }

                }
            }
            else
                newSelected = Selected;
            //now, again to Filter for all user choices. 
            foreach (CheckBox cBox in options.Children.OfType<CheckBox>())
                if ((bool)cBox.IsChecked)
                    newSelected = Filter(cBox, newSelected);
            return newSelected;
        }
        private List<Nanny> UncheckedFilter(StackPanel sp, List<Nanny> listSelected)
        {
            List<Nanny> t = listSelected;
            List<Nanny> returnSelected = listSelected;
            var cbList = sp.Children.OfType<CheckBox>();
            var checkedList = from item in cbList
                              where (bool)item.IsChecked
                              select item;
            if (sp == options)
                foreach (CheckBox item in checkedList)
                    returnSelected = Filter(item, returnSelected);
            if (sp == MinAge)
                returnSelected = FilterMinAge();
            if (sp == MaxAge)
                foreach (CheckBox item in checkedList)
                    returnSelected = FilterMaxAge();
            return returnSelected;
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).Parent == options)
                Selected = Filter((sender as CheckBox), Selected);
            if((sender as CheckBox).Parent == MinAge)
                Selected = FilterMinAge();
            if ((sender as CheckBox).Parent == MaxAge)
                Selected = FilterMaxAge();
            foreach (Button b in SortButtons.Children.OfType<Button>())
                if (b.Name == lastClicked.Name)
                    Sort_Click(b, e);
            var toList = Grid_Detailes.Children.OfType<NannyDetailes>();
            Grid_Detailes.Children.RemoveRange(1, toList.Count());
            Number_of_nannies.ClearValue(TextBlock.TextProperty);
            if (Selected.Count != 0)
            {
                Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
                foreach (Nanny item in Selected)
                    Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(item));
            }
            else
                Number_of_nannies.Text += String.Format("Sorry, but there no Nannies suit for you");
        }

        private void Unchecked(object sender, RoutedEventArgs e)
        {
            Selected = instance.getNanny();
            Selected = UncheckedFilter(options, Selected);
            Selected = UncheckedFilter(MinAge, Selected);
            Selected = UncheckedFilter(MaxAge, Selected);
            foreach (Button b in SortButtons.Children.OfType<Button>())
                if (b.Name == lastClicked.Name)
                    Sort_Click(b, e);
            var toList = Grid_Detailes.Children.OfType<NannyDetailes>();
            Grid_Detailes.Children.RemoveRange(1, toList.Count());
            Number_of_nannies.ClearValue(TextBlock.TextProperty);
            if (Selected.Count != 0)
            {
                Number_of_nannies.Text += String.Format("We Find " + Selected.Count + " Nannies suit for you");
                foreach (Nanny item in Selected)
                    Grid_Detailes.Children.Add(Element_of_Nanny_Detailes.AddNannyDetailesGrid(item));
            }
            else
                Number_of_nannies.Text += String.Format("Sorry, but there no Nannies suit for you");
        }
    }
}

