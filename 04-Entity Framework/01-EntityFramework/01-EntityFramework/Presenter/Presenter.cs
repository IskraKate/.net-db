using ModelNamespace;
using System.Data.Entity;
using System.Windows.Forms;
using View;

namespace PresenterNamespace
{
    class Presenter
    {
        private SalesContext _salesContext;
        public Presenter(IView view, SalesContext salesContext)
        {
            _salesContext = salesContext;
            view.ViewEvent += View_ViewEvent;
        }

        private void View_ViewEvent(System.Windows.Forms.ListView listview)
        {
            _salesContext.Buyers.Load();
            _salesContext.Sellers.Load();
            _salesContext.SalesInfos.Load();

            foreach (var sale in _salesContext.SalesInfos)
            {
                ListViewItem listViewItem = listview.Items.Add(new ListViewItem());
                listViewItem.Text = sale.Buyer.FirstName;
                listViewItem.SubItems.Add(sale.Buyer.LastName);
                listViewItem.SubItems.Add(sale.Seller.FirstName);
                listViewItem.SubItems.Add(sale.Seller.LastName);
                listViewItem.SubItems.Add(sale.MoneySum.ToString());
                listViewItem.SubItems.Add(sale.Date.ToShortDateString());
            }

        }
    }
}
