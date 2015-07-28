﻿using Stateless.WorkflowEngine.UI.Console.Models.Workflow;
using Stateless.WorkflowEngine.UI.Console.Services.Workflow;
using System;
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

namespace Stateless.WorkflowEngine.UI.Console.Controls
{
    /// <summary>
    /// Interaction logic for WorkflowBrowser.xaml
    /// </summary>
    public partial class WorkflowBrowser : UserControl
    {
        protected ObservableCollection<WorkflowContainer> workflows = new ObservableCollection<WorkflowContainer>();

        public WorkflowBrowser()
        {
            InitializeComponent();
        }

        public IWorkflowProvider WorkflowProvider { get; set; }

        private void RefreshWorkflows()
        {
            int count = 0;
            Int32.TryParse(txtWorkflowCount.Text, out count);
            workflows.Clear();
            foreach (WorkflowContainer wc in this.WorkflowProvider.GetActive(count))
            {
                workflows.Add(wc);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            grdWorkflows.ItemsSource = workflows;
            RefreshWorkflows();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshWorkflows();
        }

        private void txtWorkflowCount_LostFocus(object sender, RoutedEventArgs e)
        {
            int count = 0;
            if (!Int32.TryParse(txtWorkflowCount.Text, out count))
            {
                txtWorkflowCount.Text = "50";
            }

        }
    }
}