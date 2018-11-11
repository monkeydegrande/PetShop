using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AniMall
{
    public partial class Login : Window
    {
        //XML Serializer
        static XmlSerializer Xmler = new XmlSerializer(typeof(ObservableCollection<Person>));

        //List of People
        public ObservableCollection<Person> People = new ObservableCollection<Person>();

        //Main csv data file
        static string XmlPath = "People.xml";

        //CONSTRUCTOR
        public Login()
        {
            InitializeComponent();
            ReadPeopleFile();
            userName.Focus();
        }

        //EVENT HANDLERS

        //Create new Person and open AddEditWindow
        private void createUserButton_Click(object sender, RoutedEventArgs e)
        {

            CreateUserWindow newEmployeeWindow = new CreateUserWindow(People);
            userName.Text = "";
            pwBox.Password = "";
            newEmployeeWindow.ShowDialog();

        }

        //If Seller go to seller 
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatAllEntries())
            {
                Person loginTemp = People.FirstOrDefault(user => user.UserName == userName.Text);

                if (loginTemp != null && loginTemp.Password == pwBox.Password)
                {
                    //Seller goes to seller window
                    if (loginTemp.PermLevel == 1)
                    {
                        MainWindow Main = new MainWindow(People, loginTemp);
                        this.Close();
                        Main.ShowDialog();
                    }
                    else
                    {
                        CreateUserWindow employeeHome = new CreateUserWindow(People, loginTemp, false, null);
                        this.Close();
                        employeeHome.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error: Sign In");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error: Sign In");
            }
        }

        //READING AND WRITING FILE FUNCTIONS

        //Read in XML to get Students List 
        public void ReadPeopleFile()
        {
            if (File.Exists(XmlPath))
            {
                try
                {
                    using (FileStream ReadStream = new FileStream(XmlPath, FileMode.Open, FileAccess.Read))
                    {
                        People = Xmler.Deserialize(ReadStream)
                        as ObservableCollection<Person>;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to read XML file", ex.InnerException);
                    MessageBox.Show($"Unable to read XML file\nInnerException:{ ex.InnerException.Message}");
                }
            }
            else
            {
                    CreateUserWindow cuw = new CreateUserWindow(People);
                    this.Close();
                    cuw.ShowDialog();
            }
        }

        //Write to Xml file
        static public void WriteXmlFile(ObservableCollection<Person> People)
        {
            //Ensure there isn't an empty Xml file
            if (People.Count == 0)
            {
                if (File.Exists(XmlPath))
                {
                    File.Delete(XmlPath);
                }
                MessageBox.Show("No data to save. Try adding a emp first.");
            }
            else
            {
                using (FileStream fs = new FileStream(XmlPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    Xmler.Serialize(fs, People);
                }
            }
        }

        // Ensures username and password fields are not empty
        private bool ValidatAllEntries()
        {
            if (string.IsNullOrWhiteSpace(userName.Text))
            { return false; }
            if (string.IsNullOrWhiteSpace(pwBox.Password))
            { return false; }

            return true;
        }
    }
}
