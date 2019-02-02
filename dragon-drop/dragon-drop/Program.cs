using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Interactions;

namespace dragon_drop
{
	class Program
	{
		// https://github.com/SeleniumHQ/selenium/issues/4243
		static void Main(string[] args)
		{
			using (IWebDriver browser = new ChromeDriver(@".\driver"))
			{
				browser.Navigate().GoToUrl("https://bhoipkemier.github.io/dragon-drop/");
				var from = browser.FindElement(By.Id("boxA"));
				var to = browser.FindElement(By.Id("boxB"));
				var action = new Actions(browser);
				action.DragAndDrop(from, to).Build().Perform();
				var statusSpan = browser.FindElement(By.Id("status"));
				Console.WriteLine( statusSpan.Text.Trim().Length > 0 ? statusSpan.Text.Trim() : "FAIL");
				browser.Close();
			}
			Console.ReadLine();
		}
	}
}
