using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Common;
using microcosm.Models;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text.RegularExpressions;

namespace microcosm.Views
{
    internal class LatLng
    {
        public string place { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    internal class LatLngTable : ClassMap<LatLng>
    {
        private LatLngTable()
        {
            Map(c => c.place).Index(0);
            Map(c => c.lat).Index(1);
            Map(c => c.lng).Index(2);
        }
    }

    public partial class OfflineSearchLatLngViewController : AppKit.NSViewController
    {
        private string selectedPlace;
        private double selectedLat;
        private double selectedLng;
        #region Constructors

        // Called when created from unmanaged code
        public OfflineSearchLatLngViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public OfflineSearchLatLngViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public OfflineSearchLatLngViewController() : base("OfflineSearchLatLngView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Place.StringValue = CommonInstance.getInstance().userAdd.GetUserPlace();
        }

        partial void SearchButtonClicked(NSObject sender)
        {
            Search();
        }

        public void Search()
        {
            SearchLatLngDataSource DataSource = new SearchLatLngDataSource();
            using (var csv = new CsvReader(new StreamReader(Util.root + "/system/addr.csv")))
            {
                var config = csv.Configuration;
                config.HasHeaderRecord = true; // ヘッダーが存在する場合 true
                config.RegisterClassMap<LatLngTable>();
                var list = csv.GetRecords<LatLng>();

                Result.AllowsColumnSelection = true;

                foreach (var n in list)
                {
                    if (Regex.IsMatch(n.place, Place.StringValue)) 
                    {
                        DataSource.dataList.Add(new SearchLatLngData()
                        {
                            place = n.place,
                            lat = n.lat,
                            lng = n.lng
                        });
                    }

//                    Console.WriteLine($"{n.place}, {n.lat}, {n.lng}");
                }
            }
            Result.DataSource = DataSource;
            Result.Delegate = new SearchLatLngDelegate(DataSource);
            Result.ReloadData();
        }

        partial void SubmitClicked(NSObject sender)
        {
            CommonInstance.getInstance().userAdd.SetUserPlace(selectedPlace, selectedLat, selectedLng);
            DismissViewController(this);
        }

        //strongly typed view accessor
        public new OfflineSearchLatLngView View
        {
            get
            {
                return (OfflineSearchLatLngView)base.View;
            }
        }

        partial void LatLngTableClicked(NSObject sender)
        {
            int row = (int)Result.SelectedRow;
            if (row >= 0)
            {
                SearchLatLngDataSource data = (SearchLatLngDataSource)Result.DataSource;
                selectedPlace = data.dataList[row].place;
                selectedLat = data.dataList[row].lat;
                selectedLng = data.dataList[row].lng;
            }
        }

    }
}
