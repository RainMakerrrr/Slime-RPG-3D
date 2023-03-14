namespace Logic.SoftCurrency
{
    public class CoinsPresenter
    {
        private readonly CoinsCounter _model;
        private readonly CoinsView _view;

        public CoinsPresenter(CoinsCounter model, CoinsView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _model.CoinsAdded += OnCoinsAdded;
            _view.UpdateText(_model.Current.ToString());
        }

        public void Disable()
        {
            _model.CoinsAdded -= OnCoinsAdded;
        }
        
        private void OnCoinsAdded(int coins)
        {
            _view.UpdateText(coins.ToString());
        }
    }
}