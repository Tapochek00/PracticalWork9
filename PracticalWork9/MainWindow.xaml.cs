using PracticalWork9;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace PracticalWork8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            citiesList.ItemsSource = cities;
            list.ItemsSource = mailNums;
        }

        ObservableCollection<MailSorting> mails = new ObservableCollection<MailSorting>();
        ObservableCollection<int> mailNums = new ObservableCollection<int>();
        ObservableCollection<string> cities = new ObservableCollection<string>();

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дунаева М.И.\n\nПрактическая работа №9\n\n" +
                "Описать, используя структуру, почтовую сортировку (город, улица, дом, квартира, " +
                "кому, ценность).Вывести результат на экран.Вывести информацию, сколько" +
                "посылок отправлено в заданный город");
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            int count = mails.Count;

            mails.Add(new MailSorting("Город N", "Улица 2", "15Б", "14", "a5", 2000));
            mails.Add(new MailSorting("Эсфахан", "Улица 3", "13", "6", "a5", 3000));
            mails.Add(new MailSorting("Эсфахан", "Улица 4", "2", "43", "a5", 150000));
            mails.Add(new MailSorting("Рязань", "Улица 5", "10", "9", "a5", 1300));


            for (int i = 1; i <= 4; i++)
            {
                mailNums.Add(count + i);
                if (!cities.Contains(mails[count - 1 + i].City)) cities.Add(mails[count-1+i].City);
            }
        }

        private void btn_GetInfo_Click(object sender, RoutedEventArgs e)
        {
            mailInfo.Text = "Город: " + mails[list.SelectedIndex].City
                 + "\n" + "Улица: " + mails[list.SelectedIndex].Street
                 + "\n" + "Дом: " + mails[list.SelectedIndex].House
                 + "\n" + "Квартира: " + mails[list.SelectedIndex].Apartment
                 + "\n" + "Кому: " + mails[list.SelectedIndex].ToWho
                 + "\n" + "Ценность: " + Convert.ToString(mails[list.SelectedIndex].Value);

            list.SelectedItems.Clear();
        }

        private void btn_GetMail_Click(object sender, RoutedEventArgs e)
        {
            string city = Convert.ToString(citiesList.SelectedItem);
            int count = 0;
            foreach(MailSorting item in mails) if (item.City == city) count++;
            mailToCity.Text = count.ToString();
            citiesList.SelectedItems.Clear();
        }

        private void btn_AddMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string mail = enterMail.Text;
                string[] mailArr = mail.Split(',');

                foreach (string s in mailArr) s.Trim(' ');
                mails.Add(new MailSorting(mailArr[0], mailArr[1], mailArr[2],
                    mailArr[3], mailArr[4], int.Parse(mailArr[5])));
                mailNums.Add(mails.Count());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
