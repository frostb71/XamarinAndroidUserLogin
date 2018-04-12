using Android.App;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using System;

namespace MyAppTest
{
    [Activity(Label = "LOGIN", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText txtEmail;
        EditText txtPassword;
        Button btnRegister;
        Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;

            // create the database if it doesn't exist
            CreateDB();
        }

        void BtnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<User>(); //Call Table  
                var data1 = data.Where(x => x.EmailAddress == txtEmail.Text && x.Password == txtPassword.Text).FirstOrDefault(); //Linq Query  
                if (data1 != null)
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                    // TODO: redirect to the success page
                }
                else
                {
                    Toast.MakeText(this, "Enter a valid Email Address or Password invalid", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }

        void BtnRegister_Click(object sender, System.EventArgs e)
        {
            // redirect to the registration page
            StartActivity(typeof(RegisterActivity)); 
        }

        public string CreateDB()  
        {  
            var output = "Creating Database if it doesn't exists";  
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Create New Database  
            var db = new SQLiteConnection(dbPath);  
            output += "\n Database Created....";  
            return output;  
        } 
    }
}

