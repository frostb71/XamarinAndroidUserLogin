
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace MyAppTest
{
    [Activity(Label = "REGISTER")]
    public class RegisterActivity : Activity
    {
        // STEP 0: Declare the UI controls/views at the class-level
        EditText txtEmail;
        EditText txtPassword;
        EditText txtConfirmPassword;
        Button btnRegister;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // STEP 2: Link the activity to its associated Layout File
            // Create your application here
            SetContentView(Resource.Layout.Register);

            // STEP 3: Register the UI controls
            btnRegister = FindViewById<Button>(Resource.Id.btnSignUp);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);

            // STEP 4: Subscribe to the click event for the button controls
            btnRegister.Click += BtnRegister_Click;
        }

        void BtnRegister_Click(object sender, EventArgs e)
        {
            // TODO: Implement input validation code here

            try   
            {  
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");  
                var db = new SQLiteConnection(dbPath);  

                db.CreateTable<User> ();  

                User tbl = new User();  
                tbl.EmailAddress = txtEmail.Text;  
                tbl.Password = txtPassword.Text;  
                db.Insert(tbl);  
                Toast.MakeText(this, "You have registered successfully...,", ToastLength.Short).Show();

                // TODO: Navigate to landing page or StartActivity

            } catch (Exception ex) {  
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();  
            }  
        }
    }
}
