﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Controls;

namespace LessonSchedules
{
    class CreateScheduleClass
    {
        TimeSpan week = new TimeSpan(7, 0, 0, 0);

        const string AdobeJensonPath = "\\Fonts\\#Adobe Jenson Pro OldStyle";
        const int FontSizeHeader = 16;

        const string recitalDateFormat = "dddd, MMM d yyyy";
        const string lessonDateFormat = "MMM d";

        const string numberFormat = "N0";

        FontFamily fontFamily;
        const int fontSize = 16;
        const int topMargin = 72;
        const int padding = 32;
        const double contentWidth = 6.5 * 96;
        const int leftMargin = 96;

        const int columnWidth = 3 * 96;
        const int columnGutter = 48;
        const int tabSpacing = fontSize;

        readonly Brush normalBrush = Brushes.Black;
        readonly Brush recitalBrush = Brushes.Blue;

        enum DateType
        {
            normal, holiday, payment
        }

        private Brush BrushFromType(DateType type)
        {
            switch (type)
            {
                case DateType.holiday:
                    return Brushes.Red;
                case DateType.normal:
                    return Brushes.Black;
                case DateType.payment:
                    return Brushes.Black;
                default:
                    return Brushes.Black;
            }
        }

        Canvas currCanvas;
        IEnumerable<Holiday> Holidays;

        DateTime FirstLesson;

        public CreateScheduleClass(string AppDirectory)
        {
            //create the formatting items
            FontFamily AdobeJenson = new FontFamily(AppDirectory + AdobeJensonPath);
            FontFamily Georgia = new FontFamily("Georgia");
            fontFamily = Georgia;
        }

        private Decimal RoundUpToNearestMultiple(Decimal toRound, Decimal multipleOf)
        {
            //assume multipleOf is a nonnegative integer
            if (multipleOf == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round((toRound + multipleOf - 1) / multipleOf) * multipleOf;
            }
        }

