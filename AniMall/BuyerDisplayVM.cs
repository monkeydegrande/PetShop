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
    public class BuyerDisplayVM : INotifyPropertyChanged
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

        public BuyerDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {
            Animals = new ObservableCollection<Animal>();

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
