internal class Program
{
	private static void Main(string[] args)
	{
		Thread thread1 = new Thread(MyMethod1);
		Thread thread2 = new Thread(MyMethod2);
		thread1.Start();
		thread2.Start("-");

		Thread.Sleep(2000);
	}
	static void MyMethod1()
	{
		for (int i = 1; i < 4; i++)
		{
			Thread.Sleep(1000);
			Console.WriteLine(i);
		}
	}
	static void MyMethod2(object message)
	{
		for (int i = 4; i < 7; i++)
		{
			Thread.Sleep(500);
			Console.WriteLine(i);
		}
	}
}