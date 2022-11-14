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
            MessageBox.Show("Дунаева М.И.\n\nПрактическая работа №8\n\n" +
                "Создать интерфейс – серия чисел (см. лекцию). Создать класс – простые числа." +
                "Класс должен включать конструктор. Сравнение производить по текущему значению.");
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            mails.Add(new MailSorting("Город N", "Улица 1", "1А", "4", "a5", 1500));
            mails.Add(new MailSorting("Город N", "Улица 2", "15Б", "14", "a5", 2000));
            mails.Add(new MailSorting("Эсфахан", "Улица 3", "13", "6", "a5", 3000));
            mails.Add(new MailSorting("Эсфахан", "Улица 4", "2", "43", "a5", 150000));
            mails.Add(new MailSorting("Рязань", "Улица 5", "10", "9", "a5", 1300));

            mailNums.Add(1);
            mailNums.Add(2);
            mailNums.Add(3);
            mailNums.Add(4);
            mailNums.Add(5);
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

        }
    }
}
