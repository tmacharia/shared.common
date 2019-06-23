using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.UnitTests
{
    public class ConstantsTests
    {
        private static readonly string Local = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar.ToString();
        private readonly string JsonFile = $"{Local}countries.json";
        private readonly string EnumFile = $"{Local}Country.cs";

        [Test]
        public void GetCurrentRegion()
        {
            var rg = Constants.Region;
            Console.WriteLine(
                "Currency English Name: {0}\n" +
                "Currency Native Name: {1}\n" +
                "Currency Symbol: {2}\n" +
                "ISOCurrencySymbol: {3}\n" +
                "Display Name: {4}\n" +
                "English Name: {5}\n" +
                "Name: {6}\n" +
                "3-Letter-ISO-Region Name: {7}\n" +
                "3-Letter-Windows-Region Name: {8}\n" +
                "2-Letter-ISO-Region Name: {9}",
                rg.CurrencyEnglishName,
                rg.CurrencyNativeName,
                rg.CurrencySymbol,
                rg.ISOCurrencySymbol,
                rg.DisplayName,
                rg.EnglishName,
                rg.Name,
                rg.ThreeLetterISORegionName,
                rg.ThreeLetterWindowsRegionName,
                rg.TwoLetterISORegionName);
        }
        [Test]
        public void GetCurrentCulture()
        {
            PrintCulture(Constants.Culture);
        }
        [Test]
        public void GetCurrentCountry()
        {
            // Act
            var ct = Constants.CurrentCountry;

            Console.WriteLine(ct.ToString());
            Console.WriteLine(ct.GetSymbolAttribute());
        }
        [Test]
        public void GetCultures()
        {
            List<Country> countries = new List<Country>();
            Country selector(CultureInfo x)
            {
                PrintCulture(x);
                RegionInfo ri = new RegionInfo(x.Name);
                return new Country()
                {
                    Name = ri.EnglishName,
                    IsoCode = ri.TwoLetterISORegionName,
                    Currency = ri.CurrencySymbol,
                    CurrencyName = ri.CurrencyEnglishName
                };
            }
            countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(selector)
                .Where(x => !x.IsoCode.IsValidNumber())
                .Distinct(new CountryEquality())
                .OrderBy(x => x.Name)
                .ToList();

            //SaveJson(countries);
            //SaveEnumClass(countries);
        }
        private void PrintCulture(CultureInfo ct)
        {
            //var dayNames = ct.DateTimeFormat.DayNames;
            //var monthNames = ct.DateTimeFormat.MonthNames;
            //PrintFormats(ct.EnglishName, dayNames);
            //PrintFormats(ct.EnglishName, monthNames);
            Console.WriteLine(
                "English Name: {0}\n" +
                "Native Name: {1}\n" +
                "Currency Symbol: {2}\n" +
                "Display Name: {3}\n" +
                "English Name: {4}\n" +
                "Name: {5}\n" +
                "LCID: {6}\n" +
                "ThreeLetterISOLanguageName: {7}\n" +
                "ThreeLetterWindowsLanguageName: {8}\n" +
                "TwoLetterISOLanguageName: {9}\n" +
                "================================\n",
                ct.EnglishName,
                ct.NativeName,
                ct.NumberFormat.CurrencySymbol,
                ct.DisplayName,
                ct.EnglishName,
                ct.Name,
                ct.LCID,
                ct.ThreeLetterISOLanguageName,
                ct.ThreeLetterWindowsLanguageName,
                ct.TwoLetterISOLanguageName.Split(':').Last());
        }
        private void PrintFormats(string country, params string[] args)
        {
            Console.WriteLine("Country: {0}\n" +
                "----------------------------\n" +
                "{1}\n", country, string.Format(", ", args).Trim());
        }
        private void SaveJson(params object[] args)
        {
            string json = args.ToJson();
            File.WriteAllText(JsonFile, json);
        }
        private void SaveEnumClass(List<Country> countries)
        {
            StringBuilder sb = new StringBuilder();
            if (countries != null && countries.Count > 0)
            {
                sb.AppendLine("using Common.Attributes;");
                sb.AppendLine("using System.ComponentModel;");
                sb.AppendLine();
                sb.Append("namespace Common.Enums\n" +
                    "{\n" +
                    "\t/// <summary>\n" +
                    "\t/// Represents supported countries current types.\n" +
                    "\t/// </summary>\n" +
                    "\tpublic enum Country\n" +
                    "\t{\n");
                foreach (var item in countries)
                {
                    sb.Append(
                        "\t\t/// <summary>\n" +
                        $"\t\t/// {item.CurrencyName}. ({item.Name})\n" +
                        $"\t\t/// </summary>\n" +
                        $"\t\t[Description(\"{item.CurrencyName}\")]\n" +
                        $"\t\t[Symbol(\"{item.Currency}\")]\n" +
                        $"\t\t{item.IsoCode.ToUpper()},\n");
                }
                sb.Append("\t}\n}");
            }

            File.WriteAllText(EnumFile, sb.ToString());
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
}