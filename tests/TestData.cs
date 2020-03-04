using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class TestData
    {
#if DEBUG
        public static bool _printToConsole = true;
#else
        public static bool _printToConsole = false;
#endif
        public const string Color1 = "Black";
        public const string Color2 = "White";

        public static string RootDir = Directory.GetCurrentDirectory();
        public static string DocFile = @"C:\Users\george\Source\Repos\Re-Usable Resources\Common\github\Common\XmlDocumentation.xml";
        public static string DocSavePath = @"C:\Users\george\Source\Repos\Re-Usable Resources\Common\github\Docs\README.md";

        public static string[] CarNames = "Bmw,Audi,Golf".Split(',');

        public static void Log(int n) => Log(n.ToString());
        public static void Log(string value) => Log("{0}", value);
        public static void Log(string format, params object[] args)
        {
            if (_printToConsole)
                Console.WriteLine(format, args);
        }
        public static IEnumerable<string> GetTwoLetter_Strings()
        {
            yield return "aa";
            yield return "bb";
            yield return "cc";
            yield return "dd";
        }
    }
    public class Country
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Currency { get; set; }
        public string CurrencyName { get; set; }
    }
    public class CountryEquality : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            return x.IsoCode == y.IsoCode;
        }

        public int GetHashCode(Country obj)
        {
            return obj.IsoCode.GetHashCode();
        }
    }
    public class Car
    {
        public int Id { get; set; } = 10;
        public Car()
        {
            Color = TestData.Color1;
        }
        public Car(string name, string color = TestData.Color1)
        {
            Name = name;
            Color = color;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}