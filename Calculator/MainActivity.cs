using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var list = FindViewById<ListView>(Resource.Id.listView1);
            list.Adapter = new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1, new List<string>() { "+", "-", "*", "/" });


            var firstValueText = FindViewById<TextInputEditText>(Resource.Id.textInputEditText1);
            var secondValueText = FindViewById<TextInputEditText>(Resource.Id.textInputEditText2);


            list.ItemClick += (sender, args) =>
            {
                try
                {
                    double val1 = ParseNumber(firstValueText.Text);
                    double val2 = ParseNumber(secondValueText.Text);

                    if (args.View is TextView textView)
                    {
                        var textViewText = textView.Text;


                        if (textViewText == "+")
                        {
                            SumItems();
                        }
                        else if (textViewText == "-")
                        {
                            SubstractItems();
                        }
                        else if (textViewText == "/")
                        {
                            DivideItems();
                        }
                        else if (textViewText == "*")
                        {
                            SumItems();
                        }
                    }


                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "Error wrong number", ToastLength.Long);
                }
            };


            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }


        public double ParseNumber(string number)
        {
            if(double.TryParse(number, out double value))
            {
                return value;
            }
            else
            {
                throw new ArgumentException("Is not a number");
            }
        }

        private void DivideItems()
        {
            throw new NotImplementedException();
        }

        private void SubstractItems()
        {
            throw new NotImplementedException();
        }

        private void SumItems()
        {
            throw new NotImplementedException();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

