using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class SectorFormViewModel : BaseViewModel
    {
        SectorFormView sectorFormView;
        Sectors sectors = new Sectors();

        private vwSector sector;

        public vwSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }

        private ICommand saveSector;
        public ICommand SaveSector
        {
            get
            {
                if (saveSector == null)
                {
                    saveSector = new RelayCommand(param => SaveSectorExecute(), param => CanSaveSectorExecute());
                }
                return saveSector;
            }
        }

        private ICommand cancelSector;
        public ICommand CancelSector
        {
            get
            {
                if (cancelSector == null)
                {
                    cancelSector = new RelayCommand(param => CancelSectorExecute(), param => CanCancelSectorExecute());
                }
                return cancelSector;
            }
        }

        public SectorFormViewModel(SectorFormView sectorFormView)
        {
            this.sectorFormView = sectorFormView;
            Sector = new vwSector();
        }

        public void SaveSectorExecute()
        {
            if (String.IsNullOrEmpty(Sector.SectorName))
            {
                MessageBox.Show("Please fill field for sector name.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the sector?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (sectors.CalculateNumberOfSectors() > 15)
                        {
                            MessageBox.Show("The maximum number of sectors is 15. Please delete some of the existing ones.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            sectorFormView.Close();
                        }
                        else
                        {
                            bool isCreated = sectors.AddSector(Sector);
                            if (isCreated == true)
                            {
                                MessageBox.Show("Sector is created.", "Notification", MessageBoxButton.OK);
                                sectorFormView.Close();
                            }
                            else
                            {
                                MessageBox.Show("Sector cannot be created.", "Notification", MessageBoxButton.OK);
                                sectorFormView.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanSaveSectorExecute()
        {
            return true;
        }

        public void CancelSectorExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the sector?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    sectorFormView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelSectorExecute()
        {
            return true;
        }
    }
}