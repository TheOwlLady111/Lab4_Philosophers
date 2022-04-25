using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Philosophers
{
    public class Philosopher
    {
        private Fork _rightFork;
        private Fork _leftFork;
        private int count = 0;
        public TextBox box;

        public Philosopher(Fork left, Fork right, TextBox textBox)
        {
            _leftFork = left;
            _rightFork = right;
            box = textBox;
        }

        private bool TryTake()
        {
            Action action = () => box.BackColor = Color.Yellow;
                    box.Invoke(action);
            if (_leftFork.TakeFork())
            {
                if (_rightFork.TakeFork())
                {
                    return true;
                }
                else
                {
                    Random random = new Random();
                    
                    Thread.Sleep(random.Next(500, 1000));
                    if (_rightFork.TakeFork())
                    {
                        return true;
                    }
                    else
                    {
                        _leftFork.PutFork();
                        Think();
                    }
                }
            }
            return false;
        }

        private void Think()
        {
            Random random = new Random();
            Action action = () => box.BackColor = Color.PowderBlue;
            box.Invoke(action);
            Thread.Sleep(random.Next(1000, 4000));
        }

        private void Eat()
        {
            Random random = new Random();
            count++;
            Action action = () => { box.BackColor = Color.PaleGreen;box.Text = count.ToString();  };
            box.Invoke(action);
            
            Thread.Sleep(random.Next(1000, 4000));
        }

        public void Run()
        {
            while (true)
            {
                Think();

                if (TryTake())
                {
                    Eat();
                    _leftFork.PutFork();
                    _rightFork.PutFork();
                }
            }
        }
    }
}
