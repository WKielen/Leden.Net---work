using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    class DateRoutines
    {
        public static int AantalWeken(int eenJanuari, int jaar)
        {
            //als 1 januari van het jaar op donderdag valt of op woensdag tijdens een schrikkeljaar
            if ((eenJanuari == 4) || (eenJanuari == 3) && (IsSchrikkeljaar(jaar)))
                return 53; //jaar heeft 53 weken
            else
                return 52; //jaar heeft 52 weken
        }

        public static int DagInJaar(int dag, int maand, int jaar, bool inclWeek1)
        //inclWeek1 bepaald:
        //   of de echte dag in het jaar moet worden berekend (True)
        //   of incl. de dagen van het vorige jaar in de 1e week (False)
        //   of excl. de dagen van het huidige jaar in de laatste van het vorige jaar (False)
        {
            int dagen;
            int eenJanuari;
            bool inWeek1;

            eenJanuari = KrijgEenJanuari(jaar);
            inWeek1 = IsInWeek1(eenJanuari);
            dagen = dag;

            //herhaal TOT de opgegeven maand
            for (int i = 1; i < maand; i++)
            {
                //tel het aantal dagen van maand i bij dagen op
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: dagen = dagen + 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: dagen = dagen + 30;
                        break;
                    case 2:
                        if (IsSchrikkeljaar(jaar))
                            dagen = dagen + 29;
                        else
                            dagen = dagen + 28;
                        break;
                }
            }
            if (inclWeek1)
                return dagen;
            else
                if (inWeek1) //als 1 januari van het opgegeven jaar in week 1 zit
                    //tel de overige dagen van het vorige jaar in week 1(opgegeven jaar) bij dagen op
                    return dagen + eenJanuari - 1;
                else
                    //trek de dagen van het opgegeven jaar in week 52/53(vorige jaar) van dagen af
                    return dagen - (7 - eenJanuari + 1);
        }



        public static string KrijgDag(int dagNr)
        {
            string result = string.Empty; ;
            switch (dagNr)
            {
                case 1:
                    result = "Maandag";
                    break;
                case 2:
                    result = "Dindsdag";
                    break;
                case 3:
                    result = "Woensdag";
                    break;
                case 4:
                    result = "Donderdag";
                    break;
                case 5:
                    result = "Vrijdag";
                    break;
                case 6:
                    result = "Zaterdag";
                    break;
                case 0:
                case 7:
                    result = "Zondag";
                    break;
            }
            return result;
        }

        public static int KrijgEenJanuari(int jaar)
        {
            int dagen = 0;

            //herhaal TOT het opgegeven jaar
            for (int i = 1900; i < jaar; i++)
            {
                //als jaar i een schrikkeljaar is
                if (IsSchrikkeljaar(i))
                    dagen = dagen + 366;
                else
                    dagen = dagen + 365;
            }

            dagen = dagen + 1; //tel 1 januari van het opgegeven jaar bij dagen op

            //als 1 januari op een zondag is
            if ((dagen % 7) == 0)
                return 7; //return "zondag"
            else
                return dagen % 7; //return het dagnr van 1 januari van het opgegeven jaar
        }


        public static bool IsInWeek1(int eenJanuari)
        //zit 1 januari wel of niet in week 1
        {
            if (eenJanuari > 0 && eenJanuari < 5)
                return true;
            else
                return false;
        }

        public static bool IsSchrikkeljaar(int jaar)
        //als het jaar deelbaar is door 400 of als het jaar door 4 maar niet door 100 deelbaar is
        {
            if ((jaar % 400 == 0) || (jaar % 4 == 0 && jaar % 100 != 0))
                return true;
            else
                return false;
        }

        public static int WeekNr(int dag, int maand, int jaar)
        {
            int dagNr;
            int eenJanuari;
            int wknr;
            bool inWeek1;

            eenJanuari = KrijgEenJanuari(jaar);
            inWeek1 = IsInWeek1(eenJanuari);

            //als 1 januari niet in week 1 valt en de opgegeven in dezelfde week valt als 1 januari
            if ((!inWeek1) && (dag <= 7 - eenJanuari + 1) && (maand == 1))
                return AantalWeken(KrijgEenJanuari(jaar - 1), jaar - 1);
            //als 1 januari van het volgende jaar in week 1 zit en de opgegeven datum zit ook in dezelfde week
            else
                if ((IsInWeek1(KrijgEenJanuari(jaar + 1))) && (dag > 32 - KrijgEenJanuari(jaar + 1)) && (maand == 12))
                    return 1;

            //het dagnummer van de opgegeven datum
            dagNr = DagInJaar(dag, maand, jaar, true);

            wknr = dagNr / 7; //bepaal het weeknummer
            //haal de decimalen weg als wknr een double is (niet met CInt, vanwege het afronden)
            //		if pos <> 0 Then wknr = Left(wknr, pos - 1)

            //als het zondag is (dan is het weeknr goed)
            if (dagNr % 7 == 0)
                return wknr;
            else
                return wknr + 1; //tel 1 week bij WeekNr op
        }

        public static DateTime EersteDagVanWeek(int Jaar, int WeekNummer)
        {
            DateTime start = new DateTime(Jaar, 1, 4, 0, 0, 0);
            DateTime weekDate = start.AddDays((WeekNummer - 1) * 7);
            DayOfWeek weekDayOfWeek = weekDate.DayOfWeek;
            int offset = (weekDayOfWeek == DayOfWeek.Sunday ? 7 : (int)weekDayOfWeek) - 1;
            weekDate = weekDate.AddDays(-1 * offset);
            return weekDate;
        }
    }

    public struct DateTimeSpan
    {
        private readonly int years;
        private readonly int months;
        private readonly int days;
        private readonly int hours;
        private readonly int minutes;
        private readonly int seconds;
        private readonly int milliseconds;

        public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
        {
            this.years = years;
            this.months = months;
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }

        public int Years { get { return years; } }
        public int Months { get { return months; } }
        public int Days { get { return days; } }
        public int Hours { get { return hours; } }
        public int Minutes { get { return minutes; } }
        public int Seconds { get { return seconds; } }
        public int Milliseconds { get { return milliseconds; } }

        enum Phase { Years, Months, Days, Done }

        public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                var sub = date1;
                date1 = date2;
                date2 = sub;
            }

            DateTime current = date1;
            int years = 0;
            int months = 0;
            int days = 0;

            Phase phase = Phase.Years;
            DateTimeSpan span = new DateTimeSpan();

            while (phase != Phase.Done)
            {
                switch (phase)
                {
                    case Phase.Years:
                        if (current.AddYears(years + 1) > date2)
                        {
                            phase = Phase.Months;
                            current = current.AddYears(years);
                        }
                        else
                        {
                            years++;
                        }
                        break;
                    case Phase.Months:
                        if (current.AddMonths(months + 1) > date2)
                        {
                            phase = Phase.Days;
                            current = current.AddMonths(months);
                        }
                        else
                        {
                            months++;
                        }
                        break;
                    case Phase.Days:
                        if (current.AddDays(days + 1) > date2)
                        {
                            current = current.AddDays(days);
                            var timespan = date2 - current;
                            span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                            phase = Phase.Done;
                        }
                        else
                        {
                            days++;
                        }
                        break;
                }
            }

            return span;
        }

    }


}
