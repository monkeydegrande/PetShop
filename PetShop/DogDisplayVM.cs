using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PetShop
{
    public class DogDisplayVM : INotifyPropertyChanged
    {

        public ObservableCollection<Dog> DogCollection { get; set; } = new ObservableCollection<Dog>();

        private Dog selectedDog;
        public Dog SelectedDog
        {
            get { return selectedDog; }
            set
            {
                selectedDog = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedDog"));
            }
        }

        public DogDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            DogCollection = new ObservableCollection<Dog>()
            {
                new Dog("Magoo", "$200", 5, "Labrador",@"\Images\labrador.jpg"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
