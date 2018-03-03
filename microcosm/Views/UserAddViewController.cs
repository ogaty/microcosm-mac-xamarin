﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.User;
using System.IO;
using microcosm.Common;

namespace microcosm.Views
{
    public partial class UserAddViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public UserAddViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public UserAddViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public UserAddViewController() : base("UserAddView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new UserAddView View
        {
            get
            {
                return (UserAddView)base.View;
            }
        }

        /// <summary>
        /// ユーザー追加
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void SubmitClick(NSObject sender)
        {
            DateTime date;
            if (UserBirth.DateValue == null)
            {
                return;
            }
            try
            {
                NSDate nsd = UserBirth.DateValue;
                date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);
            }
            catch (FormatException)
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "正しい日付を入れてください";
                alert.RunModal();
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }

            double lat = 35.685175, lng = 139.7528;
            try {
                lat = double.Parse(UserLat.StringValue);
                lng = double.Parse(UserLng.StringValue);
            } catch (InvalidCastException)
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "正しい緯度経度を入力してください";
                alert.RunModal();
                return;
            }

            if (FileName.StringValue == "")
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "ファイル名を入れてください";
                alert.RunModal();
                return;
            }

            if (UserName.StringValue == "") 
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "名前を入れてください";
                alert.RunModal();
                return;
            }

            string selectedPath = CommonInstance.getInstance().SelectedDirectoryFullPath;
            if (File.Exists(selectedPath)) 
            {
                selectedPath = Path.GetDirectoryName(selectedPath);
            }
            string FilePath = CommonInstance.getInstance().SelectedDirectoryFullPath + "/" + FileName.StringValue + ".csm";
            UserXml.SaveUserData(FilePath, new UserData(
                UserName.StringValue,
                UserFurigana.StringValue,
                date,
                lat,
                lng,
                UserPlace.StringValue,
                UserMemo.ToString(),
                "JST"
            ));
            UserDbViewController dbvc = this.PresentingViewController as UserDbViewController;
            dbvc.ReSetDbTree();


            DismissViewController(this);
        }
    }
}
