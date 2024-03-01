using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using Student_Management_System.Views;
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

namespace Student_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtEmail.Text) && textEmail.Text.Length > 0)
        //    {
        //        textEmail.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        textEmail.Visibility = Visibility.Visible;
        //    }
        //}

        //private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    txtEmail.Focus();
        //}


        //private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    txtPassword.Focus();
        //}

        //private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length > 0)
        //    {
        //        textPassword.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        textPassword.Visibility = Visibility.Visible;
        //    }

        //}

        //private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ChangedButton == MouseButton.Left)
        //    {
        //        this.DragMove();
        //    }
        //}



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var UserName = txtEmail.Text;
            var Password = txtPassword.Text;

            using (UserDataContext context = new UserDataContext())
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("Please enter both a username and password.");
                    return;
                }

                var user = context.Users.FirstOrDefault(u => u.Name == UserName && u.Password == Password);

                if (user != null)
                {
                    if (user.Role == "Admin")
                    {
                        var window = new AdminWindow();
                        window.Show();
                    }
                    else if (user.Role == "User")
                    {
                        var window = new UserWindow();
                        window.Show();
                    }

                    txtEmail.Text = null;
                    txtPassword.Text = null;
                    Close();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }
    }
}
