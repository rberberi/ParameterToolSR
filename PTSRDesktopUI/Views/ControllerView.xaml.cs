﻿using PTSRDesktopUI.Models;
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

namespace PTSRDesktopUI.Views
{
    /// <summary>
    /// Interaktionslogik für ControllerView.xaml
    /// </summary>
    public partial class ControllerView : UserControl
    {
        public ControllerView()
        {
            InitializeComponent();

            //Set the title lable to the selected controller name
            ViewTitle_Lbl.Content = SelectedController.controllerName;

            //Sets the login user text block to the global variable for logged in user
            loggedUser_textblock.Text = LoggedUser.loggedUser;
        }

        //Open Popup when clicking info button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = true;
        }

        //Close Popup when clicking x button
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;

        }
    }
}
