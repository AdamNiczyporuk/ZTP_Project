using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;


namespace ZTP_Project.TemplateMethod
{
    public abstract class Exporter
    {
        public  void Save(string path,List<Transaction> transaction)
        {
            StreamWriter sw = OpenFile(path);
            InsertData(sw, transaction);
            CloseFile(sw);
           
        }

        protected abstract StreamWriter OpenFile(string path);


        protected abstract void InsertData(StreamWriter sw, List<Transaction> transaction);


        protected void CloseFile(StreamWriter sw)
        {
            sw.Close();
        }

    }
}
