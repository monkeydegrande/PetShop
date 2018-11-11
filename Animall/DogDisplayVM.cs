using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml.Serialization;

namespace Animall
{
    public class DogDisplayVM : INotifyPropertyChanged
    {
        readonly string path = "stockPath.xml";
        XmlSerializer Xmler = new XmlSerializer(typeof(ObservableCollection<Dog>));
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
                new Dog("Magoo", 200.00, 5, "Labrador",@"\Images\labrador.jpg"),
            };
            //Read in stock information information from previous session, stored in XML file
            try { ReadStockFile(); }

            catch (Exception ex)
            {
                Console.WriteLine("Unable to read file", ex.InnerException);
                MessageBox.Show($"Unable to read xml file\nInnerException:{ ex.InnerException.Message}");
            }
        }
        //Read in stock XML
        private void ReadStockFile()
        {
            if (File.Exists(path))
            {
                using (FileStream ReadStream = new FileStream(path,
                FileMode.Open, FileAccess.Read))
                {
                    DogCollection = Xmler.Deserialize(ReadStream)
                    as ObservableCollection<Dog>;
                }
            }

        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