        public FixedDocument CreateSchedule(
            string StudentName, string SchoolYear,
            DateTime pFirstLesson, DateTime LastLesson, int TotalWeeks,
            IEnumerable<Holiday> pHolidays,
            Decimal PaymentRate, Decimal RoundPayments,
            int UserPaymentCount, string FirstStudentName, Decimal FirstStudentRate,
            string SecondStudentName, Decimal SecondStudentRate, string LessonTime,
            Decimal UserMonthlyPayment,
            IList<DateTime> GroupLessonDates, Decimal GroupLessonRate, string GroupLessonNamePlural, string GroupLessonNameSingular,
            bool FirstStudentGLs, bool SecondStudentGLs,
            string ExtraText, Decimal ExtraFees, bool smallLastMonth)
        {
            Holidays = pHolidays;
            FirstLesson = pFirstLesson;

            //create the fixed document that contains the canvas, which is
            //where we do all of the drawing
            FixedDocument fd = new FixedDocument();
            PageContent pc = new PageContent();
            fd.Pages.Add(pc);
            FixedPage fp = new FixedPage();
            ((IAddChild)pc).AddChild(fp);
            Canvas canvas = new Canvas();
            fp.Children.Add(canvas);

            currCanvas = canvas;

            //create the text items
            //header
            string HeaderText = "Jaewon Lee Piano Studio\n" +
                                "Lesson Schedule\n" +
                                "Student: " + StudentName + "\n" +
                                "Year: " + SchoolYear + "\n" +
                                LessonTime + "\n";

            //columns of lesson dates
            DateTime currLesson = FirstLesson;
            int paymentCount = 0;
            int holidayCount = 0;

            int halfwayPoint = (TotalWeeks % 2 == 0) ? TotalWeeks / 2 : TotalWeeks / 2 + 1;

            //if the userpaymentcount was not specified, make it unlimited. There are only 12 months in the year
            UserPaymentCount = UserPaymentCount < 1 ? 13 : UserPaymentCount;

            Dictionary<string, DateType> LessonDatesColumn1
                = CreateLessonDatesColumn(ref currLesson, ref paymentCount, UserPaymentCount, ref holidayCount,
                                           1, halfwayPoint);
            Dictionary<string, DateType> LessonDatesColumn2
                = CreateLessonDatesColumn(ref currLesson, ref paymentCount, UserPaymentCount, ref holidayCount,
                                           halfwayPoint + 1, TotalWeeks);

            //group lessons
            int totalGLs = GroupLessonDates == null ? 0 : GroupLessonDates.Count;
            int numberOfStudentsDoingGL = !string.IsNullOrEmpty(FirstStudentName)
                ? ((FirstStudentGLs ? 1 : 0) + (SecondStudentGLs ? 1 : 0))
                : (totalGLs == 0 ? 0 : 1);
            int glHalfwayPoint = (totalGLs % 2 == 0) ? totalGLs / 2 : totalGLs / 2 + 1;

            Dictionary<string, DateType> GLDatesColumn1 = new Dictionary<string, DateType>();
            Dictionary<string, DateType> GLDatesColumn2 = new Dictionary<string, DateType>();
            for (int i = 0; i < glHalfwayPoint; i++)
                GLDatesColumn1.Add(/*GroupLessonNameSingular + ": " +*/ GroupLessonDates[i].ToString(lessonDateFormat), DateType.normal);
            for (int i = glHalfwayPoint; i < totalGLs; i++)
                GLDatesColumn2.Add(/*GroupLessonNameSingular + ": " +*/ GroupLessonDates[i].ToString(lessonDateFormat), DateType.normal);

            //payments
            int totalLessons = TotalWeeks - holidayCount;
            Decimal totalPayment =
                totalLessons * PaymentRate
                + totalGLs * GroupLessonRate * numberOfStudentsDoingGL
                + ExtraFees;
            Decimal paymentPerPeriod = totalPayment / paymentCount;
            Decimal finalPayment = CalculateFinalPayment(smallLastMonth, PaymentRate, LessonDatesColumn2, paymentCount, totalPayment,
                UserMonthlyPayment, RoundPayments, ref paymentPerPeriod);

            string PaymentExplanationText;
            if (FirstStudentName == string.Empty)
            {
                PaymentExplanationText = OneStudentPaymentExplanation(totalLessons, PaymentRate, totalGLs, GroupLessonRate);
            }
            else
            {
                PaymentExplanationText =
                    FirstStudentName + ":\n"
                        + OneStudentPaymentExplanation(totalLessons, FirstStudentRate,
                            FirstStudentGLs ? totalGLs : 0, GroupLessonRate) + "\n"
                    + SecondStudentName + ":\n"
                        + OneStudentPaymentExplanation(totalLessons, SecondStudentRate,
                            SecondStudentGLs ? totalGLs : 0, GroupLessonRate) + "\n";
            }

            Dictionary<string, DateType> LessonDatesColumn1Subbed = new Dictionary<string, DateType>();
            Dictionary<string, DateType> LessonDatesColumn2Subbed = new Dictionary<string, DateType>();
            foreach (KeyValuePair<string, DateType> line in LessonDatesColumn1)
                LessonDatesColumn1Subbed.Add(string.Format(line.Key, paymentPerPeriod.ToString(numberFormat)),
                    line.Value);

            int finalPaymentIndex = -1;
            for (int i = 0; i < LessonDatesColumn2.Count; i++)
            {
                if (LessonDatesColumn2.ElementAt(i).Value == DateType.payment)
                    finalPaymentIndex = i;
            }
            if (finalPaymentIndex == -1)
            {
                for (int i = 0; i < LessonDatesColumn1.Count; i++)
                    if (LessonDatesColumn1.ElementAt(i).Value == DateType.payment)
                        finalPaymentIndex = i;
            }
            if (finalPaymentIndex == -1) throw new ApplicationException("Unrecoverable error");

            for (int i = 0; i < LessonDatesColumn2.Count; i++)
            {
                KeyValuePair<string, DateType> line = LessonDatesColumn2.ElementAt(i);
                if (i == finalPaymentIndex)
                    LessonDatesColumn2Subbed.Add(string.Format(line.Key, finalPayment.ToString(numberFormat)),
                        line.Value);
                else
                    LessonDatesColumn2Subbed.Add(string.Format(line.Key, paymentPerPeriod.ToString(numberFormat)),
                        line.Value);
            }

            //create the items that will go on the page
            double yPos = 0;

            yPos += topMargin;
            yPos += AddTextBlock(HeaderText, yPos, contentWidth, leftMargin, normalBrush, true).Height;
            yPos += padding;

            double col1Height = AddDatesColumn(
                                    LessonDatesColumn1Subbed,
                                    yPos,
                                    leftMargin).Height;
            double col2Height = AddDatesColumn(
                                    LessonDatesColumn2Subbed,
                                    yPos,
                                    leftMargin + columnWidth + columnGutter).Height;
            yPos += col1Height > col2Height ? col1Height : col2Height;

            if (totalGLs > 0)
            {
                yPos += padding;
                yPos += AddTextBlock(GroupLessonNamePlural, yPos).Height;
                col1Height = AddDatesColumn(GLDatesColumn1, yPos, leftMargin).Height;
                col2Height = AddDatesColumn(GLDatesColumn2, yPos, leftMargin + columnWidth + columnGutter).Height;
                yPos += col1Height > col2Height ? col1Height : col2Height;
            }

            yPos += padding;
            yPos += AddTextBlock(PaymentExplanationText, yPos).Height;

            if (!string.IsNullOrEmpty(ExtraText))
            {
                yPos += padding;
                yPos += AddTextBlock(ExtraText, yPos).Height;
            }

            return fd;
        }

