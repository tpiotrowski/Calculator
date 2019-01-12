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

            double val1 = 0;
            double val2 = 0;

            list.ItemClick += (sender, args) =>
            {
                try
                {
                     val1 = ParseNumber(firstValueText.Text);
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "Error Val1 wrong number", ToastLength.Long).Show();
                    return;
                }

                try
                {
                    val2 = ParseNumber(secondValueText.Text);
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "Error Val2 wrong number", ToastLength.Long).Show();
                    return;
                }

                double result = 0;

                    if (args.View is TextView textView)
                    {
                        var textViewText = textView.Text;


                        if (textViewText == "+")
                        {
                            result = SumItems(val1,val2);
                        }
                        else if (textViewText == "-")
                        {
                            result = SubstractItems(val1, val2);
                        }
                        else if (textViewText == "/")
                        {
                            if (val2 == 0)
                            {
                                Toast.MakeText(this, "Can not divide by 0", ToastLength.Long).Show();
                                return;
                        }

                            result = DivideItems(val1, val2);
                        }
                        else if (textViewText == "*")
                        {
                            result = MnozItems(val1,val2);
                        }
                    }

                    var resulTextView = FindViewById<TextView>(Resource.Id.textView1);

                    resulTextView.Text = result.ToString();

            };


            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        private double MnozItems(double val1, double val2)
        {
            return val1 * val2;
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

        private double DivideItems(double val1, double val2)
        {
            return val1 / val2;
        }

        private double SubstractItems(double val1, double val2)
        {
            return val1 - val2;
        }

        private double SumItems(double val1, double val2)
        {
            return val1 + val2;
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

