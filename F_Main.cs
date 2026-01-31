using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// Desensolvido por Roberto Carlos PMG. Github: Dev. RCP91 
// Uso para calcular market preços rubinot.

namespace MarketRubinot
{
    public partial class F_Main : Form
    {
        MarketService marketService;
        public int TypeDoneOffer { get; set; } // 0 cancelado, 1 venda, 2 cpmpra, 3 pending
        public string OfferName { get; set; }
        public int Buy { get; set; }
        public int Sell { get; set; }
        public int Amount { get; set; }

        public int feeBuy { get; set; }
        public int feeSell { get; set; }
        public int Balance { get; set; }

        public F_Main()
        {
            InitializeComponent();
            marketService = new MarketService(this);
            nud_balance.Value = (Balance = marketService.GetBalance());
            LoadOffers();
        }

        void LoadOffers()
        {
            foreach (var o in marketService.GetAll())
            {
                var price = o.TypeOffer == 1 ? o.Sell : o.Buy;
                Sell = o.Sell;
                Buy = o.Buy;
                AddOfferDgv(o.TimeOffer, o.Name, o.TypeOffer, o.Amount, price, o.TypeDoneOffer);
            }
        }

        string GetStatusText(int type) =>
            type == 0 ? "Canceled"
            : type == 1 ? "Sold"
            : type == 2 ? "Buy"
            : "Pending";
        string GetOffertType(int type) => type == 1 ? "Sell" : type == 2 ? "Buy" : "Unknow";

        Control ChangeColor(Control control, float value)
        {
            control.BackColor = (value > 0)
                ? Color.FromArgb(0, 55, 0) : (value < 0)
                ? Color.FromArgb(192, 0, 0) : Color.Navy;
            return control;
        }
        int GetCalculate()
        {
            OfferName = tb_offerName.Text;
            Sell = Convert.ToInt32(nud_sell.Value);
            Buy = Convert.ToInt32(nud_buy.Value);
            Amount = Convert.ToInt32(nud_amount.Value);

            int totalBuy = Buy * Amount;
            int totalSell = Sell * Amount;

            feeBuy = marketService.CalculateFee(totalBuy);
            feeSell = marketService.CalculateFee(totalSell);

            int feeAll = feeBuy + feeSell;
            int profit = (nud_sell.Value > 0) ? totalSell - feeSell : totalBuy + feeBuy;

            int profitAll = totalSell - feeSell - totalBuy - feeBuy;

            lb_sellTotal.Text = totalSell.ToString("N0");
            lb_buyTotal.Text = (totalBuy).ToString("N0");

            lb_fee.Text = "-" + feeSell.ToString("N0");
            lb_feeBuy.Text = "-" + feeBuy.ToString("N0");
            lb_feeall.Text = "-" + feeAll.ToString("N0");

            lb_sellFinal.Text = profit.ToString("N0");
            lb_buyFinal.Text = (totalBuy + feeBuy).ToString("N0");

            lb_profit.Text = profitAll.ToString("N0");
            ChangeColor(lb_profit, profitAll);

            lb_profitNpc.Text = (profitAll + feeSell).ToString("N0");

            int totalProfit = totalSell - totalBuy - feeAll;
            float profitPercent = (totalSell > 0) ? (float)totalProfit / totalSell * 100f : 0f;
            float riskPercent = (totalSell > 0) ? (float)(totalBuy + feeAll) / totalSell * 100f : 0f;
            int buyAtt = profitAll > 0 && feeBuy > 0 ? profitAll / feeBuy : 0;
            int sellAtt = profitAll > 0 && feeSell > 0 ? profitAll / feeSell : 0;

            lb_profitPercent.Text = $"Profit:\n{profitPercent:N2}%";
            ChangeColor(lb_profitPercent, profitPercent);

            lb_display.Text = $"Risk: {Math.Min(riskPercent, 100f):N2}% / Attempts Buy: {buyAtt} / Attempts Sell: {sellAtt}";
            return 1;
        }
        void UpdateGridStatus(int rowIndex, int status)
        {
            dgv_marketList.Rows[rowIndex].Cells["Status"].Value = GetStatusText(status);
        }
        void AddOfferDgv(DateTime time, string name, int type, int amount, int price, int status)
        {
            var rowIndex = dgv_marketList.Rows.Add(
                time.ToString("HH:mm:ss"),
                GetOffertType(type),
                name,
                amount,
                price.ToString("N0"),
                GetStatusText(status)
            );
            dgv_marketList.Rows[rowIndex].Tag = new { buy = Buy, sell = Sell };
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveConfig();
        }

        private TextBox organizeNumeric(Object sender)
        {
            var nud = (NumericUpDown)sender;
            var textBox = nud.Controls[1] as TextBox;

            var pos = textBox.SelectionStart;
            textBox.Text = nud.Value.ToString("N0");
            textBox.SelectionStart = Math.Min(pos + 1, textBox.Text.Length);
            return textBox;
        }

        private void nud_amount_ValueChanged(object sender, EventArgs e)
        {
            var nud = (NumericUpDown)sender;
            var tb = nud.Controls[1] as TextBox;
            tb?.Select(tb.Text.Length, 0);

            if (nud == nud_balance)
            {
                marketService.UpdateBalance((int)nud_balance.Value);
            }

            sender = organizeNumeric(nud);
            GetCalculate();
        }

