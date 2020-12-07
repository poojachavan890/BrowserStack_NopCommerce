namespace BrowserStack.WebTests.Core.PageObjects
{
    public interface IModal
    {
        bool ModalIsVisible { get; }
        void BuildElements();
    }
}
