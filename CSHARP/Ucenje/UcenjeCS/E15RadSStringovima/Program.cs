
using System.Globalization;
using System.Text;

namespace UcenjeCS.E15RadSStringovima
{
    internal class Program
    {
        public Program()
        {
            var s = "Edunova";
            Console.WriteLine(s.GetHashCode());

            s = "Osijek";
            Console.WriteLine(s.GetHashCode());

            var sb = new StringBuilder();
            sb.AppendLine("Edunova");
            Console.WriteLine(sb.GetHashCode());

            sb.Clear();

            sb.AppendLine("Osijek");
            Console.WriteLine(sb.GetHashCode());

            s = "a";
            s += " b";
            s += "c";

            Console.WriteLine(s);

            sb = new StringBuilder();
            sb.Append('a');
            sb.Append(" b");
            sb.Append('c');

            Console.WriteLine(sb);

            Console.WriteLine(s.ToLower());
            Console.WriteLine(s.ToUpper());
            s = "Osijek";
            Console.WriteLine(s.Substring(1));
            Console.WriteLine(s.Substring(1, 2));

            s = "    Ana Marija ";
            Console.WriteLine(">{0}<", s);
            Console.WriteLine(">{0}<", s.Trim());

            Console.WriteLine(s.Replace('a', 'b'));
            Console.WriteLine(s.Replace("a", "b", true, CultureInfo.CurrentCulture));
        }
    }
}
