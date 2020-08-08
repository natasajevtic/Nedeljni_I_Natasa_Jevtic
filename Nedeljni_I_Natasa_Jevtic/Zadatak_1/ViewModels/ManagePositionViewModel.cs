using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagePositionViewModel : BaseViewModel
    {
        ManagePositionView managePositionView;
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

        private List<vwPosition> positionList;

        public List<vwPosition> PositionList
        {
            get
            {
                return positionList;
            }
            set
            {
                positionList = value;
                OnPropertyChanged("PositionList");
            }
        }

        private ICommand addPosition;
        public ICommand AddPosition
        {
            get
            {
                if (addPosition == null)
                {
                    addPosition = new RelayCommand(param => AddPositionExecute(), param => CanAddPositionExecute());
                }
                return addPosition;
            }
        }

        public ManagePositionViewModel(ManagePositionView managePositionView)
        {
            this.managePositionView = managePositionView;
            PositionList = positions.GetAllPositions();
        }

        public void AddPositionExecute()
        {
            try
            {
                PositionFormView form = new PositionFormView();
                form.ShowDialog();
                PositionList = positions.GetAllPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddPositionExecute()
        {
            return true;
        }
    }
}