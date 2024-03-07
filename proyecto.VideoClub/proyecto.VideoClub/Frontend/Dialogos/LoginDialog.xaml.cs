﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using proyecto.VideoClub.MVVM;
using System.ComponentModel;




namespace proyecto.VideoClub.Frontend.Dialogos
{

    public partial class LoginDialog : Window 
    {
        private UsuarioServicio servUsu;
        private videoclubEntities vCEnt;
       

        public LoginDialog()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {

            vCEnt = new videoclubEntities();
            servUsu = new UsuarioServicio(vCEnt);
          
           
            btnEntrar.IsEnabled = false;
        }

       



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Cerrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ResetPss_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        
        private void Cerrar_MouseEnter(object sender, MouseEventArgs e)
        {
            Cerrar.Opacity = 1;

        }

        private void Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            Cerrar.Opacity = 0.3;
        }

     

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (servUsu.login(txtUsuario.Text, txtPass.Password))
            {

                MainWindow ventanaPrincipal = new MainWindow(vCEnt, servUsu.usuLogin);
                ventanaPrincipal.Show();
                this.Close();


            }
            else
            {
                Error er = new Error();
                er.Show();
                this.Close();

            }
        }

        private void comprobarBtn ()
        {
            if (txtUsuario.Text.Length > 0 && txtPass.Password.Length > 0 )
            {
                btnEntrar.IsEnabled = true;
            }
            else
            {
                btnEntrar.IsEnabled = false;
            }
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            comprobarBtn();
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            comprobarBtn();
        }

        private void btnVerCatalogo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaPrincipal = new MainWindow(vCEnt);
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}