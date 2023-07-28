namespace CarShopMaui.ViewModels.Base
{
    public abstract class BaseViewModel : ObservableObject, INavigation
    {
        public IReadOnlyList<Page> ModalStack { get; }

        public IReadOnlyList<Page> NavigationStack { get; }

        public INavigation Navigation { get; set; }


        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public void InsertPageBefore(Page page, Page before)
        {
            throw new NotImplementedException();
        }

        public async Task<Page> PopAsync()
        {
            var task = Navigation?.PopAsync();

            return task != null ? await task : null;
        }

        public Task<Page> PopAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public async Task PushAsync(Page page)
        {
            var task = Navigation?.PushAsync(page);

            if (task != null)
                await task;
        }

        public Task PushAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public void RemovePage(Page page)
        {
            throw new NotImplementedException();
        }
    }
}
