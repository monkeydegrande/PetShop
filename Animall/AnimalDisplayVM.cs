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

namespace AniMall
{
    public class AnimalDisplayVM : INotifyPropertyChanged
    {
        readonly string path = "stockPath.xml";
        XmlSerializer Xmler = new XmlSerializer(typeof(ObservableCollection<Animal>));
        public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal>();

        private Animal selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                selectedAnimal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedDog"));
            }
        }

        public AnimalDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {
            Animals = new ObservableCollection<Animal>()
            {
                new Animal("Magoo", 200.00, 5, "Labrador",@"\Images\labrador.jpg")
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
                    Animals = Xmler.Deserialize(ReadStream)
                    as ObservableCollection<Animal>;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