        private void nud_balance_KeyUp(object sender, KeyEventArgs e = null)
        {
            if (e.KeyCode == Keys.Back) return;
            GetCalculate();
        }

        private void btn_sell_Click(object sender, EventArgs e)
        {
            GetCalculate();
            marketService.CreateOffer();
            AddOfferDgv(DateTime.Now, OfferName, 1, Amount, Sell, 3);
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            GetCalculate();
            marketService.CreateOffer(2);
            AddOfferDgv(DateTime.Now, OfferName, 2, Amount, Buy, 3);
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            if (dgv_marketList.CurrentRow == null) return;

            var row = dgv_marketList.CurrentRow;
            var name = row.Cells["OfferName"].Value.ToString();
            var typeText = row.Cells["OfferType"].Value.ToString();

            int doneType = (typeText == GetOffertType(1)) ? 1 : (typeText == GetOffertType(2)) ? 2 : 3;

            marketService.FinishOffer(name, doneType);
            UpdateGridStatus(row.Index, doneType);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (dgv_marketList.CurrentRow == null) return;

            var row = dgv_marketList.CurrentRow;
            var name = row.Cells["OfferName"].Value.ToString();

            marketService.FinishOffer(name, 0);
            UpdateGridStatus(row.Index, 0);
        }

        private void dgv_marketList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            tb_offerName.Text = dgv_marketList.Rows[e.RowIndex].Cells["OfferName"].Value.ToString();
            int price = int.Parse(
                dgv_marketList.Rows[e.RowIndex].Cells["Price"].Value.ToString(),
                System.Globalization.NumberStyles.AllowThousands
            );

            var offerType = dgv_marketList.Rows[e.RowIndex].Cells["OfferType"].Value.ToString();
            int amount = Convert.ToInt32(dgv_marketList.Rows[e.RowIndex].Cells["dgv_Amount"].Value.ToString());

            var tag = dgv_marketList.Rows[e.RowIndex].Tag;
            dynamic tags = tag;

            nud_amount.Value = amount;
            nud_sell.Value = (offerType == GetOffertType(1)) ? price : tags.sell;
            nud_buy.Value = (offerType == GetOffertType(2)) ? price : tags.buy;

            GetCalculate();
        }

        private void tb_offerName_Click(object sender, EventArgs e)
        {
            tb_offerName.Text = "";
        }
    }
    class MarketService
    {
        const string CONFIG_FILE = "config.json";
        ConfigJson configJson;
        F_Main F;

        public MarketService(F_Main f)
        {
            F = f;
            LoadConfig();

        }
        public List<MarketItem> GetAll() => configJson.MarketItem;
        public int CalculateFee(int price) => Math.Min(1000000, Math.Max(20, (int)(price * 0.02)));
        public int GetBalance() => configJson.LastBalance;

        public void UpdateBalance(int value)
        {
            F.Balance = value;
            F.nud_balance.Value = value;
            configJson.LastBalance = value;
            SaveConfig();
        }

        public void CreateOffer(int type = 1)
        {
            var m = F;

            int totalBuy = m.Buy * m.Amount;
            int totalSell = m.Sell * m.Amount;

            int feeBuy = CalculateFee(totalBuy);
            int feeSell = CalculateFee(totalSell);

            configJson.MarketItem.Add(new MarketItem
            {
                TimeOffer = DateTime.Now,
                Name = m.OfferName,
                TypeOffer = type,
                Buy = m.Buy,
                Sell = m.Sell,
                Amount = m.Amount,
                TypeDoneOffer = 3
            });

            int newBalance = type == 1 ? m.Balance - feeSell : (m.Balance - (totalBuy + feeBuy));
            UpdateBalance(newBalance);
        }

        public void FinishOffer(string name, int action)
        {
            var offer = configJson.MarketItem.FirstOrDefault(o => o.Name == name && o.TypeDoneOffer == 3);
            if (offer == null) return;

            int totalBuy = offer.Buy * offer.Amount;
            int totalSell = offer.Sell * offer.Amount;

            int balanceChange = action == 1 ? totalSell : (action == 0 ? totalBuy : 0);
            UpdateBalance(F.Balance + balanceChange);

            offer.TypeDoneOffer = action;
            SaveConfig();
        }

        public MarketItem GetPending(string name) => configJson.MarketItem.First(o => o.Name == name && o.TypeDoneOffer == 3);
        void SaveConfig() => File.WriteAllText(CONFIG_FILE, JsonConvert.SerializeObject(configJson, Newtonsoft.Json.Formatting.Indented));
        
        void LoadConfig()
        {
            configJson = File.Exists(CONFIG_FILE) ? JsonConvert.DeserializeObject<ConfigJson>(File.ReadAllText(CONFIG_FILE)): null;
            if (configJson == null) configJson = new ConfigJson();
            if (configJson.MarketItem == null)configJson.MarketItem = new List<MarketItem>();
        }
    }


    class ConfigJson
    {
        public List<MarketItem> MarketItem { get; set; }
        public int LastBalance { get; set; }
    }
    class MarketItem
    {
        public DateTime TimeOffer { get; set; }
        public string Name { get; set; }
        public int TypeOffer { get; set; } // sell ou buy.
        public int TypeDoneOffer { get; set; } // 0 cancelado, 1 vendid, 2 comprado, 3 pending.
        public int Buy { get; set; }
        public int Sell { get; set; }
        public int Amount { get; set; }
    }
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F_Main());
        }
    }
}