namespace MarketRubinot
{
    partial class F_Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Main));
            this.nud_sell = new System.Windows.Forms.NumericUpDown();
            this.nud_buy = new System.Windows.Forms.NumericUpDown();
            this.lb_sellFinal = new System.Windows.Forms.Label();
            this.lb_fee = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_amount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_display = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_feeall = new System.Windows.Forms.Label();
            this.lb_profit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_balance = new System.Windows.Forms.NumericUpDown();
            this.lb_profitNpc = new System.Windows.Forms.Label();
            this.lb_feeBuy = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_buyTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lb_sellTotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_buyFinal = new System.Windows.Forms.Label();
            this.lb_profitPercent = new System.Windows.Forms.Label();
            this.tb_offerName = new System.Windows.Forms.TextBox();
            this.btn_buy = new System.Windows.Forms.Button();
            this.btn_sell = new System.Windows.Forms.Button();
            this.btn_done = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.dgv_marketList = new System.Windows.Forms.DataGridView();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfferType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_buy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_marketList)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_sell
            // 
            this.nud_sell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nud_sell.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nud_sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_sell.ForeColor = System.Drawing.Color.Yellow;
            this.nud_sell.Location = new System.Drawing.Point(15, 89);
            this.nud_sell.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_sell.Name = "nud_sell";
            this.nud_sell.Size = new System.Drawing.Size(129, 20);
            this.nud_sell.TabIndex = 1;
            this.nud_sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_sell.ThousandsSeparator = true;
            this.nud_sell.ValueChanged += new System.EventHandler(this.nud_amount_ValueChanged);
            this.nud_sell.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_balance_KeyUp);
            // 
            // nud_buy
            // 
            this.nud_buy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nud_buy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nud_buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_buy.ForeColor = System.Drawing.Color.Yellow;
            this.nud_buy.Location = new System.Drawing.Point(15, 123);
            this.nud_buy.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_buy.Name = "nud_buy";
            this.nud_buy.Size = new System.Drawing.Size(129, 20);
            this.nud_buy.TabIndex = 2;
            this.nud_buy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_buy.ThousandsSeparator = true;
            this.nud_buy.ValueChanged += new System.EventHandler(this.nud_amount_ValueChanged);
            this.nud_buy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_balance_KeyUp);
            // 
            // lb_sellFinal
            // 
            this.lb_sellFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(0)))));
            this.lb_sellFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_sellFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sellFinal.ForeColor = System.Drawing.Color.White;
            this.lb_sellFinal.Location = new System.Drawing.Point(245, 207);
            this.lb_sellFinal.Name = "lb_sellFinal";
            this.lb_sellFinal.Size = new System.Drawing.Size(177, 19);
            this.lb_sellFinal.TabIndex = 6;
            this.lb_sellFinal.Text = "0";
            this.lb_sellFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_sellFinal.UseMnemonic = false;
            // 
            // lb_fee
            // 
            this.lb_fee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_fee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_fee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fee.ForeColor = System.Drawing.Color.White;
            this.lb_fee.Location = new System.Drawing.Point(245, 109);
            this.lb_fee.Name = "lb_fee";
            this.lb_fee.Size = new System.Drawing.Size(177, 21);
            this.lb_fee.TabIndex = 8;
            this.lb_fee.Text = "0";
            this.lb_fee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_fee.UseMnemonic = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price to Sell:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label4.UseMnemonic = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Price to Buy:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label5.UseMnemonic = false;
            // 
            // nud_amount
            // 
            this.nud_amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nud_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nud_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_amount.ForeColor = System.Drawing.Color.Yellow;
            this.nud_amount.Location = new System.Drawing.Point(15, 157);
            this.nud_amount.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.nud_amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_amount.Name = "nud_amount";
            this.nud_amount.Size = new System.Drawing.Size(129, 20);
            this.nud_amount.TabIndex = 3;
            this.nud_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_amount.ThousandsSeparator = true;
            this.nud_amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_amount.ValueChanged += new System.EventHandler(this.nud_amount_ValueChanged);
            this.nud_amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_balance_KeyUp);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(163, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fee Sell";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(163, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sell Final";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Amount:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.UseMnemonic = false;
            // 
            // lb_display
            // 
            this.lb_display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lb_display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_display.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lb_display.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_display.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_display.ForeColor = System.Drawing.Color.Yellow;
            this.lb_display.Location = new System.Drawing.Point(15, 273);
            this.lb_display.Name = "lb_display";
            this.lb_display.Size = new System.Drawing.Size(420, 23);
            this.lb_display.TabIndex = 14;
            this.lb_display.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_display.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(150, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 223);
            this.label2.TabIndex = 18;
            this.label2.Text = "Profit Total on Market";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.UseMnemonic = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(163, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fee All";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.UseMnemonic = false;
            // 
            // lb_feeall
            // 
            this.lb_feeall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_feeall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_feeall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_feeall.ForeColor = System.Drawing.Color.White;
            this.lb_feeall.Location = new System.Drawing.Point(245, 156);
            this.lb_feeall.Name = "lb_feeall";
            this.lb_feeall.Size = new System.Drawing.Size(177, 20);
            this.lb_feeall.TabIndex = 16;
            this.lb_feeall.Text = "0";
            this.lb_feeall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_feeall.UseMnemonic = false;
            // 
            // lb_profit
            // 
            this.lb_profit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(0)))));
            this.lb_profit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_profit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_profit.ForeColor = System.Drawing.Color.White;
            this.lb_profit.Location = new System.Drawing.Point(245, 234);
            this.lb_profit.Name = "lb_profit";
            this.lb_profit.Size = new System.Drawing.Size(177, 19);
            this.lb_profit.TabIndex = 15;
            this.lb_profit.Text = "0";
            this.lb_profit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_profit.UseMnemonic = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Balance:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label8.UseMnemonic = false;
            // 
            // nud_balance
            // 
            this.nud_balance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nud_balance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nud_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_balance.ForeColor = System.Drawing.Color.Yellow;
            this.nud_balance.Location = new System.Drawing.Point(15, 55);
            this.nud_balance.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_balance.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.nud_balance.Name = "nud_balance";
            this.nud_balance.Size = new System.Drawing.Size(129, 20);
            this.nud_balance.TabIndex = 0;
            this.nud_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_balance.ThousandsSeparator = true;
            this.nud_balance.ValueChanged += new System.EventHandler(this.nud_amount_ValueChanged);
            this.nud_balance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_balance_KeyUp);
            // 
            // lb_profitNpc
            // 
            this.lb_profitNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(0)))));
            this.lb_profitNpc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_profitNpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_profitNpc.ForeColor = System.Drawing.Color.White;
            this.lb_profitNpc.Location = new System.Drawing.Point(15, 249);
            this.lb_profitNpc.Name = "lb_profitNpc";
            this.lb_profitNpc.Size = new System.Drawing.Size(129, 18);
            this.lb_profitNpc.TabIndex = 23;
            this.lb_profitNpc.Text = "0";
            this.lb_profitNpc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_profitNpc.UseMnemonic = false;
            // 
            // lb_feeBuy
            // 
            this.lb_feeBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_feeBuy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_feeBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_feeBuy.ForeColor = System.Drawing.Color.White;
            this.lb_feeBuy.Location = new System.Drawing.Point(245, 133);
            this.lb_feeBuy.Name = "lb_feeBuy";
            this.lb_feeBuy.Size = new System.Drawing.Size(177, 20);
            this.lb_feeBuy.TabIndex = 24;
            this.lb_feeBuy.Text = "0";
            this.lb_feeBuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_feeBuy.UseMnemonic = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(163, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Fee Buy";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.UseMnemonic = false;
            // 
            // lb_buyTotal
            // 
            this.lb_buyTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.lb_buyTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_buyTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_buyTotal.ForeColor = System.Drawing.Color.White;
            this.lb_buyTotal.Location = new System.Drawing.Point(245, 82);
            this.lb_buyTotal.Name = "lb_buyTotal";
            this.lb_buyTotal.Size = new System.Drawing.Size(177, 20);
            this.lb_buyTotal.TabIndex = 26;
            this.lb_buyTotal.Text = "0";
            this.lb_buyTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_buyTotal.UseMnemonic = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 32);
            this.label9.TabIndex = 27;
            this.label9.Text = "    Npc Profit Total";
            this.label9.UseMnemonic = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(163, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Buy Total";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.UseMnemonic = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(163, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 19);
            this.label13.TabIndex = 29;
            this.label13.Text = "Profit Total";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.UseMnemonic = false;
            // 
            // lb_sellTotal
            // 
            this.lb_sellTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(0)))));
            this.lb_sellTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_sellTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sellTotal.ForeColor = System.Drawing.Color.White;
            this.lb_sellTotal.Location = new System.Drawing.Point(245, 60);
            this.lb_sellTotal.Name = "lb_sellTotal";
            this.lb_sellTotal.Size = new System.Drawing.Size(177, 19);
            this.lb_sellTotal.TabIndex = 30;
            this.lb_sellTotal.Text = "0";
            this.lb_sellTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_sellTotal.UseMnemonic = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(163, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 19);
            this.label14.TabIndex = 31;
            this.label14.Text = "Sell Total";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.UseMnemonic = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(163, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Buy Final";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.UseMnemonic = false;
            // 
            // lb_buyFinal
            // 
            this.lb_buyFinal.BackColor = System.Drawing.Color.Navy;
            this.lb_buyFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_buyFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_buyFinal.ForeColor = System.Drawing.Color.White;
            this.lb_buyFinal.Location = new System.Drawing.Point(245, 184);
            this.lb_buyFinal.Name = "lb_buyFinal";
            this.lb_buyFinal.Size = new System.Drawing.Size(177, 20);
            this.lb_buyFinal.TabIndex = 32;
            this.lb_buyFinal.Text = "0";
            this.lb_buyFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_buyFinal.UseMnemonic = false;
            // 
            // lb_profitPercent
            // 
            this.lb_profitPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(0)))));
            this.lb_profitPercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_profitPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_profitPercent.ForeColor = System.Drawing.Color.White;
            this.lb_profitPercent.Location = new System.Drawing.Point(15, 184);
            this.lb_profitPercent.Name = "lb_profitPercent";
            this.lb_profitPercent.Size = new System.Drawing.Size(129, 42);
            this.lb_profitPercent.TabIndex = 34;
            this.lb_profitPercent.Text = "0";
            this.lb_profitPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_profitPercent.UseMnemonic = false;
            // 
            // tb_offerName
            // 
            this.tb_offerName.BackColor = System.Drawing.SystemColors.MenuText;
            this.tb_offerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_offerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_offerName.ForeColor = System.Drawing.Color.Yellow;
            this.tb_offerName.Location = new System.Drawing.Point(15, 12);
            this.tb_offerName.MaxLength = 100;
            this.tb_offerName.Multiline = true;
            this.tb_offerName.Name = "tb_offerName";
            this.tb_offerName.Size = new System.Drawing.Size(420, 24);
            this.tb_offerName.TabIndex = 35;
            this.tb_offerName.Text = "OFFER NAME";
            this.tb_offerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_offerName.Click += new System.EventHandler(this.tb_offerName_Click);
            // 
            // btn_buy
            // 
            this.btn_buy.BackColor = System.Drawing.Color.Gray;
            this.btn_buy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buy.ForeColor = System.Drawing.Color.Blue;
            this.btn_buy.Location = new System.Drawing.Point(516, 274);
            this.btn_buy.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btn_buy.Name = "btn_buy";
            this.btn_buy.Size = new System.Drawing.Size(65, 23);
            this.btn_buy.TabIndex = 37;
            this.btn_buy.Text = "Buy";
            this.btn_buy.UseVisualStyleBackColor = false;
            this.btn_buy.Click += new System.EventHandler(this.btn_buy_Click);
            // 
            // btn_sell
            // 
            this.btn_sell.BackColor = System.Drawing.Color.Gray;
            this.btn_sell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sell.ForeColor = System.Drawing.Color.Green;
            this.btn_sell.Location = new System.Drawing.Point(441, 274);
            this.btn_sell.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.btn_sell.Name = "btn_sell";
            this.btn_sell.Size = new System.Drawing.Size(65, 23);
            this.btn_sell.TabIndex = 38;
            this.btn_sell.Text = "Sell";
            this.btn_sell.UseVisualStyleBackColor = false;
            this.btn_sell.Click += new System.EventHandler(this.btn_sell_Click);
            // 
            // btn_done
            // 
            this.btn_done.BackColor = System.Drawing.Color.Gray;
            this.btn_done.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_done.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_done.ForeColor = System.Drawing.Color.Green;
            this.btn_done.Location = new System.Drawing.Point(754, 274);
            this.btn_done.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(107, 23);
            this.btn_done.TabIndex = 39;
            this.btn_done.Text = "Finalize Offer";
            this.btn_done.UseVisualStyleBackColor = false;
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Maroon;
            this.btn_cancel.Location = new System.Drawing.Point(629, 274);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(30, 5, 15, 5);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 23);
            this.btn_cancel.TabIndex = 40;
            this.btn_cancel.Text = "Cancel Offer";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // dgv_marketList
            // 
            this.dgv_marketList.AllowUserToAddRows = false;
            this.dgv_marketList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Yellow;
            this.dgv_marketList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_marketList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgv_marketList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_marketList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_marketList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_marketList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_marketList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hour,
            this.OfferType,
            this.offerName,
            this.dgv_Amount,
            this.Price,
            this.Status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_marketList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_marketList.Location = new System.Drawing.Point(441, 12);
            this.dgv_marketList.Name = "dgv_marketList";
            this.dgv_marketList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_marketList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_marketList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow;
            this.dgv_marketList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_marketList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_marketList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_marketList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgv_marketList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Yellow;
            this.dgv_marketList.RowTemplate.ReadOnly = true;
            this.dgv_marketList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_marketList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_marketList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_marketList.Size = new System.Drawing.Size(420, 254);
            this.dgv_marketList.TabIndex = 41;
            this.dgv_marketList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_marketList_CellClick);
            // 
            // Hour
            // 
            this.Hour.HeaderText = "Hours";
            this.Hour.MaxInputLength = 20;
            this.Hour.Name = "Hour";
            this.Hour.ReadOnly = true;
            this.Hour.Width = 70;
            // 
            // OfferType
            // 
            this.OfferType.HeaderText = "Type";
            this.OfferType.MaxInputLength = 10;
            this.OfferType.Name = "OfferType";
            this.OfferType.ReadOnly = true;
            this.OfferType.Width = 50;
            // 
            // offerName
            // 
            this.offerName.HeaderText = "Offer";
            this.offerName.Name = "offerName";
            this.offerName.ReadOnly = true;
            // 
            // dgv_Amount
            // 
            this.dgv_Amount.HeaderText = "Amount";
            this.dgv_Amount.MaxInputLength = 12;
            this.dgv_Amount.Name = "dgv_Amount";
            this.dgv_Amount.ReadOnly = true;
            this.dgv_Amount.Width = 70;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MaxInputLength = 12;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MaxInputLength = 10;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(600, 274);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(10, 23);
            this.panel1.TabIndex = 42;
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(878, 306);
            this.Controls.Add(this.btn_sell);
            this.Controls.Add(this.dgv_marketList);
            this.Controls.Add(this.btn_done);
            this.Controls.Add(this.tb_offerName);
            this.Controls.Add(this.btn_buy);
            this.Controls.Add(this.lb_profitPercent);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_buyFinal);
            this.Controls.Add(this.lb_sellTotal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lb_buyTotal);
            this.Controls.Add(this.lb_feeBuy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_profitNpc);
            this.Controls.Add(this.nud_balance);
            this.Controls.Add(this.lb_profit);
            this.Controls.Add(this.lb_feeall);
            this.Controls.Add(this.lb_sellFinal);
            this.Controls.Add(this.lb_fee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_display);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nud_amount);
            this.Controls.Add(this.nud_buy);
            this.Controls.Add(this.nud_sell);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_Main";
            this.Text = "Market Calculator - Dev. RCP91";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nud_sell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_buy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_marketList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.NumericUpDown nud_sell;
        public System.Windows.Forms.NumericUpDown nud_buy;
        private System.Windows.Forms.Label lb_sellFinal;
        private System.Windows.Forms.Label lb_fee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nud_amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_display;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_feeall;
        private System.Windows.Forms.Label lb_profit;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown nud_balance;
        private System.Windows.Forms.Label lb_profitNpc;
        private System.Windows.Forms.Label lb_feeBuy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_buyTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lb_sellTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_buyFinal;
        private System.Windows.Forms.Label lb_profitPercent;
        private System.Windows.Forms.TextBox tb_offerName;
        private System.Windows.Forms.Button btn_buy;
        private System.Windows.Forms.Button btn_sell;
        private System.Windows.Forms.Button btn_done;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridView dgv_marketList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferType;
        private System.Windows.Forms.DataGridViewTextBoxColumn offerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Panel panel1;
    }
}

