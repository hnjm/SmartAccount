﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Model.Entity;
using GKS.Model.ViewModels;
using GKS.Model;

//using ExportToExcelTools;

namespace GKS.XAML.UserControls
{
    public partial class HeadMgmtUC : UserControl
    {
        private readonly HeadMgmtModel _vm;
        public HeadMgmtUC()
        {
            InitializeComponent();
            _vm = new HeadMgmtModel();
            DataContext = _vm;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditHeadWindow headWindow = new AddEditHeadWindow { Owner = Window.GetWindow(this) };
            headWindow.Closed += (sndr, handler) => _vm.Reset();
            headWindow.SetOperationType(OperationType.Add);
            headWindow.ShowDialog();
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            Head head = _vm.SelectedGridItem;
            if (head != null)
            {
                AddEditHeadWindow headWindow = new AddEditHeadWindow(head) { Owner = Window.GetWindow(this) };
                headWindow.Closed += (sndr, handler) => _vm.Reset();
                headWindow.SetOperationType(OperationType.Update);
                headWindow.ShowDialog();
            }
            else MessageBox.Show("No head is selected.");
        }

        //private void RefreshButton_Click(object sender, RoutedEventArgs e)
        //{
        //    HeadMgmtModel vm = DataContext as HeadMgmtModel;
        //    vm.Reset();
        //}

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            dataGridAllHeads.ExportToExcel();
        }
    }
}


