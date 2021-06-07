using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz
{
    public class UserXml : IXml
    {
        public  List<User> Users { get; set; }
        XmlSerializer xmlserializer = new XmlSerializer(typeof(List<User>));
        public UserXml()
        {
            Users = new List<User>();

        }
        public void Write()
        {

            try
            {
                if (File.Exists("userList.xml"))
                {
                    using (Stream stream = File.Open("userList.xml", FileMode.Open))
                    {

                        xmlserializer.Serialize(stream, Users);

                    }
                }
                else
                {

                    using (Stream stream = File.Create("userList.xml"))
                    {

                        xmlserializer.Serialize(stream, Users);

                    }


                }
            }
            catch (Exception)
            {

                throw;
            } 
        }
        public void Read()
        {
            try
            {
                using (Stream stream = File.Open("userList.xml",FileMode.Open))
                {
                    Users = (List<User>)xmlserializer.Deserialize(stream);

                }
              
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddUser(User u) {

            if (File.Exists("userList.xml")) Read();
            Users.Add(u);
            
        }


    }
}
