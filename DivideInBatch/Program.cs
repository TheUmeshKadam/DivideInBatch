using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideInBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int batchSize = Int32.Parse(ConfigurationManager.AppSettings["BatchSize"].ToString());
            string commaSeparatedList = ConfigurationManager.AppSettings["CommaSeparatedList"].ToString();

            int itr;

            var items = commaSeparatedList.Split(',');
            List<string> itemsInBatches = new List<string>();
            StringBuilder tempBatch = new StringBuilder();

            for (itr = 1; itr <= items.Length; itr++)
            {
                tempBatch.Append((tempBatch.ToString() == string.Empty ? items[itr - 1].ToString() : (',' + items[itr - 1].ToString())));
                if (itr % batchSize == 0 || itr == items.Length)
                {
                    itemsInBatches.Add(tempBatch.ToString());
                    tempBatch.Clear();
                }
            }

            itr = 1;
            Console.WriteLine("\nFollowing are the batches of given list : ");
            foreach (string batch in itemsInBatches)
            {
                Console.WriteLine( "Batch (" + itr.ToString() + ") : " + batch);
                itr++;
            }
            Console.ReadLine();
        }
    }
}
