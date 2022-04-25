namespace Lab4_Philosophers
{
    public partial class Form1 : Form
    {
        public static int N = 5;
        public Form1()
        {
            InitializeComponent();
            StartDinner();
        }

        List<Fork> forks;
        List<Philosopher> philosophers;
        public void StartDinner()
        {
            forks = new List<Fork>();
            philosophers = new List<Philosopher>();
            for (int i = 0; i < N; i++)
            { 
                Fork fork = new Fork();
                forks.Add(fork);
            }

            philosophers.Add(new Philosopher(forks[(0 + 1) % N], forks[0], textBox1));
            philosophers.Add(new Philosopher(forks[(1 + 1) % N], forks[1], textBox2));
            philosophers.Add(new Philosopher(forks[(2 + 1) % N], forks[2], textBox3));
            philosophers.Add(new Philosopher(forks[(3 + 1) % N], forks[3], textBox4));
            philosophers.Add(new Philosopher(forks[(4 + 1) % N], forks[4], textBox5));

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Thread> philosoferThreads = new List<Thread>();

            foreach (Philosopher philosofer in philosophers)
            {
                Thread philosoferThread = new Thread(new ThreadStart(philosofer.Run));
                philosoferThreads.Add(philosoferThread);
                philosoferThread.Start();
            }
        }
    }
}