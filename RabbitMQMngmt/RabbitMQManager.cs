using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQMngmt.DTO;

namespace RabbitMQMngmt
{
    public partial class frmRabbitMQMngr : Form
    {
        private RabbitMqAccess _rmqAccess;

        private Dictionary<string, RmqItems> _rmqItems = new Dictionary<string, RmqItems>
        {
            {"None", RmqItems.None},
            {"Queues", RmqItems.Queues},
            {"Exchanges", RmqItems.Exchanges},
        };

        public frmRabbitMQMngr(RabbitMqAccess rmqAccess)
        {
            InitializeComponent();
            _rmqAccess = rmqAccess;
            PopulateInitialData();
        }

        

        private void _cmbEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }



        private void _btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _cmbHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void _chbDeleteVirtualHost_CheckedChanged(object sender, EventArgs e)
        {
            var value = _chbDeleteVirtualHost.Checked;

            if (value)
            {
                _cmbEntityType.SelectedIndex = 0;
            }

            _cmbEntityType.Enabled = !value;
            _btnSelectAll.Enabled = !value;
            _btnSelectNone.Enabled = !value;
            _clbItems.Enabled = !value;

        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            if (_chbDeleteVirtualHost.Checked)
            {
                // delete selected vhost
                _rmqAccess.DeleteVhost(GetVHost());
                // refresh
                _cmbEntityType.DataSource = _rmqItems.ToList();
                return;
            }

            // delete selected items

            var entityType = (RmqItems)_cmbEntityType.SelectedValue;
            switch (entityType)
            {
                case RmqItems.Queues:
                    DeleteItem<QueueItem>(GetVHost(), _rmqAccess.DeleteQueue);
                    //DeleteQueues(GetVHost());
                    RefreshItems();
                    break;
                case RmqItems.Exchanges:
                    DeleteItem<ExchangeItem>(GetVHost(), _rmqAccess.DeleteExchange);
                    //DeleteExchanges(GetVHost());
                    RefreshItems();
                    break;
            }

        }

        private void _btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll(true);
        }

        private void _btnSelectNone_Click(object sender, EventArgs e)
        {
            SelectAll(false);
        }



        #region Helpers

        private void PopulateInitialData()
        {
            this.Text = string.Format("{0} - {1}", this.Text, _rmqAccess.GetNodeHost());
            _cmbHosts.DataSource = _rmqAccess.GetVHosts();

            _cmbEntityType.DisplayMember = "Key";
            _cmbEntityType.ValueMember = "Value";

            _cmbEntityType.DataSource = _rmqItems.ToList();
        }

        private void RefreshItems()
        {
            if (_cmbEntityType.SelectedValue == null)
                return;

            var value = (RmqItems)_cmbEntityType.SelectedValue;
            var vhost = _cmbHosts.SelectedItem.ToString();
            RefreshItems(vhost, value);
        }

        private void RefreshItems(string vhost, RmqItems itemsToRefresh)
        {
            switch (itemsToRefresh)
            {
                case RmqItems.None:
                    break;

                case RmqItems.Queues:
                    PopulateQueues(vhost);
                    break;
                case RmqItems.Exchanges:
                    PopulateExchanges(vhost);
                    break;
            }

            SelectAll(false);
        }

        private void PopulateExchanges(string host)
        {
            var exchanges = _rmqAccess.GetExchanges(host);

            _clbItems.DataSource = exchanges;
            var enabled = exchanges.Count != 0;

            _btnSelectAll.Enabled = enabled;
            _btnSelectNone.Enabled = enabled;
        }

        private void PopulateQueues(string host)
        {
            var queues = _rmqAccess.GetQueues(host);

            _clbItems.DataSource = queues;
            var enabled = queues.Count != 0;

            _btnSelectAll.Enabled = enabled;
            _btnSelectNone.Enabled = enabled;
        }

        private string GetVHost()
        {
            return _cmbHosts.SelectedValue.ToString();
        }

        private void DeleteItem<T>(string vhost, Action<string, string> deleteAction ) where T : RmqDataItem
        {
            foreach (var selectedIndex in _clbItems.CheckedItems)
            {
                var item = (T)selectedIndex;
                deleteAction(vhost, item.Name);
            }
        }

        private void SelectAll(bool value)
        {
            
            for (int i = 0; i < _clbItems.Items.Count; i++)
                _clbItems.SetItemChecked(i, value);
        } 

        #endregion
    }
}
