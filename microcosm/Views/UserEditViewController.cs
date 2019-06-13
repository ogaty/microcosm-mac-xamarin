using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

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
            UserDbViewController dbvc = this.PresentingViewController as UserDbViewController;
            dbvc.ReSetDbTree();

            // ファイル名が変わっていたら移動
            // 元のファイル名を保持が必要

            DismissViewController(this);
        }
    }
}
