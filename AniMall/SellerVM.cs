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
        public SellerVM() {}

        private void EditAnimal(object obj)
        {

        }

        public ICommand EditAnimalCommand
        {
            get
            {
                if (_editAnimalEvent == null)
                {
                    _editAnimalEvent = new DelegateCommand(EditAnimal);
                }

                return _editAnimalEvent;
            }
        }
        DelegateCommand _editAnimalEvent;

        public ICommand AddAnimalCommand
        {
            get
            {
                if (_addAnimalEvent == null)
                {
                    _addAnimalEvent = new DelegateCommand(EditAnimal);
                }

                return _addAnimalEvent;
            }
        }
        DelegateCommand _addAnimalEvent;

        public ICommand RemoveAnimalCommand
        {
            get
            {
                if (_removeAnimalEvent == null)
                {
                    _removeAnimalEvent = new DelegateCommand(EditAnimal);
                }

                return _removeAnimalEvent;
            }
        }
        DelegateCommand _removeAnimalEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
