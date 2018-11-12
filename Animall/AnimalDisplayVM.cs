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
        static readonly string StockPath = "stock.xml";
        static XmlSerializer Xmler = new XmlSerializer(typeof(ObservableCollection<Animal>));
        public ObservableCollection<Animal> Animals { get; set; } = new ObservableCollection<Animal>();

        private Animal selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                selectedAnimal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedAnimal"));
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
                new Animal("Labrador Dog", "Friendly bugger", 299.99, 5, @"\Images\labrador.jpg"),
                new Animal("French Bulldog", "Friendly and cute", 449.99, 9, @"\Images\frenchy.jpg"),
                new Animal("Gerbil", "Spastic and cute", 10.99, 12, @"\Images\gerbil.jpg"),
                new Animal("Pangolin", "Totally illegal but, really badass", 15999.99, 2, @"\Images\pangolin.jpg"),
                new Animal("Pterodactyl", "Relatively docile, but need a REALLY big home", 899895.99, 1, @"\Images\pterodactyl.jpg"),
                new Animal("Ragdoll Cat", "Pretty and lazy", 1999.99, 3, @"\Images\ragdoll.jpg"),
                new Animal("Toucan", "Pretty but, never shuts up about Fruit Loops", 699.99, 4, @"\Images\toucan.jpg"),
                new Animal("Velociraptor", "Complete jerk, but you'll never have to worry about burglars", 789987.99, 3, @"\Images\velociraptor.jpg"),
                new Animal("Siamese Cat", "Pretty, but kind of jerks", 450.99, 2, @"\Images\siamese.jpg"),
            };
            WriteStockFile(Animals);
            //Read in stock information information from previous session, stored in XML file
            try { ReadStockFile(); }

            catch (Exception ex)
            {
                Console.WriteLine("Unable to read file", ex.InnerException);
                MessageBox.Show($"Unable to read xml file\nInnerException:{ ex.InnerException.Message}");
            }
        }

        //Write stock file
        static public void WriteStockFile(ObservableCollection<Animal> Animals)
        {
            //Ensure there isn't an empty Xml file
            if (Animals.Count == 0)
            {
                if (File.Exists(StockPath))
                {
                    File.Delete(StockPath);
                }
                MessageBox.Show("No data to save. Try adding an animal first.");
            }
            else
            {
                using (FileStream fs = new FileStream(StockPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    Xmler.Serialize(fs, Animals);
                }
            }
        }

        //Read in stock XML
        private void ReadStockFile()
        {
            if (File.Exists(StockPath))
            {
                using (FileStream ReadStream = new FileStream(StockPath, FileMode.Open, FileAccess.Read))
                {
                    Animals = Xmler.Deserialize(ReadStream)
                    as ObservableCollection<Animal>;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