        private Decimal CalculateFinalPayment(bool smallLastMonth, Decimal PaymentRate, Dictionary<string, DateType> GLDatesColumn2, int paymentCount, Decimal totalPayment, Decimal UserMonthlyPayment, Decimal RoundPayments, ref Decimal paymentPerPeriod)
        {
            Decimal finalPayment;
            if (UserMonthlyPayment != 0)
            {
                paymentPerPeriod = UserMonthlyPayment;
                finalPayment = totalPayment - paymentPerPeriod * paymentCount + paymentPerPeriod;
            }
            else if (RoundPayments > 0)
            {
                paymentPerPeriod = RoundUpToNearestMultiple(paymentPerPeriod, RoundPayments);
                finalPayment = totalPayment - paymentPerPeriod * paymentCount + paymentPerPeriod;

                if (smallLastMonth)
                {
                    int lastMonthCount = 1;

                    foreach (KeyValuePair<string, DateType> date in GLDatesColumn2)
                    {
                        if (date.Value == DateType.normal)
                            lastMonthCount++;
                        else if (date.Value == DateType.payment)
                            lastMonthCount = 1;
                    }

                    while (finalPayment > PaymentRate * lastMonthCount)
                    {
                        paymentPerPeriod += RoundPayments;
                        finalPayment = totalPayment - paymentPerPeriod * paymentCount + paymentPerPeriod;
                    }
                }
            }
            else
            {
                finalPayment = paymentPerPeriod;
            }

            return finalPayment;
        }

        private string OneStudentPaymentExplanation(
            int privateLessons, Decimal privateLessonsRate,
            int groupLessons, Decimal groupLessonsRate)
        {
            return "Private Lessons: " + privateLessons.ToString() + "\n" +
                   "Private Lessons Rate: $" + privateLessonsRate.ToString(numberFormat) + "\n" +
                   (groupLessons > 0
                       ?
                       "Group Lessons: " + groupLessons.ToString() + "\n" +
                       "Group Lessons Rate: $" + groupLessonsRate.ToString(numberFormat) + "\n"
                       :
                       "")
                    /* + "Total: " + QbyR(privateLessons, privateLessonsRate)
                    + (groupLessons > 0
                          ? " + " + QbyR(groupLessons, groupLessonsRate)
                          : "")
                    + " = $" + (privateLessons * privateLessonsRate + groupLessons * groupLessonsRate).ToString(numberFormat) */
                        + "\n";
        }

