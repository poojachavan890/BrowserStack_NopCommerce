using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThGrid : ThElementBase
    {
        private readonly string _cssSelector;

        public ThGrid(
            string cssSelector
        ) : base(cssSelector: cssSelector)
        {
            _cssSelector = cssSelector;
        }

        public void ClickColumn(int columnNumber)
        {
            WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
            var selector = $"{_cssSelector} thead tr th";
            var columnSelector = By.CssSelector(selector);
            var columns = this.Driver.FindElements(columnSelector);
            columns[columnNumber - 1].Click();
        }

        public int ColumnCount
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
                var selector = By.CssSelector($"{_cssSelector} thead tr th");

                var columns = this.Driver.FindElements(selector);
                return columns.Count;
            }
        }

        public int RecordCount
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
                var selector = By.CssSelector($"{_cssSelector} tbody tr");
                var rows = this.Driver.FindElements(selector);
                return rows.Count;
            }
        }

        public IWebElement[] Rows
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
                var selector = By.CssSelector($"{_cssSelector} tbody tr");
                return this.Driver.FindElements(selector).ToArray();
            }
        }

        public void MouseOverRow(int rowNumber)
        {
            Actions actions = new Actions(this.Driver);

            var selector = By.CssSelector($"{_cssSelector} tbody tr:nth-child({rowNumber})");

            WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(selector));

            var row = Driver.FindElement(selector);

            actions.MoveToElement(row);
            actions.Perform();
        }

        public ThCell GetCell(int rowIndex, int cellIndex)
        {
            WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
            var rows = this.Driver.FindElements(By.CssSelector($"{_cssSelector} tbody tr"));
            var cells = rows[rowIndex].FindElements(By.TagName("td"));

            return new ThCell(cells[cellIndex]);
        }

        public T GetCell<T>(int rowIndex, int cellIndex) where T : ITemplateCell, new()
        {
            WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
            var rows = this.Driver.FindElements(By.CssSelector($"{_cssSelector} tbody tr"));
            var cells = rows[rowIndex].FindElements(By.TagName("td"));

            var cell = new T();
            // cell.Driver = this.Driver;
            cell.AssignCell(cells[cellIndex]);
            return cell;
        }

        public ThCellElement<T> GetCellElement<T>(int rowIndex, int cellIndex, By selector) where T : IThElement, new()
        {
            WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
            var rows = this.Driver.FindElements(By.CssSelector($"{_cssSelector} tbody tr"));
            var cells = rows[rowIndex].FindElements(By.TagName("td"));

            var cell = new ThCellElement<T>();
            if (cells.Count < cellIndex)
            {
                Assert.Fail($"Table Row {rowIndex} of table {_cssSelector} only has {cells.Count} cells. Trying to access index {cellIndex} on route {this.Driver.Url}");
            }
            cell.AssignCell(cells[cellIndex], selector);
            return cell;
        }

        public int FindRowWithElement(By selector, string attribute)
        {
            var sanityCheck = 0;
            var avaliableRow = false;
            while (!avaliableRow && sanityCheck < 3)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
                    var rowElements = this.Driver.FindElements(By.CssSelector($"{_cssSelector} tbody tr"));
                    if (rowElements.Count > 0)
                    {
                        int RowCount = 1;
                        wait = new WebDriverWait(this.Driver, System.TimeSpan.FromSeconds(15));
                        wait.Until(ExpectedConditions.ElementExists(selector));
                        var selectorElement = this.Driver.FindElement(selector);
                        foreach (IWebElement row in rowElements)
                        {
                            foreach (IWebElement child in row.FindElements(By.TagName(selectorElement.TagName)))
                            {
                                if (attribute.Equals("text"))
                                {
                                    if (selectorElement.Text.Equals(child.Text))
                                    {
                                        return RowCount;
                                    }
                                }
                                else if (selectorElement.GetAttribute(attribute).Equals(child.GetAttribute(attribute)))
                                {
                                    return RowCount;
                                }
                            }
                            RowCount = RowCount + 1;
                        }
                    }
                    avaliableRow = true;
                }
                catch (StaleElementReferenceException)
                {
                    sanityCheck++;
                }
            }
            return 0;
        }
    }
}
