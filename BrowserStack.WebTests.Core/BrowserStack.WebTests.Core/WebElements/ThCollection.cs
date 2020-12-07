using Autofac;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BrowserStack.WebTests.Core.WebElements
{
    public class ThCollection<T>
    {
        private readonly Dictionary<string, T> _elements;

        /// <summary>
        /// 
        /// </summary>
        public ThCollection()
        {
            _elements = new Dictionary<string, T>();
        }

        public void AddElement(string itemIdentifier, T element)
        {
            this._elements[itemIdentifier] = element;
        }

        public T GetElement(string itemIdentifier)
        {
            if (!this._elements.ContainsKey(itemIdentifier))
            {
                var driver = WebTestSuiteBase.Container.Resolve<IWebDriver>();
                var errorMessage =
                    $"The key '{itemIdentifier}' was not found in the collection on {driver.Url.ToString()}.  Available keys include: {string.Join(", ", this._elements.Keys)}";
                throw new Exception(errorMessage);
            }

            return this._elements[itemIdentifier];
        }
    }
}
