using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19
{
    //Delegates Lesson
    delegate void MyDelegate();
    delegate void MyAction<in T>(T arg1, T arg2);

    class Program
    {
        static void foo()
        {Console.WriteLine("foo");}

        static void too()
        {Console.WriteLine("too");}

        static void Main(string[] args)
        {
            //MotionSensor sensor = new MotionSensor();
            //TextMessageSender textMessageSender = new TextMessageSender();
            ////sensor.listener = textMessageSender;
            //sensor.sensorDelegate = textMessageSender.motionDetected;
            //sensor.sensorDelegate = stam;
            //sensor.detectMotion();

            //  You can add multiple methods to a single delegate
            //as long as they all are of the same type and take the same input.
            //  In a similiar fashion you can remove methods from a delegate.
            //  Delegates with multiple methods start instantiating 
            //them from the first in line.
            MyDelegate del1 = foo;
            MyDelegate del2 = too;           
            MyDelegate del3 = del2 + foo;
            del3 += too;
            del3 += del2;
            del3 -= del2;
            del3();

            //  "Action" is a build in delegate and does
            //an action with the input types.
            Action<int, int, string> action;
            action = stam2;
            MyAction<int> myAction = stam3;

            //  "Func" is similiar to Action but the last
            //input in the input types has to be returned.
            Func<string> myFunc = stam4;

            //  "delegate () {};" is an anonymous delegate
            Func<string> myOtherFunc = delegate () { return "hello"; };

            //  "() => " is a lambda expression.
            //  "() => {}" is a lambda statement. The only difference
            //is that you can put multiple lines of code in the statement.
            //  Practically it's no more than 2 or 3 lines of code.
            myOtherFunc = () => { return "hello"; };
            Console.WriteLine(myOtherFunc());

            // You can use variables outside the lambda expression
            //but only in the same scope that defined the expression.
            int x = 0;
            Action action5 = null;
            action5 = () => { Console.WriteLine("hi"); if (x++ < 5) action5(); };
            action5();

            Action<string> action6 = (s) => Console.WriteLine(s);
            action6("test");

            Func<float, float> square = (a) => a * a;
            float result = square(10.5f);
            Console.WriteLine(result);
        }

        static string stam4()
        { return "hello"; }

        static void stam3(int x, int y)
        { }

        static void stam2(int x, int y, string s)
        {  }

        static void stam()
        {Console.WriteLine("stam..");}
    }

    //interface MotionSensorListener
    //{
    //    void motionDetected();
    //}

    public delegate void MotionSensorDelegate();

    class MotionSensor
    {
        //private MotionSensorListener _listener;
        //public MotionSensorListener listener
        //{
        //    set
        //    {
        //        _listener = value;
        //    }
        //}

        public MotionSensorDelegate sensorDelegate;

        public void detectMotion()
        {
            //if (_listener != null)
            //    _listener.motionDetected();
            sensorDelegate();
        }
    }

    class TextMessageSender //: MotionSensorListener
    {
        public void motionDetected()
        {Console.WriteLine("sending text message about motion detected");}
    }    
}