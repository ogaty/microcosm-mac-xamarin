using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using AppKit;
using Foundation;
using microcosm.Calc;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;
using microcosm.Views;
using Newtonsoft.Json;
using SkiaSharp;
using SkiaSharp.Views.Mac;
using CoreGraphics;
using System.Linq;

namespace microcosm
{
    public partial class ViewController
    {

        /// <summary>
        /// 左ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = -1 * int.Parse(DateSetterDay.StringValue);
                int hour = -1 * int.Parse(DateSetterHour.StringValue);
                int minute = -1 * int.Parse(DateSetterMinute.StringValue);
                double second = -1 * double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);
                date = date.AddMinutes(minute);
                date = date.AddHours(hour);
                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }
        }

        /// <summary>
        /// 右ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = int.Parse(DateSetterDay.StringValue);
                int hour = int.Parse(DateSetterHour.StringValue);
                int minute = int.Parse(DateSetterMinute.StringValue);
                double second = double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);
                date = date.AddMinutes(minute);
                date = date.AddHours(hour);
                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        /// <summary>
        /// Day 左ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterDayLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = -1 * int.Parse(DateSetterDay.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        /// <summary>
        /// Day 右ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterDayRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = int.Parse(DateSetterDay.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        /// <summary>
        /// 時刻左ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterHourLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int hour = -1 * int.Parse(DateSetterHour.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddHours(hour);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        /// <summary>
        /// 時刻右ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterHourRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int hour = int.Parse(DateSetterHour.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddHours(hour);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        partial void DateSetterMinuteLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int minute = -1 * int.Parse(DateSetterMinute.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddMinutes(minute);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }
        }

        partial void DateSetterMinuteRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int minute = int.Parse(DateSetterMinute.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddMinutes(minute);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }
        }

        partial void DateSetterSecondLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                double second = -1 * double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }

        }

        partial void DateSetterSecondRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                double second = double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
                ReCalcAll();
                ReRender();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }

        }

        partial void DateSetterNow(NSObject sender)
        {
            DateTime date = DateTime.Now;
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
            ReSetUserBox();
        }

        /// <summary>
        /// SETボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterSet(NSObject sender)
        {
            NSDate nsd = DateSetterDatePicker.DateValue;
            DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

            DateSetterTime(date);

            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
            ReSetUserBox();
            ReCalcAll();
            ReRender();

        }


    }
}
