using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18
{
    class Program
    {
        static void Main(string[] args)
        {
            //  The sensor class can get other objects
            //(such as 'police' and 'siren') that implement
            //the 'IMotionListener' interface. And the sensor
            //activates all these objects 'motionDetected'
            //method if it detected motion.
            AlarmSensor sensor = new AlarmSensor();
            Police police = new Police();
            Siren siren = new Siren();
            sensor.listener = police;
            sensor.listener = siren;
            sensor.detectMotion();
            
            //Example of shortened implentation of an object:    
            Car[] cars = {new Car() { model = "Toyota", year = 2013, color = 123456},
                new Car() {model = "Honda", year=2016, color=1023123} };
            //Every array has a build in sort as long the object given has an IComparable interface
            Array.Sort(cars);

            List<Person> persons = new List<Person>();
            Person p1 = new Person() { firstName = "Elad", lastName = "Lavi" };
            Person p2 = new Person() { firstName = "Elad", lastName = "Lavi" };
            persons.Add(p1);
            Console.WriteLine(persons.Contains(p2));

            MyList<int> nums = new MyList<int>();
            nums.add(10);
            nums.add(20);
            nums.add(30);
            foreach (int x in nums)
            {

            }
        }
    }

    // Example of an event listner, the class AlarmSensor just detects movement when the method is activated and has a property listener
    // Any outside object with the interface "IMotionListener" can use the event of the detected motion.
    class Police : IMotionListener
    {
        public void motionDetected()
        {
            Console.WriteLine("police! you under arrest!");
            //Console.Beep();
        }
    }

    class Siren : IMotionListener
    {

        public void motionDetected()
        {
            Console.WriteLine("Alarm! Alarm!");
        }
    }
    public class AlarmSensor
    {
        //  Since we don't wont to put a getter in the listener we use 
        //another public object of IMotionlistener to use listen
        private IMotionListener[] _listener;
        public AlarmSensor()
        {
            _listener = new IMotionListener[10];
        }
        public IMotionListener listener
        {
            set
            {
                for (int i = 0; i < _listener.Length; i++)
                {
                    if (_listener[i] == null)
                    {
                        _listener[i] = value;
                        break;
                    }
                }
            }
        }
        public void detectMotion()
        {
            //...
            //(code for detecting motion goes here)
            //...

            //  If the motion-check code detected motion and if there is a listener, 
            //notify them of the detected motion.
            for (int i = 0; i < _listener.Length; i++)
            {
                if (_listener != null)
                    _listener[i].motionDetected();
            }
        }
    }
    public interface IMotionListener
    {
        void motionDetected();
    }    

    class Car : IComparable
    {
        public int color { get; set; }
        public string model { get; set; }
        public int year { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException();
            if (obj is Car)
            {
                Car other = (Car)obj;
                if (this.year > other.year)
                    return 1;
                else if (this.year == other.year)
                    return 0;
                else
                    return -1;
            }
            else
                throw new InvalidCastException();
        }
    }

    class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public override bool Equals(object obj)
        {
            Console.WriteLine("in Equals");
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            if (obj is Person)
            {
                Person other = (Person)obj;
                return this.firstName.Equals(other.firstName) &&
                    this.lastName.Equals(other.lastName);
            }
            return false;
        }
    }

    class MyList<T> : IEnumerator<T>, IEnumerable<T>
    {
        T[] arr;
        int pos = 0;

        int currentPos = -1;
        public MyList()
        {
            arr = new T[10];
        }

        public void add(T item)
        {
            //make room if necessary
            arr[pos++] = item;
        }


        public T Current
        {
            get { return arr[currentPos]; }
        }

        public void Dispose()
        {
            Console.WriteLine("In Despose");
        }

        public bool MoveNext()
        {

            if (currentPos < pos)
            {
                currentPos++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            currentPos = 0;
        }

        object IEnumerator.Current
        {
            get
            {
                return arr[currentPos];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public int Size()
        {
            return pos;
        }
        public T Get(int index)
        {
            if (index < 0 || index >= pos)
                throw new IndexOutOfRangeException();
            return arr[index];
        }
    }
}