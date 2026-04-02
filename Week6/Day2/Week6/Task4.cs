using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.Week6
{
    public interface IPrinter
    {
        public void Print();

    }
    public interface IScanner
    {
        public void Scan();
    }
    public interface IFax
    {
        public void Fax();
    }
    public class BasicPrinter:IPrinter
    {
        public void Print()
        {
            Console.WriteLine("printer");
        }
    }
    public class AdvancedPrinter: IPrinter,IScanner,IFax
    {
        public void Print()
        {
            Console.WriteLine("printer");
        }
        public void Scan()
        {
            Console.WriteLine("scanner");
        }
        public void Fax()
        {
            Console.WriteLine("Fax");
        }
    }
}
