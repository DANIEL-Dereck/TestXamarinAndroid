using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Widget;
using ZXing.Mobile;

namespace App3
{
    [Activity(Label = "ZxingActivity")]
    public class ZxingActivity : BaseActivity
    {
        private TextView tvScanResult;
        private ImageButton btnScan;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            btnScan.Click += async (sender, e) => {
                MobileBarcodeScanner.Initialize(Application);
                var scanner = new MobileBarcodeScanner();
                var options = new MobileBarcodeScanningOptions();

                options.PossibleFormats = new List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.EAN_13, ZXing.BarcodeFormat.QR_CODE };

                var result = await scanner.Scan(options);

                if (result != null)
                {
                    int ean = 0;

                    if (int.TryParse(result.ToString(), out ean))
                    {
                        this.tvScanResult.Text = $"Scanned Barcode:\n {ean}";
                    }
                    else
                    {
                        this.tvScanResult.Text = $"Scanned Barcode:\n {Html.FromHtml(result.ToString())}";
                    }
                } else
                {
                    Toast.MakeText(this, "Error", ToastLength.Short);
                }
            };
        }

        public override int GetContentView()
        {
            return Resource.Layout.activity_zxing;
        }

        protected override void InitComponents()
        {
            this.tvScanResult = this.FindViewById<TextView>(Resource.Id.tv_zxing_scan);
            this.btnScan = this.FindViewById<ImageButton>(Resource.Id.btn_zxing_scan);
        }

        protected override void InitEvents()
        {

        }
    }
}