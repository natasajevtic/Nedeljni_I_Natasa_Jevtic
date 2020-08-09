using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManageSectorsViewModel : BaseViewModel
    {
        ManageSectorsView manageSectorsView;
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

        private List<vwSector> sectorList;

        public List<vwSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }

        private ICommand addSector;
        public ICommand AddSector
        {
            get
            {
                if (addSector == null)
                {
                    addSector = new RelayCommand(param => AddSectorExecute(), param => CanAddSectorExecute());
                }
                return addSector;
            }
        }

        private ICommand deleteSector;
        public ICommand DeleteSector
        {
            get
            {
                if (deleteSector == null)
                {
                    deleteSector = new RelayCommand(param => DeleteSectorExecute(), param => CanDeleteSectorExecute());
                }
                return deleteSector;
            }
        }

        public ManageSectorsViewModel(ManageSectorsView manageSectorsView)
        {
            this.manageSectorsView = manageSectorsView;
            SectorList = sectors.GetAllSectors();
        }

        public void AddSectorExecute()
        {
            try
            {
                if (sectors.CalculateNumberOfSectors() < 15)
                {
                    SectorFormView form = new SectorFormView();
                    form.ShowDialog();
                    SectorList = sectors.GetAllSectors();
                }
                else
                {
                    MessageBox.Show("The maximum number of sectors is 15. Please delete some of the existing ones.", "Notification", MessageBoxButton.OK);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddSectorExecute()
        {
            return true;
        }

        public void DeleteSectorExecute()
        {
            try
            {
                if (Sector != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this sector?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = sectors.DeleteSector(Sector);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Sector is deleted.", "Notification", MessageBoxButton.OK);
                            SectorList = sectors.GetAllSectors();
                        }
                        else
                        {
                            MessageBox.Show("Sector cannot be deleted.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeleteSectorExecute()
        {
            if (Sector != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}