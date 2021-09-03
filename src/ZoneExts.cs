﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Common.Enums;
using Common.Models;
using Newtonsoft.Json;

namespace Common
{
    /// <summary>
    /// Contains methods &amp; properties for identifying a machine's Local TimeZone Info &amp; Region
    /// </summary>
    public static class ZoneExts
    {
        private static string _currentGeoName = string.Empty;
        private static RegionInfo _region = null;

        /// <summary>
        /// Current International Geographical Name/2-Letter ISO Code
        /// </summary>
        public static string CurrentGeo
        {
            get
            {
                if (!_currentGeoName.IsValid())
                    _currentGeoName = GetCurrentZone();
                return _currentGeoName;
            }
        }
        /// <summary>
        /// Gets the current <see cref="RegionInfo"/>
        /// </summary>
        public static RegionInfo Region
        {
            get
            {
                if (_region == null)
                    _region = new RegionInfo(CurrentGeo);
                return _region;
            }
        }
        /// <summary>
        /// Current Country
        /// </summary>
        public static Country CurrentCountry => (Country)Enum.Parse(typeof(Country), CurrentGeo);
        /// <summary>
        /// Returns the ISO-2 Digit Code that represent the country in which the current machine's 
        /// local time zone info is.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentZone()
        {
            try
            {
                var zone = GetCurrentZoneInfo();
                if (zone != null)
                    return zone.Code;
            }
            catch (Exception)
            {  }
            return RegionInfo.CurrentRegion.TwoLetterISORegionName;
        }
        /// <summary>
        /// Gets the <see cref="ZoneInfo"/> of the current machine based on its local time zone.
        /// </summary>
        /// <returns><see cref="ZoneInfo"/></returns>
        public static ZoneInfo GetCurrentZoneInfo()
        {
            TimeZoneInfo zone = TimeZoneInfo.Local;
            string name = Regex.Replace(zone.DisplayName, @"\(UTC[+|-]([0-9]{2}):([0-9]{2})\)", "").Trim();
            var zones = GetZoneInfos();
            return zones.FirstOrDefault(x => x.Name.Matches(name));
        }
        /// <summary>
        /// Reads TimeZoneInfo json data and returns it as a list of <see cref="ZoneInfo"/>
        /// </summary>
        /// <returns></returns>
        private static List<ZoneInfo> GetZoneInfos() => Data.DeserializeTo<List<ZoneInfo>>(ReferenceLoopHandling.Ignore);

