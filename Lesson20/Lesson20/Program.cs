using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20
{
    class Program
    {
        static void Main(string[] args)
        {
            //using interface
            Button btnLogin = new Button();
            btnLogin.text = "Login";
            MyClass myClass = new MyClass();
            btnLogin.clickable = myClass;
            btnLogin.detectClick();

            //using delegates
            Button2 btnLogin2 = new Button2();
            btnLogin2.text = "Login2";
            MyClass2 myClass2 = new MyClass2();
            btnLogin2.clickable = myClass2.Clicked;
            btnLogin2.detectClick();

            //anonymous function in delegate
            btnLogin2.clickable = delegate () { Console.WriteLine("loggin in..."); };
            //lambda expression
            btnLogin2.clickable = () => Console.WriteLine("loggin in....");

            //using abstracts
            Button3 btnLogin3 = new Button_Abstract();
            btnLogin3.detectClick();

            //using events
            Button4 button4 = new Button4();
            button4.clicked += button4_clicked;
            button4.detectClick();

            BackAccount myAccount = new BackAccount();
            myAccount.overdrawn += myAccount_overdrawn;
            myAccount.balance = 0;
            myAccount.withdraw(100);
        }

        private static void myAccount_overdrawn()
        {
            Console.WriteLine("Overdrawned!!!");
        }

        private static void button4_clicked()
        {
            Console.WriteLine("loggin in......");
        }
    }

    // Listener using an interface:
    class MyClass : OnClickListener
    {

        public void Clicked()
        {
            Console.WriteLine("loggin in...");
        }

        public void DoubleClicked()
        {
            Console.WriteLine("thanks");
        }
    }

    class Button
    {
        private OnClickListener _clickable;
        public OnClickListener clickable
        {
            set
            {
                _clickable = value;
            }
        }

        public string text { get; set; }
        public int color { get; set; }
        public int poition { get; set; } //for simplicity sake the position is just an int

        public void detectClick()
        {
            // Here goes the logic of detecting a click

            // Once a click detected the method runs the following:
            if (_clickable != null)
            {
                _clickable.Clicked();
            }
        }
    }

    interface OnClickListener
    {
        void Clicked();
        void DoubleClicked();
    }

    /* class Button_MultipleListeners // Same as class Button but can serve many listeneres
    {
        private List<OnClickListener> _clickables;        

        public Button_MultipleListeners()
        {
            _clickables = new List<OnClickListener>;
        }

        public OnClickListener clickable
        {
            set
            {
                _clickables.Add(value);
            }
        }

        public string text { get; set; }
        public int color { get; set; }
        public int poition { get; set; } //for simplicity sake the position is just an int

        public void detectClick()
        {
            // here goes the logic of detecting a click
            // once a click detected the method runs the following:

            foreach(OnClickListener c in _clickables)
            {
                c.Clicked();
            }
        }
    }
    */

    // Listener using a delegate:
    class MyClass2
    {
        public void Clicked()
        {
            Console.WriteLine("loggin in...");
        }

        public void DoubleClicked()
        {
            Console.WriteLine("thanks");
        }
    }

    class Button2
    {
        public Clicked clickable;

        public string text { get; set; }
        public int color { get; set; }
        public int poition { get; set; } //for simplicity sake the position is just an int

        public void detectClick()
        {
            clickable();
        }
    }

    delegate void Clicked();

    // Listener using abstract class:
    abstract class Button3
    {
        public abstract void clicked();

        public string text { get; set; }
        public int color { get; set; }
        public int poition { get; set; } //for simplicity sake the position is just an int

        public void detectClick()
        {
            clicked();
        }
    }

    class Button_Abstract : Button3
    {
        public override void clicked()
        {
            Console.WriteLine("Logging in....");
        }
    }
}