        private string QbyR(int q, Decimal r)
        {
            return q.ToString() + " × $" + r.ToString(numberFormat);
        }

        private Dictionary<string, DateType> CreateLessonDatesColumn(ref DateTime currLesson, ref int payments, int UserPaymentCount, ref int holidayCount, int initial, int final)
        {
            Dictionary<string, DateType> column = new Dictionary<string, DateType>();
            for (int i = initial; i <= final; i++)
            {
                string initialString
                    = string.Format(
                        "Lesson {0:D}: {1:" + lessonDateFormat + "}",
                        i - holidayCount,
                        currLesson);

                Holiday holiday = IsHoliday(currLesson);

                if (holiday != null)
                {
                    column.Add(
                        string.Format(
                            "{0}: {1:" + lessonDateFormat + "}",
                            holiday.Name,
                            currLesson),
                        DateType.holiday);
                    holidayCount++;
                }
                else if (IsPayment(currLesson) && payments < UserPaymentCount)
                {
                    column.Add(initialString + " Payment: ${0}", DateType.payment);
                    payments++;
                }
                else
                {
                    column.Add(initialString, DateType.normal);
                }
                currLesson += week;
            }

            return column;
        }

        private Holiday IsHoliday(DateTime toCheck)
        {
            foreach (Holiday h in Holidays)
                if (h.Contains(toCheck))
                    return h;
            return null;
        }

        private bool IsPayment(DateTime toCheck)
        {
            if (IsHoliday(toCheck) != null)
                return false;
            if (toCheck == FirstLesson)
                return true;

            DateTime prevLesson = toCheck;
            //TimeSpan week = new TimeSpan( 7, 0, 0, 0 );
            do
            {
                prevLesson -= week;
            } while (IsHoliday(prevLesson) != null);

            if (toCheck.Month != prevLesson.Month &&
                !IsPayment(prevLesson))
                return true;
            else
                return false;
        }

        private Size AddDatesColumn(Dictionary<string, DateType> Column, double Top, double Left)
        {
            double yPos = Top;
            double width = 0;
            foreach (KeyValuePair<string, DateType> line in Column)
            {
                Size size = AddTextBlock(
                                line.Key,
                                yPos,
                                columnWidth,
                                Left,
                                BrushFromType(line.Value));
                yPos += size.Height;
                if (size.Width > width)
                    width = size.Width;
            }

            return new Size(width, yPos - Top);
        }

        private Size AddTextBlock(string Text, double Top)
        {
            return AddTextBlock(Text, Top, contentWidth);
        }
        private Size AddTextBlock(string Text, double Top, double Width)
        {
            return AddTextBlock(Text, Top, Width, leftMargin);
        }
        private Size AddTextBlock(string Text, double Top, double Width, double Left)
        {
            return AddTextBlock(Text, Top, Width, Left, Brushes.Black);
        }
        private Size AddTextBlock(string Text, double Top, double Width, double Left, Brush Color)
        {
            return AddTextBlock(Text, Top, Width, Left, Color, false);
        }
        private Size AddTextBlock(string Text, double Top, double Width, double Left, Brush Color, bool Centered)
        {
            //calculate the height of the added element
            FormattedText ft = new FormattedText(
                    Text,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(fontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                    fontSize,
                    Brushes.Black
                );

            ft.MaxTextWidth = Width;

            double height = ft.Height;

            if (Top + height > 11 * 96)
                return new Size(0, 0);

            //add the text to the page
            TextBlock tb = new TextBlock();
            currCanvas.Children.Add(tb);
            tb.Text = Text;
            tb.FontFamily = fontFamily;
            tb.FontSize = fontSize;
            tb.Width = Width;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = Color;
            if (Centered)
                tb.TextAlignment = TextAlignment.Center;
            Canvas.SetTop(tb, Top);
            Canvas.SetLeft(tb, Left);

            return new Size(ft.Width, ft.Height);
        }
    }
}
