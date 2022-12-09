using System.Linq;
using System.Windows;

namespace WPF_Learn
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Авторизация
            if (MethodValidation(TextBoxLogin.Text, TextBoxPassword.Password) == true)
            {
                if (MethodAutorization(TextBoxLogin.Text, TextBoxPassword.Password) == true)
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                }
                else
                {
                    MessageBox.Show("Введены неверные данные!");
                }
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные!");
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //Регистрация
            if (MethodValidation(TextBoxLogin.Text, TextBoxPassword.Password) == true)
            {
                if (MethodRegistration(TextBoxLogin.Text, TextBoxPassword.Password) == true)
                {
                    MessageBox.Show("Вы успешно зарегистровались!");
                }
                else
                {
                    MessageBox.Show("Логин занят!");
                }
            }
            else { MessageBox.Show("Проверьте введенные данные!"); }
        }
        public bool MethodRegistration(string _Login, string _Password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int countUsers = (from p in db.Users where p.Name == _Login select p).Count();
                if (countUsers == 0)
                {
                    User user = new User { Name = _Login, Password = _Password };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            };
        }
        public bool MethodAutorization(string _Login, string _Password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int countUsers = (from p in db.Users where p.Name == _Login && p.Password == _Password orderby p select p).Count();
                if (countUsers > 0)
                {
                    return true;
                }
                else { return false; }
            };
        }

        public bool MethodValidation(string _Login, string _Password)
        {
            if (_Login != "" && _Password != "")
            {
                if (_Password.Length >= 8)
                { return true; }
                else
                { return false; }
            }
            else { return false; }
        }
    }
}
