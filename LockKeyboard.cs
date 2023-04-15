//Seyed Erfan Noorbakhsh//
namespace locking
{
    class lockkeyboard
    {
        private string y;
        private string x;
        private int num;
        private ConsoleKeyInfo digit;
        public int keyboardnumberlocker()
        {
            while (true)
            {
                digit = Console.ReadKey(true);
                if (char.IsDigit(digit.KeyChar))
                {
                    num = num * 10 + (int)char.GetNumericValue(digit.KeyChar);
                    Console.Write(digit.KeyChar);
                }
                else
                {
                    Console.Beep();
                }
                if (digit.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
            }
            return num;
        }

        public string keyboardYESORNOlocking()
        {
            do
            {
                x = Console.ReadKey(true).KeyChar.ToString();

            } while (x.ToLower() != "y" & x.ToLower() != "n");
            return x;
        }
        public string menulocking()
        {
            do
            {
                y = Console.ReadKey(true).KeyChar.ToString();

            } while (y.ToLower() != "y" & y.ToLower() != "o" & y.ToLower() != "c" & y.ToLower() != "i" & y.ToLower() != "t");
            return y;
        }
    }
}