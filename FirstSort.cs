using System.Text.RegularExpressions;
//Seyed Erfan Noorbakhsh//

namespace cities
{
    class Datasetsort
    {
        string address = @"D:\digikala\orders.csv";
        private string line;
        public string citysorter()
        {
            List<string> cities = new List<string>();

            using (StreamReader srreader = new StreamReader(address))
            {
                while (!srreader.EndOfStream)
                {
                    line = srreader.ReadLine();
                    cities.Add(Regex.Replace(line, @"(\d|\.|,|:|-| )+", ""));



                    var nonduplicatecitys = cities.Distinct();

                    foreach (string city in nonduplicatecitys)
                    {
                        using (StreamWriter strwriter = new StreamWriter(@"D:\digikala\cities\" + city + ".csv"))
                        {

                            strwriter.WriteLine();

                        }
                    }
                }
            }
            return line;
        }

    }
}
