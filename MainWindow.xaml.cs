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

namespace WPF_Learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Button myButton = new Button();
            //myButton.Width = 100;
            //myButton.Height = 30;
            //myButton.Content = "Кнопка";
            //layoutGrid.Children.Add(myButton);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = MethodValidation(TextBoxLogin.Text, TextBoxPassword.Password);
            bool result2 = MethodRegistration(TextBoxLogin.Text, TextBoxPassword.Password);
            if (result == true)
            {
                if (result2 == true)
                {
                    MessageBox.Show("Вы успешно зарегистровался!");
                }
                else
                {
                    MessageBox.Show("Регистрация не удалась!");
                }
            }
            else 
            {
                MessageBox.Show("Проверьте введенные данные!");
            }
        }

        public bool MethodRegistration(string _Login, string _Password) 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                User user = new User{ Name = _Login, Password = _Password };
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            };
        }
        public bool MethodValidation(string _Login, string _Password)
        {
            if (_Login!= "" && _Password != "")
            {
                if (_Password.Length >= 8) 
                { 
                    return true; 
                }
                return false;
            }
            return false;
        }
    }
}
