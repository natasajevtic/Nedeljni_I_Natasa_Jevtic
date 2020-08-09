using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class PositionFormViewModel : BaseViewModel
    {
        PositionFormView positionFormView;
        Positions positions = new Positions();

        private vwPosition position;

        public vwPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        private ICommand savePosition;
        public ICommand SavePosition
        {
            get
            {
                if (savePosition == null)
                {
                    savePosition = new RelayCommand(param => SavePositionExecute(), param => CanSavePositionExecute());
                }
                return savePosition;
            }
        }

        private ICommand cancelPosition;
        public ICommand CancelPosition
        {
            get
            {
                if (cancelPosition == null)
                {
                    cancelPosition = new RelayCommand(param => CancelPositionExecute(), param => CanCancelPositionExecute());
                }
                return cancelPosition;
            }
        }

        public PositionFormViewModel(PositionFormView positionFormView)
        {
            this.positionFormView = positionFormView;
            Position = new vwPosition();
        }

        public void SavePositionExecute()
        {
            if (String.IsNullOrEmpty(Position.PositionName) || String.IsNullOrEmpty(Position.PositionDescription))
            {
                MessageBox.Show("Please fill all fields", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the position?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = positions.AddPosition(Position);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Position is created.", "Notification", MessageBoxButton.OK);
                            positionFormView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Position cannot be created.", "Notification", MessageBoxButton.OK);
                            positionFormView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanSavePositionExecute()
        {
            return true;
        }

        public void CancelPositionExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the position?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    positionFormView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanCancelPositionExecute()
        {
            return true;
        }
    }
}