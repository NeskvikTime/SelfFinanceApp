using SelfFinanceApp.Domain.Pages.Abstractions;

namespace SelfFinanceApp.Domain.Pages
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Items { get; set; }

        public PagedResult()
        {
            Items = new List<T>();
        }
    }
}
