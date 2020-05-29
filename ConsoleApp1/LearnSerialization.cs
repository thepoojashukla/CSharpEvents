using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace InternalAssessment
{
    [Serializable] //Serialized class cannot be inherited
    public class Sample
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class LearnSerialization
    {
        public void TestSerialize()
        {
            Sample mySample = new Sample();
            mySample.id = 5;
            mySample.name = "Pooja";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Soller\\TestSerialize.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, mySample);
        }

        public Sample TestDeserialize()
        {
            try
            {
                Sample sample = new Sample();
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("C:\\Soller\\TestSerialize.txt", FileMode.Open, FileAccess.Read);
                return  sample = (Sample)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Got some error: {ex.Message}");
                throw;
            }
            
        }
    }
}