        #region Data Region
        /// <summary>
        /// Json array of timezone info names and their corresponding country names
        /// </summary>
        private static string Data =>
            "[{\"Code\":\"AD\",\"Name\":\"Europe Andorra\"},{\"Code\":\"AE\",\"Name\":\"Asia Dubai\"},{\"Code\":\"AF\",\"Name\":\"Asia Kabul\"},{\"Code\":\"AG\",\"Name\":\"America Antigua\"},{\"Code\":\"AI\",\"Name\":\"America Anguilla\"},{\"Code\":\"AL\",\"Name\":\"Europe Tirane\"},{\"Code\":\"AM\",\"Name\":\"Asia Yerevan\"},{\"Code\":\"AO\",\"Name\":\"Africa Luanda\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica McMurdo\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Casey\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Davis\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica DumontDUrville\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Mawson\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Palmer\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Rothera\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Syowa\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Troll\"},{\"Code\":\"AQ\",\"Name\":\"Antarctica Vostok\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Buenos_Aires\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Cordoba\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Salta\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Jujuy\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Tucuman\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Catamarca\"},{\"Code\":\"AR\",\"Name\":\"America Argentina La_Rioja\"},{\"Code\":\"AR\",\"Name\":\"America Argentina San_Juan\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Mendoza\"},{\"Code\":\"AR\",\"Name\":\"America Argentina San_Luis\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Rio_Gallegos\"},{\"Code\":\"AR\",\"Name\":\"America Argentina Ushuaia\"},{\"Code\":\"AS\",\"Name\":\"Pacific Pago_Pago\"},{\"Code\":\"AT\",\"Name\":\"Europe Vienna\"},{\"Code\":\"AU\",\"Name\":\"Australia Lord_Howe\"},{\"Code\":\"AU\",\"Name\":\"Antarctica Macquarie\"},{\"Code\":\"AU\",\"Name\":\"Australia Hobart\"},{\"Code\":\"AU\",\"Name\":\"Australia Currie\"},{\"Code\":\"AU\",\"Name\":\"Australia Melbourne\"},{\"Code\":\"AU\",\"Name\":\"Australia Sydney\"},{\"Code\":\"AU\",\"Name\":\"Australia Broken_Hill\"},{\"Code\":\"AU\",\"Name\":\"Australia Brisbane\"},{\"Code\":\"AU\",\"Name\":\"Australia Lindeman\"},{\"Code\":\"AU\",\"Name\":\"Australia Adelaide\"},{\"Code\":\"AU\",\"Name\":\"Australia Darwin\"},{\"Code\":\"AU\",\"Name\":\"Australia Perth\"},{\"Code\":\"AU\",\"Name\":\"Australia Eucla\"},{\"Code\":\"AW\",\"Name\":\"America Aruba\"},{\"Code\":\"AX\",\"Name\":\"Europe Mariehamn\"},{\"Code\":\"AZ\",\"Name\":\"Asia Baku\"},{\"Code\":\"BA\",\"Name\":\"Europe Sarajevo\"},{\"Code\":\"BB\",\"Name\":\"America Barbados\"},{\"Code\":\"BD\",\"Name\":\"Asia Dhaka\"},{\"Code\":\"BE\",\"Name\":\"Europe Brussels\"},{\"Code\":\"BF\",\"Name\":\"Africa Ouagadougou\"},{\"Code\":\"BG\",\"Name\":\"Europe Sofia\"},{\"Code\":\"BH\",\"Name\":\"Asia Bahrain\"},{\"Code\":\"BI\",\"Name\":\"Africa Bujumbura\"},{\"Code\":\"BJ\",\"Name\":\"Africa Porto-Novo\"},{\"Code\":\"BL\",\"Name\":\"America St_Barthelemy\"},{\"Code\":\"BM\",\"Name\":\"Atlantic Bermuda\"},{\"Code\":\"BN\",\"Name\":\"Asia Brunei\"},{\"Code\":\"BO\",\"Name\":\"America La_Paz\"},{\"Code\":\"BQ\",\"Name\":\"America Kralendijk\"},{\"Code\":\"BR\",\"Name\":\"America Noronha\"},{\"Code\":\"BR\",\"Name\":\"America Belem\"},{\"Code\":\"BR\",\"Name\":\"America Fortaleza\"},{\"Code\":\"BR\",\"Name\":\"America Recife\"},{\"Code\":\"BR\",\"Name\":\"America Araguaina\"},{\"Code\":\"BR\",\"Name\":\"America Maceio\"},{\"Code\":\"BR\",\"Name\":\"America Bahia\"},{\"Code\":\"BR\",\"Name\":\"America Sao_Paulo\"},{\"Code\":\"BR\",\"Name\":\"America Campo_Grande\"},{\"Code\":\"BR\",\"Name\":\"America Cuiaba\"},{\"Code\":\"BR\",\"Name\":\"America Santarem\"},{\"Code\":\"BR\",\"Name\":\"America Porto_Velho\"},{\"Code\":\"BR\",\"Name\":\"America Boa_Vista\"},{\"Code\":\"BR\",\"Name\":\"America Manaus\"},{\"Code\":\"BR\",\"Name\":\"America Eirunepe\"},{\"Code\":\"BR\",\"Name\":\"America Rio_Branco\"},{\"Code\":\"BS\",\"Name\":\"America Nassau\"},{\"Code\":\"BT\",\"Name\":\"Asia Thimphu\"},{\"Code\":\"BW\",\"Name\":\"Africa Gaborone\"},{\"Code\":\"BY\",\"Name\":\"Europe Minsk\"},{\"Code\":\"BZ\",\"Name\":\"America Belize\"},{\"Code\":\"CA\",\"Name\":\"America St_Johns\"},{\"Code\":\"CA\",\"Name\":\"America Halifax\"},{\"Code\":\"CA\",\"Name\":\"America Glace_Bay\"},{\"Code\":\"CA\",\"Name\":\"America Moncton\"},{\"Code\":\"CA\",\"Name\":\"America Goose_Bay\"},{\"Code\":\"CA\",\"Name\":\"America Blanc-Sablon\"},{\"Code\":\"CA\",\"Name\":\"America Toronto\"},{\"Code\":\"CA\",\"Name\":\"America Nipigon\"},{\"Code\":\"CA\",\"Name\":\"America Thunder_Bay\"},{\"Code\":\"CA\",\"Name\":\"America Iqaluit\"},{\"Code\":\"CA\",\"Name\":\"America Pangnirtung\"},{\"Code\":\"CA\",\"Name\":\"America Atikokan\"},{\"Code\":\"CA\",\"Name\":\"America Winnipeg\"},{\"Code\":\"CA\",\"Name\":\"America Rainy_River\"},{\"Code\":\"CA\",\"Name\":\"America Resolute\"},{\"Code\":\"CA\",\"Name\":\"America Rankin_Inlet\"},{\"Code\":\"CA\",\"Name\":\"America Regina\"},{\"Code\":\"CA\",\"Name\":\"America Swift_Current\"},{\"Code\":\"CA\",\"Name\":\"America Edmonton\"},{\"Code\":\"CA\",\"Name\":\"America Cambridge_Bay\"},{\"Code\":\"CA\",\"Name\":\"America Yellowknife\"},{\"Code\":\"CA\",\"Name\":\"America Inuvik\"},{\"Code\":\"CA\",\"Name\":\"America Creston\"},{\"Code\":\"CA\",\"Name\":\"America Dawson_Creek\"},{\"Code\":\"CA\",\"Name\":\"America Fort_Nelson\"},{\"Code\":\"CA\",\"Name\":\"America Vancouver\"},{\"Code\":\"CA\",\"Name\":\"America Whitehorse\"},{\"Code\":\"CA\",\"Name\":\"America Dawson\"},{\"Code\":\"CC\",\"Name\":\"Indian Cocos\"},{\"Code\":\"CD\",\"Name\":\"Africa Kinshasa\"},{\"Code\":\"CD\",\"Name\":\"Africa Lubumbashi\"},{\"Code\":\"CF\",\"Name\":\"Africa Bangui\"},{\"Code\":\"CG\",\"Name\":\"Africa Brazzaville\"},{\"Code\":\"CH\",\"Name\":\"Europe Zurich\"},{\"Code\":\"CI\",\"Name\":\"Africa Abidjan\"},{\"Code\":\"CK\",\"Name\":\"Pacific Rarotonga\"},{\"Code\":\"CL\",\"Name\":\"America Santiago\"},{\"Code\":\"CL\",\"Name\":\"America Punta_Arenas\"},{\"Code\":\"CL\",\"Name\":\"Pacific Easter\"},{\"Code\":\"CM\",\"Name\":\"Africa Douala\"},{\"Code\":\"CN\",\"Name\":\"Asia Shanghai\"},{\"Code\":\"CN\",\"Name\":\"Asia Urumqi\"},{\"Code\":\"CO\",\"Name\":\"America Bogota\"},{\"Code\":\"CR\",\"Name\":\"America Costa_Rica\"},{\"Code\":\"CU\",\"Name\":\"America Havana\"},{\"Code\":\"CV\",\"Name\":\"Atlantic Cape_Verde\"},{\"Code\":\"CW\",\"Name\":\"America Curacao\"},{\"Code\":\"CX\",\"Name\":\"Indian Christmas\"},{\"Code\":\"CY\",\"Name\":\"Asia Nicosia\"},{\"Code\":\"CY\",\"Name\":\"Asia Famagusta\"},{\"Code\":\"CZ\",\"Name\":\"Europe Prague\"},{\"Code\":\"DE\",\"Name\":\"Europe Berlin\"},{\"Code\":\"DE\",\"Name\":\"Europe Busingen\"},{\"Code\":\"DJ\",\"Name\":\"Africa Djibouti\"},{\"Code\":\"DK\",\"Name\":\"Europe Copenhagen\"},{\"Code\":\"DM\",\"Name\":\"America Dominica\"},{\"Code\":\"DO\",\"Name\":\"America Santo_Domingo\"},{\"Code\":\"DZ\",\"Name\":\"Africa Algiers\"},{\"Code\":\"EC\",\"Name\":\"America Guayaquil\"},{\"Code\":\"EC\",\"Name\":\"Pacific Galapagos\"},{\"Code\":\"EE\",\"Name\":\"Europe Tallinn\"},{\"Code\":\"EG\",\"Name\":\"Africa Cairo\"},{\"Code\":\"EH\",\"Name\":\"Africa El_Aaiun\"},{\"Code\":\"ER\",\"Name\":\"Africa Asmara\"},{\"Code\":\"ES\",\"Name\":\"Europe Madrid\"},{\"Code\":\"ES\",\"Name\":\"Africa Ceuta\"},{\"Code\":\"ES\",\"Name\":\"Atlantic Canary\"},{\"Code\":\"ET\",\"Name\":\"Africa Addis_Ababa\"},{\"Code\":\"FI\",\"Name\":\"Europe Helsinki\"},{\"Code\":\"FJ\",\"Name\":\"Pacific Fiji\"},{\"Code\":\"FK\",\"Name\":\"Atlantic Stanley\"},{\"Code\":\"FM\",\"Name\":\"Pacific Chuuk\"},{\"Code\":\"FM\",\"Name\":\"Pacific Pohnpei\"},{\"Code\":\"FM\",\"Name\":\"Pacific Kosrae\"},{\"Code\":\"FO\",\"Name\":\"Atlantic Faroe\"},{\"Code\":\"FR\",\"Name\":\"Europe Paris\"},{\"Code\":\"GA\",\"Name\":\"Africa Libreville\"},{\"Code\":\"GB\",\"Name\":\"Europe London\"},{\"Code\":\"GD\",\"Name\":\"America Grenada\"},{\"Code\":\"GE\",\"Name\":\"Asia Tbilisi\"},{\"Code\":\"GF\",\"Name\":\"America Cayenne\"},{\"Code\":\"GG\",\"Name\":\"Europe Guernsey\"},{\"Code\":\"GH\",\"Name\":\"Africa Accra\"},{\"Code\":\"GI\",\"Name\":\"Europe Gibraltar\"},{\"Code\":\"GL\",\"Name\":\"America Godthab\"},{\"Code\":\"GL\",\"Name\":\"America Danmarkshavn\"},{\"Code\":\"GL\",\"Name\":\"America Scoresbysund\"},{\"Code\":\"GL\",\"Name\":\"America Thule\"},{\"Code\":\"GM\",\"Name\":\"Africa Banjul\"},{\"Code\":\"GN\",\"Name\":\"Africa Conakry\"},{\"Code\":\"GP\",\"Name\":\"America Guadeloupe\"},{\"Code\":\"GQ\",\"Name\":\"Africa Malabo\"},{\"Code\":\"GR\",\"Name\":\"Europe Athens\"},{\"Code\":\"GS\",\"Name\":\"Atlantic South_Georgia\"},{\"Code\":\"GT\",\"Name\":\"America Guatemala\"},{\"Code\":\"GU\",\"Name\":\"Pacific Guam\"},{\"Code\":\"GW\",\"Name\":\"Africa Bissau\"},{\"Code\":\"GY\",\"Name\":\"America Guyana\"},{\"Code\":\"HK\",\"Name\":\"Asia Hong_Kong\"},{\"Code\":\"HN\",\"Name\":\"America Tegucigalpa\"},{\"Code\":\"HR\",\"Name\":\"Europe Zagreb\"},{\"Code\":\"HT\",\"Name\":\"America Port-au-Prince\"},{\"Code\":\"HU\",\"Name\":\"Europe Budapest\"},{\"Code\":\"ID\",\"Name\":\"Asia Jakarta\"},{\"Code\":\"ID\",\"Name\":\"Asia Pontianak\"},{\"Code\":\"ID\",\"Name\":\"Asia Makassar\"},{\"Code\":\"ID\",\"Name\":\"Asia Jayapura\"},{\"Code\":\"IE\",\"Name\":\"Europe Dublin\"},{\"Code\":\"IL\",\"Name\":\"Asia Jerusalem\"},{\"Code\":\"IM\",\"Name\":\"Europe Isle_of_Man\"},{\"Code\":\"IN\",\"Name\":\"Asia Kolkata\"},{\"Code\":\"IO\",\"Name\":\"Indian Chagos\"},{\"Code\":\"IQ\",\"Name\":\"Asia Baghdad\"},{\"Code\":\"IR\",\"Name\":\"Asia Tehran\"},{\"Code\":\"IS\",\"Name\":\"Atlantic Reykjavik\"},{\"Code\":\"IT\",\"Name\":\"Europe Rome\"},{\"Code\":\"JE\",\"Name\":\"Europe Jersey\"},{\"Code\":\"JM\",\"Name\":\"America Jamaica\"},{\"Code\":\"JO\",\"Name\":\"Asia Amman\"},{\"Code\":\"JP\",\"Name\":\"Asia Tokyo\"},{\"Code\":\"KE\",\"Name\":\"Africa Nairobi\"},{\"Code\":\"KG\",\"Name\":\"Asia Bishkek\"},{\"Code\":\"KH\",\"Name\":\"Asia Phnom_Penh\"},{\"Code\":\"KI\",\"Name\":\"Pacific Tarawa\"},{\"Code\":\"KI\",\"Name\":\"Pacific Enderbury\"},{\"Code\":\"KI\",\"Name\":\"Pacific Kiritimati\"},{\"Code\":\"KM\",\"Name\":\"Indian Comoro\"},{\"Code\":\"KN\",\"Name\":\"America St_Kitts\"},{\"Code\":\"KP\",\"Name\":\"Asia Pyongyang\"},{\"Code\":\"KR\",\"Name\":\"Asia Seoul\"},{\"Code\":\"KW\",\"Name\":\"Asia Kuwait\"},{\"Code\":\"KY\",\"Name\":\"America Cayman\"},{\"Code\":\"KZ\",\"Name\":\"Asia Almaty\"},{\"Code\":\"KZ\",\"Name\":\"Asia Qyzylorda\"},{\"Code\":\"KZ\",\"Name\":\"Asia Qostanay\"},{\"Code\":\"KZ\",\"Name\":\"Asia Aqtobe\"},{\"Code\":\"KZ\",\"Name\":\"Asia Aqtau\"},{\"Code\":\"KZ\",\"Name\":\"Asia Atyrau\"},{\"Code\":\"KZ\",\"Name\":\"Asia Oral\"},{\"Code\":\"LA\",\"Name\":\"Asia Vientiane\"},{\"Code\":\"LB\",\"Name\":\"Asia Beirut\"},{\"Code\":\"LC\",\"Name\":\"America St_Lucia\"},{\"Code\":\"LI\",\"Name\":\"Europe Vaduz\"},{\"Code\":\"LK\",\"Name\":\"Asia Colombo\"},{\"Code\":\"LR\",\"Name\":\"Africa Monrovia\"},{\"Code\":\"LS\",\"Name\":\"Africa Maseru\"},{\"Code\":\"LT\",\"Name\":\"Europe Vilnius\"},{\"Code\":\"LU\",\"Name\":\"Europe Luxembourg\"},{\"Code\":\"LV\",\"Name\":\"Europe Riga\"},{\"Code\":\"LY\",\"Name\":\"Africa Tripoli\"},{\"Code\":\"MA\",\"Name\":\"Africa Casablanca\"},{\"Code\":\"MC\",\"Name\":\"Europe Monaco\"},{\"Code\":\"MD\",\"Name\":\"Europe Chisinau\"},{\"Code\":\"ME\",\"Name\":\"Europe Podgorica\"},{\"Code\":\"MF\",\"Name\":\"America Marigot\"},{\"Code\":\"MG\",\"Name\":\"Indian Antananarivo\"},{\"Code\":\"MH\",\"Name\":\"Pacific Majuro\"},{\"Code\":\"MH\",\"Name\":\"Pacific Kwajalein\"},{\"Code\":\"MK\",\"Name\":\"Europe Skopje\"},{\"Code\":\"ML\",\"Name\":\"Africa Bamako\"},{\"Code\":\"MM\",\"Name\":\"Asia Yangon\"},{\"Code\":\"MN\",\"Name\":\"Asia Ulaanbaatar\"},{\"Code\":\"MN\",\"Name\":\"Asia Hovd\"},{\"Code\":\"MN\",\"Name\":\"Asia Choibalsan\"},{\"Code\":\"MO\",\"Name\":\"Asia Macau\"},{\"Code\":\"MP\",\"Name\":\"Pacific Saipan\"},{\"Code\":\"MQ\",\"Name\":\"America Martinique\"},{\"Code\":\"MR\",\"Name\":\"Africa Nouakchott\"},{\"Code\":\"MS\",\"Name\":\"America Montserrat\"},{\"Code\":\"MT\",\"Name\":\"Europe Malta\"},{\"Code\":\"MU\",\"Name\":\"Indian Mauritius\"},{\"Code\":\"MV\",\"Name\":\"Indian Maldives\"},{\"Code\":\"MW\",\"Name\":\"Africa Blantyre\"},{\"Code\":\"MX\",\"Name\":\"America Mexico_City\"},{\"Code\":\"MX\",\"Name\":\"America Cancun\"},{\"Code\":\"MX\",\"Name\":\"America Merida\"},{\"Code\":\"MX\",\"Name\":\"America Monterrey\"},{\"Code\":\"MX\",\"Name\":\"America Matamoros\"},{\"Code\":\"MX\",\"Name\":\"America Mazatlan\"},{\"Code\":\"MX\",\"Name\":\"America Chihuahua\"},{\"Code\":\"MX\",\"Name\":\"America Ojinaga\"},{\"Code\":\"MX\",\"Name\":\"America Hermosillo\"},{\"Code\":\"MX\",\"Name\":\"America Tijuana\"},{\"Code\":\"MX\",\"Name\":\"America Bahia_Banderas\"},{\"Code\":\"MY\",\"Name\":\"Asia Kuala_Lumpur\"},{\"Code\":\"MY\",\"Name\":\"Asia Kuching\"},{\"Code\":\"MZ\",\"Name\":\"Africa Maputo\"},{\"Code\":\"NA\",\"Name\":\"Africa Windhoek\"},{\"Code\":\"NC\",\"Name\":\"Pacific Noumea\"},{\"Code\":\"NE\",\"Name\":\"Africa Niamey\"},{\"Code\":\"NF\",\"Name\":\"Pacific Norfolk\"},{\"Code\":\"NG\",\"Name\":\"Africa Lagos\"},{\"Code\":\"NI\",\"Name\":\"America Managua\"},{\"Code\":\"NL\",\"Name\":\"Europe Amsterdam\"},{\"Code\":\"NO\",\"Name\":\"Europe Oslo\"},{\"Code\":\"NP\",\"Name\":\"Asia Kathmandu\"},{\"Code\":\"NR\",\"Name\":\"Pacific Nauru\"},{\"Code\":\"NU\",\"Name\":\"Pacific Niue\"},{\"Code\":\"NZ\",\"Name\":\"Pacific Auckland\"},{\"Code\":\"NZ\",\"Name\":\"Pacific Chatham\"},{\"Code\":\"OM\",\"Name\":\"Asia Muscat\"},{\"Code\":\"PA\",\"Name\":\"America Panama\"},{\"Code\":\"PE\",\"Name\":\"America Lima\"},{\"Code\":\"PF\",\"Name\":\"Pacific Tahiti\"},{\"Code\":\"PF\",\"Name\":\"Pacific Marquesas\"},{\"Code\":\"PF\",\"Name\":\"Pacific Gambier\"},{\"Code\":\"PG\",\"Name\":\"Pacific Port_Moresby\"},{\"Code\":\"PG\",\"Name\":\"Pacific Bougainville\"},{\"Code\":\"PH\",\"Name\":\"Asia Manila\"},{\"Code\":\"PK\",\"Name\":\"Asia Karachi\"},{\"Code\":\"PL\",\"Name\":\"Europe Warsaw\"},{\"Code\":\"PM\",\"Name\":\"America Miquelon\"},{\"Code\":\"PN\",\"Name\":\"Pacific Pitcairn\"},{\"Code\":\"PR\",\"Name\":\"America Puerto_Rico\"},{\"Code\":\"PS\",\"Name\":\"Asia Gaza\"},{\"Code\":\"PS\",\"Name\":\"Asia Hebron\"},{\"Code\":\"PT\",\"Name\":\"Europe Lisbon\"},{\"Code\":\"PT\",\"Name\":\"Atlantic Madeira\"},{\"Code\":\"PT\",\"Name\":\"Atlantic Azores\"},{\"Code\":\"PW\",\"Name\":\"Pacific Palau\"},{\"Code\":\"PY\",\"Name\":\"America Asuncion\"},{\"Code\":\"QA\",\"Name\":\"Asia Qatar\"},{\"Code\":\"RE\",\"Name\":\"Indian Reunion\"},{\"Code\":\"RO\",\"Name\":\"Europe Bucharest\"},{\"Code\":\"RS\",\"Name\":\"Europe Belgrade\"},{\"Code\":\"RU\",\"Name\":\"Europe Kaliningrad\"},{\"Code\":\"RU\",\"Name\":\"Europe Moscow\"},{\"Code\":\"UA\",\"Name\":\"Europe Simferopol\"},{\"Code\":\"RU\",\"Name\":\"Europe Kirov\"},{\"Code\":\"RU\",\"Name\":\"Europe Astrakhan\"},{\"Code\":\"RU\",\"Name\":\"Europe Volgograd\"},{\"Code\":\"RU\",\"Name\":\"Europe Saratov\"},{\"Code\":\"RU\",\"Name\":\"Europe Ulyanovsk\"},{\"Code\":\"RU\",\"Name\":\"Europe Samara\"},{\"Code\":\"RU\",\"Name\":\"Asia Yekaterinburg\"},{\"Code\":\"RU\",\"Name\":\"Asia Omsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Novosibirsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Barnaul\"},{\"Code\":\"RU\",\"Name\":\"Asia Tomsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Novokuznetsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Krasnoyarsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Irkutsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Chita\"},{\"Code\":\"RU\",\"Name\":\"Asia Yakutsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Khandyga\"},{\"Code\":\"RU\",\"Name\":\"Asia Vladivostok\"},{\"Code\":\"RU\",\"Name\":\"Asia Ust-Nera\"},{\"Code\":\"RU\",\"Name\":\"Asia Magadan\"},{\"Code\":\"RU\",\"Name\":\"Asia Sakhalin\"},{\"Code\":\"RU\",\"Name\":\"Asia Srednekolymsk\"},{\"Code\":\"RU\",\"Name\":\"Asia Kamchatka\"},{\"Code\":\"RU\",\"Name\":\"Asia Anadyr\"},{\"Code\":\"RW\",\"Name\":\"Africa Kigali\"},{\"Code\":\"SA\",\"Name\":\"Asia Riyadh\"},{\"Code\":\"SB\",\"Name\":\"Pacific Guadalcanal\"},{\"Code\":\"SC\",\"Name\":\"Indian Mahe\"},{\"Code\":\"SD\",\"Name\":\"Africa Khartoum\"},{\"Code\":\"SE\",\"Name\":\"Europe Stockholm\"},{\"Code\":\"SG\",\"Name\":\"Asia Singapore\"},{\"Code\":\"SH\",\"Name\":\"Atlantic St_Helena\"},{\"Code\":\"SI\",\"Name\":\"Europe Ljubljana\"},{\"Code\":\"SJ\",\"Name\":\"Arctic Longyearbyen\"},{\"Code\":\"SK\",\"Name\":\"Europe Bratislava\"},{\"Code\":\"SL\",\"Name\":\"Africa Freetown\"},{\"Code\":\"SM\",\"Name\":\"Europe San_Marino\"},{\"Code\":\"SN\",\"Name\":\"Africa Dakar\"},{\"Code\":\"SO\",\"Name\":\"Africa Mogadishu\"},{\"Code\":\"SR\",\"Name\":\"America Paramaribo\"},{\"Code\":\"SS\",\"Name\":\"Africa Juba\"},{\"Code\":\"ST\",\"Name\":\"Africa Sao_Tome\"},{\"Code\":\"SV\",\"Name\":\"America El_Salvador\"},{\"Code\":\"SX\",\"Name\":\"America Lower_Princes\"},{\"Code\":\"SY\",\"Name\":\"Asia Damascus\"},{\"Code\":\"SZ\",\"Name\":\"Africa Mbabane\"},{\"Code\":\"TC\",\"Name\":\"America Grand_Turk\"},{\"Code\":\"TD\",\"Name\":\"Africa Ndjamena\"},{\"Code\":\"TF\",\"Name\":\"Indian Kerguelen\"},{\"Code\":\"TG\",\"Name\":\"Africa Lome\"},{\"Code\":\"TH\",\"Name\":\"Asia Bangkok\"},{\"Code\":\"TJ\",\"Name\":\"Asia Dushanbe\"},{\"Code\":\"TK\",\"Name\":\"Pacific Fakaofo\"},{\"Code\":\"TL\",\"Name\":\"Asia Dili\"},{\"Code\":\"TM\",\"Name\":\"Asia Ashgabat\"},{\"Code\":\"TN\",\"Name\":\"Africa Tunis\"},{\"Code\":\"TO\",\"Name\":\"Pacific Tongatapu\"},{\"Code\":\"TR\",\"Name\":\"Europe Istanbul\"},{\"Code\":\"TT\",\"Name\":\"America Port_of_Spain\"},{\"Code\":\"TV\",\"Name\":\"Pacific Funafuti\"},{\"Code\":\"TW\",\"Name\":\"Asia Taipei\"},{\"Code\":\"TZ\",\"Name\":\"Africa Dar_es_Salaam\"},{\"Code\":\"UA\",\"Name\":\"Europe Kiev\"},{\"Code\":\"UA\",\"Name\":\"Europe Uzhgorod\"},{\"Code\":\"UA\",\"Name\":\"Europe Zaporozhye\"},{\"Code\":\"UG\",\"Name\":\"Africa Kampala\"},{\"Code\":\"UM\",\"Name\":\"Pacific Midway\"},{\"Code\":\"UM\",\"Name\":\"Pacific Wake\"},{\"Code\":\"US\",\"Name\":\"America New_York\"},{\"Code\":\"US\",\"Name\":\"America Detroit\"},{\"Code\":\"US\",\"Name\":\"America Kentucky Louisville\"},{\"Code\":\"US\",\"Name\":\"America Kentucky Monticello\"},{\"Code\":\"US\",\"Name\":\"America Indiana Indianapolis\"},{\"Code\":\"US\",\"Name\":\"America Indiana Vincennes\"},{\"Code\":\"US\",\"Name\":\"America Indiana Winamac\"},{\"Code\":\"US\",\"Name\":\"America Indiana Marengo\"},{\"Code\":\"US\",\"Name\":\"America Indiana Petersburg\"},{\"Code\":\"US\",\"Name\":\"America Indiana Vevay\"},{\"Code\":\"US\",\"Name\":\"America Chicago\"},{\"Code\":\"US\",\"Name\":\"America Indiana Tell_City\"},{\"Code\":\"US\",\"Name\":\"America Indiana Knox\"},{\"Code\":\"US\",\"Name\":\"America Menominee\"},{\"Code\":\"US\",\"Name\":\"America North_Dakota Center\"},{\"Code\":\"US\",\"Name\":\"America North_Dakota New_Salem\"},{\"Code\":\"US\",\"Name\":\"America North_Dakota Beulah\"},{\"Code\":\"US\",\"Name\":\"America Denver\"},{\"Code\":\"US\",\"Name\":\"America Boise\"},{\"Code\":\"US\",\"Name\":\"America Phoenix\"},{\"Code\":\"US\",\"Name\":\"America Los_Angeles\"},{\"Code\":\"US\",\"Name\":\"America Anchorage\"},{\"Code\":\"US\",\"Name\":\"America Juneau\"},{\"Code\":\"US\",\"Name\":\"America Sitka\"},{\"Code\":\"US\",\"Name\":\"America Metlakatla\"},{\"Code\":\"US\",\"Name\":\"America Yakutat\"},{\"Code\":\"US\",\"Name\":\"America Nome\"},{\"Code\":\"US\",\"Name\":\"America Adak\"},{\"Code\":\"US\",\"Name\":\"Pacific Honolulu\"},{\"Code\":\"UY\",\"Name\":\"America Montevideo\"},{\"Code\":\"UZ\",\"Name\":\"Asia Samarkand\"},{\"Code\":\"UZ\",\"Name\":\"Asia Tashkent\"},{\"Code\":\"VA\",\"Name\":\"Europe Vatican\"},{\"Code\":\"VC\",\"Name\":\"America St_Vincent\"},{\"Code\":\"VE\",\"Name\":\"America Caracas\"},{\"Code\":\"VG\",\"Name\":\"America Tortola\"},{\"Code\":\"VI\",\"Name\":\"America St_Thomas\"},{\"Code\":\"VN\",\"Name\":\"Asia Ho_Chi_Minh\"},{\"Code\":\"VU\",\"Name\":\"Pacific Efate\"},{\"Code\":\"WF\",\"Name\":\"Pacific Wallis\"},{\"Code\":\"WS\",\"Name\":\"Pacific Apia\"},{\"Code\":\"YE\",\"Name\":\"Asia Aden\"},{\"Code\":\"YT\",\"Name\":\"Indian Mayotte\"},{\"Code\":\"ZA\",\"Name\":\"Africa Johannesburg\"},{\"Code\":\"ZM\",\"Name\":\"Africa Lusaka\"},{\"Code\":\"ZW\",\"Name\":\"Africa Harare\"}]";
        #endregion
    }
}