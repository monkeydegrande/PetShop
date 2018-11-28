using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace AniMall
{
    public class SellerVM : INotifyPropertyChanged
    {
        #region Properties
        Person User;
        MainWindowVM MVM;

        private ObservableCollection<Animal> products;
        public ObservableCollection<Animal> Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }
        #endregion

//CONSTRUCTOR
        public SellerVM(MainWindowVM mvm)
        {
            User = mvm.User;
            Products = mvm.Products;
            MVM = mvm;
        }

//DELGATES AND EVENT HANDLRES
        private void EditAnimal(object obj)
        {

        }
        public ICommand EditAnimalCommand
        {
            get
            {
                if (editAnimalEvent == null)
                {
                    editAnimalEvent = new DelegateCommand(EditAnimal);
                }

                return editAnimalEvent;
            }
        }
        DelegateCommand editAnimalEvent;

        private void AddAnimal(object obj)
        {

        }
        public ICommand AddAnimalCommand
        {
            get
            {
                if (addAnimalEvent == null)
                {
                    addAnimalEvent = new DelegateCommand(EditAnimal);
                }

                return addAnimalEvent;
            }
        }
        DelegateCommand addAnimalEvent;

        private void RemoveAnimal(object obj)
        {

        }
        public ICommand RemoveAnimalCommand
        {
            get
            {
                if (removeAnimalEvent == null)
                {
                    removeAnimalEvent = new DelegateCommand(RemoveAnimal);
                }

                return removeAnimalEvent;
            }
        }
        DelegateCommand removeAnimalEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
