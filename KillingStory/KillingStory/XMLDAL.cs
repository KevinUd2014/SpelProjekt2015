using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace KillingStory
{   //https://msdn.microsoft.com/en-us/library/twcad0zb.aspx
    class XMLDAL<T>
    {//hittade en bra video på youtube om detta som jag kollade på!
        public Type type;

        public T Load(string path)//denna ska ladda in från xml filen!
        {
            T instance;
            using (TextReader reader = new StreamReader(path))//bin\Windows\Debug\ detta är output utan serialize
            {
                XmlSerializer xml = new XmlSerializer(type);
                instance = (T)xml.Deserialize(reader);//konverterar till type T
            }
            return instance;
        }
        public void Save(string path, object obj)//denna kommer skriva sparningar senare!
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
