using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz
{
    class TestXml:IXml
    {
        public List<Category> Categ { get; set; }
        XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Category>));
       
        public TestXml()
        {
            Categ = new List<Category>();
        }
        public void Write()
        {

            try
            {
                if (File.Exists("TestList.xml"))
                {
                    using (Stream stream = File.Open("TestList.xml", FileMode.Open))
                    {

                        xmlserializer.Serialize(stream, Categ);

                    }
                }
                else
                {

                    using (Stream stream = File.Create("TestList.xml"))
                    {

                        xmlserializer.Serialize(stream, Categ);
                        Console.WriteLine("Test");
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
                using (Stream stream = File.Open("TestList.xml", FileMode.Open))
                {
                    Categ = (List<Category>)xmlserializer.Deserialize(stream);

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddNew(Category c)
        {

            if (File.Exists("TestList.xml")) Read();
                Categ.Add(c);

        }

    }
}
