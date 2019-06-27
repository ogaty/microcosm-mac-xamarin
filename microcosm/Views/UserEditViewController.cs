using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Common;
using System.IO;
using microcosm.User;

namespace microcosm.Views
{
    public partial class UserEditViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public UserEditViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public UserEditViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public UserEditViewController() : base("UserEditView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new UserEditView View
        {
            get
            {
                return (UserEditView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UserData userData = CommonInstance.getInstance().SelectedUserData;
            fileName.StringValue = Path.GetFileNameWithoutExtension(CommonInstance.getInstance().SelectedFileName);
            userName.StringValue = userData.name;
            furigana.StringValue = userData.furigana;
            DateTime d = new DateTime(userData.birth_year, userData.birth_month, userData.birth_day,
                                     userData.birth_hour, userData.birth_minute, userData.birth_second);
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            birthDay.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((d - reference).TotalSeconds);
            userLat.StringValue = userData.lat.ToString();
            userLng.StringValue = userData.lng.ToString();
            userPlace.StringValue = userData.birth_place;
            memo.StringValue = userData.memo;

        }

        partial void SubmitClicked(NSObject sender)
        {
            DateTime date;
            if (birthDay.DateValue == null)
            {
                return;
            }
            try
            {
                NSDate nsd = birthDay.DateValue;
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
            /*
            double lat = 35.685175, lng = 139.7528;
            try
            {
                lat = double.Parse(UserLat.StringValue);
                lng = double.Parse(UserLng.StringValue);
            }
            catch (InvalidCastException)
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "正しい緯度経度を入力してください";
                alert.RunModal();
                return;
            }
            */

            if (fileName.StringValue == "")
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "ファイル名を入れてください";
                alert.RunModal();
                return;
            }

            if (userName.StringValue == "")
            {
                var alert = new NSAlert();
                alert.MessageText = "エラー";
                alert.InformativeText = "名前を入れてください";
                alert.RunModal();
                return;
            }

            // ファイル名が変わっていたら移動
            // 元のファイル名を保持が必要
            if (fileName.StringValue + ".csm" != CommonInstance.getInstance().SelectedFileName)
            {
                string fName = fileName.StringValue;
                string fullPath = CommonInstance.getInstance().SelectedDirectoryFullPath;
                string FilePath = CommonInstance.getInstance().SelectedDirectoryFullPath + "/" + fName + ".csm";
                UserXml.SaveUserData(FilePath, new UserData(
                    userName.StringValue,
                    furigana.StringValue,
                    date,
                    double.Parse(userLat.StringValue),
                    double.Parse(userLng.StringValue),
                    userPlace.StringValue,
                    memo.StringValue,
                    "JST"
                ));

            } else {
                string fName = fileName.StringValue;
                string selectedPath = CommonInstance.getInstance().SelectedDirectoryFullPath;
                if (File.Exists(selectedPath)) 
                {
                    selectedPath = Path.GetDirectoryName(selectedPath);
                }
                string FilePath = selectedPath + "/" + fName + ".csm";
                UserXml.SaveUserData(FilePath, new UserData(
                    userName.StringValue,
                    furigana.StringValue,
                    date,
                    double.Parse(userLat.StringValue),
                    double.Parse(userLng.StringValue),
                    userPlace.StringValue,
                    memo.StringValue,
                    "JST"
                ));
            }

            UserDbViewController dbvc = this.PresentingViewController as UserDbViewController;
            dbvc.ReSetDbTree();

            DismissViewController(this);
        }
    }
}
