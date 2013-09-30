﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using System.ComponentModel;
using Navigator.Navigation;

namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<string> _goToPathCommand;

        private RelayCommand<INotifyPropertyChanged> _goToPage1Command;

        private RelayCommand<INotifyPropertyChanged> _goToPage2Command;

        private RelayCommand<INotifyPropertyChanged> _goToPage3Command;

        private readonly INotifyPropertyChanged _p1ViewModel = new Page1ViewModel();
        private readonly INotifyPropertyChanged _p2ViewModel = new Page2ViewModel();
        private readonly INotifyPropertyChanged _p3ViewModel = new Page3ViewModel();

        #endregion


        #region Properties

        public RelayCommand<string> GoToPathCommand
        {
            get { return _goToPathCommand; }
            set
            {
                _goToPathCommand = value;
                RaisePropertyChanged("GoToPathCommand");
            }
        }

        public RelayCommand<INotifyPropertyChanged> GoToPage1Command
        {
            get 
            { 
                return _goToPage1Command; 
            }
            set
            {
                _goToPage1Command = value;
                RaisePropertyChanged("GoToPage1Command");
            }
        }

        public RelayCommand<INotifyPropertyChanged> GoToPage2Command
        {
            get { return _goToPage2Command; }
            set
            {
                _goToPage2Command = value;
                RaisePropertyChanged("GoToPage2Command");
            }
        }

        public RelayCommand<INotifyPropertyChanged> GoToPage3Command
        {
            get { return _goToPage3Command; }
            set
            {
                _goToPage3Command = value;
                RaisePropertyChanged("GoToPage3Command");
            }
        }

        public INotifyPropertyChanged Page1ViewModel
        {
            get { return _p1ViewModel; }
        }

        public INotifyPropertyChanged Page2ViewModel
        {
            get { return _p2ViewModel; }
        }

        public INotifyPropertyChanged Page3ViewModel
        {
            get { return _p3ViewModel; }
        }

        #endregion


        #region Constructors

        public MainViewModel()
        {
            InitializeCommands();
        }

        #endregion



        private void InitializeCommands()
        {
            
            GoToPathCommand = new RelayCommand<string>(GoToPathCommandExecute);

            GoToPage1Command = new RelayCommand<INotifyPropertyChanged>(GoToPage1CommandExecute);

            GoToPage2Command = new RelayCommand<INotifyPropertyChanged>(GoToPage2CommandExecute);

            GoToPage3Command = new RelayCommand<INotifyPropertyChanged>(GoToPage3CommandExecute);
        }

        private void GoToPathCommandExecute(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            
            var uri = new Uri(path);

            Navigation.Navigate(uri);
        }

        private void GoToPage1CommandExecute(INotifyPropertyChanged viewModel)
        {
            var uri = new Uri("pack://application:,,,/Pages;component/Page1.xaml");

            Navigation.Navigate(uri, Page1ViewModel);
        }

        private void GoToPage2CommandExecute(INotifyPropertyChanged viewModel)
        {
            var uri = new Uri("pack://application:,,,/Pages;component/Page2.xaml");

            Navigation.Navigate(uri, Page1ViewModel);
        }

        private void GoToPage3CommandExecute(INotifyPropertyChanged viewModel)
        {
            var uri = new Uri("pack://application:,,,/Pages;component/Page3.xaml");

            Navigation.Navigate(uri, Page1ViewModel);
        }
    }
}
