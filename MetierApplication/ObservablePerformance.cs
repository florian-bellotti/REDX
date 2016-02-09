using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetierApplication
{
    public class ObservablePerformance
    {
        public event EventHandler SomethingHappened;
        private DataSet data;
        private MappagePerformance mapPerformance;
        private string cpu;
        private string ram;
        private string disk;

        public ObservablePerformance()
        {
            this.mapPerformance = new MappagePerformance();
            this.cpu = "";
            this.ram = "";
            this.disk = "";
            this.data = new DataSet();
        }
        
        public void checkPerformance()
        {
            DataSet data = this.mapPerformance.selectAll();
            while (true)
            {
                bool boolTest = false; 
                data = mapPerformance.selectAll();
                foreach (DataTable table in data.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            switch (column.ToString())
                            {
                                case "RAM":
                                    if (ram != row[column].ToString())
                                    {
                                        ram = row[column].ToString();
                                        boolTest = true;
                                    }
                                    break;
                                case "CPU":
                                    if (cpu != row[column].ToString())
                                    {
                                        cpu = row[column].ToString();
                                        boolTest = true;
                                    }
                                    break;
                                case "Disk":
                                    if (disk != row[column].ToString())
                                    {
                                        disk = row[column].ToString();
                                        boolTest = true;
                                    }
                                    break;
                            }
                        }
                    }
                }

                if (boolTest)
                {
                    EventHandler handler = SomethingHappened;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
                
                Thread.Sleep(1 * 60 * 1000);
            }
        }


        public string[] getAllStates()
        {
            string[] tab = new string[3];
            tab[0] = cpu;
            tab[1] = ram;
            tab[2] = disk;
            return tab;
        }
    }
}
