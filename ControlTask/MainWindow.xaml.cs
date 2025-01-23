using ControlTask.Models;
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

namespace ControlTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControlWorkEntities db = new ControlWorkEntities();
            var user = db.Users.FirstOrDefault(x => x.username == tbLogin.Text && x.password == tbPassword.Password);
            if (user != null)
            {
                var role = db.Roles.FirstOrDefault(x => x.role_id == user.role_id);
                MessageBox.Show($"Добро пожаловать! Ваша роль: {role.role_name}");
                tbLogin.Clear();
                tbPassword.Clear();
            }
            else
            {
                MessageBox.Show("Неверно введены логин или пароль!");
            }
        }
    }
}
