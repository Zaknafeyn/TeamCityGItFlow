namespace RabbitMQMngmt
{
    partial class frmRabbitMQMngr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRabbitMQMngr));
            this._cmbHosts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cmbEntityType = new System.Windows.Forms.ComboBox();
            this._clbItems = new System.Windows.Forms.CheckedListBox();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnSelectNone = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnExit = new System.Windows.Forms.Button();
            this._chbDeleteVirtualHost = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _cmbHosts
            // 
            this._cmbHosts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbHosts.FormattingEnabled = true;
            this._cmbHosts.Location = new System.Drawing.Point(81, 6);
            this._cmbHosts.Name = "_cmbHosts";
            this._cmbHosts.Size = new System.Drawing.Size(187, 21);
            this._cmbHosts.TabIndex = 0;
            this._cmbHosts.SelectedIndexChanged += new System.EventHandler(this._cmbHosts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VirtualHosts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entity type";
            // 
            // _cmbEntityType
            // 
            this._cmbEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEntityType.FormattingEnabled = true;
            this._cmbEntityType.Location = new System.Drawing.Point(336, 6);
            this._cmbEntityType.Name = "_cmbEntityType";
            this._cmbEntityType.Size = new System.Drawing.Size(187, 21);
            this._cmbEntityType.TabIndex = 2;
            this._cmbEntityType.SelectedIndexChanged += new System.EventHandler(this._cmbEntityType_SelectedIndexChanged);
            // 
            // _clbItems
            // 
            this._clbItems.CheckOnClick = true;
            this._clbItems.FormattingEnabled = true;
            this._clbItems.Location = new System.Drawing.Point(12, 59);
            this._clbItems.Name = "_clbItems";
            this._clbItems.Size = new System.Drawing.Size(511, 259);
            this._clbItems.TabIndex = 4;
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Location = new System.Drawing.Point(12, 33);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this._btnSelectAll.TabIndex = 6;
            this._btnSelectAll.Text = "Select all";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this._btnSelectAll_Click);
            // 
            // _btnSelectNone
            // 
            this._btnSelectNone.Location = new System.Drawing.Point(93, 33);
            this._btnSelectNone.Name = "_btnSelectNone";
            this._btnSelectNone.Size = new System.Drawing.Size(75, 23);
            this._btnSelectNone.TabIndex = 7;
            this._btnSelectNone.Text = "Select none";
            this._btnSelectNone.UseVisualStyleBackColor = true;
            this._btnSelectNone.Click += new System.EventHandler(this._btnSelectNone_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(12, 325);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(75, 23);
            this._btnDelete.TabIndex = 8;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // _btnExit
            // 
            this._btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnExit.Location = new System.Drawing.Point(448, 325);
            this._btnExit.Name = "_btnExit";
            this._btnExit.Size = new System.Drawing.Size(75, 23);
            this._btnExit.TabIndex = 9;
            this._btnExit.Text = "Exit";
            this._btnExit.UseVisualStyleBackColor = true;
            this._btnExit.Click += new System.EventHandler(this._btnExit_Click);
            // 
            // _chbDeleteVirtualHost
            // 
            this._chbDeleteVirtualHost.AutoSize = true;
            this._chbDeleteVirtualHost.Location = new System.Drawing.Point(174, 37);
            this._chbDeleteVirtualHost.Name = "_chbDeleteVirtualHost";
            this._chbDeleteVirtualHost.Size = new System.Drawing.Size(111, 17);
            this._chbDeleteVirtualHost.TabIndex = 10;
            this._chbDeleteVirtualHost.Text = "Delete virtual host";
            this._chbDeleteVirtualHost.UseVisualStyleBackColor = true;
            this._chbDeleteVirtualHost.CheckedChanged += new System.EventHandler(this._chbDeleteVirtualHost_CheckedChanged);
            // 
            // frmRabbitMQMngr
            // 
            this.AcceptButton = this._btnDelete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnExit;
            this.ClientSize = new System.Drawing.Size(537, 360);
            this.Controls.Add(this._chbDeleteVirtualHost);
            this.Controls.Add(this._btnExit);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnSelectNone);
            this.Controls.Add(this._btnSelectAll);
            this.Controls.Add(this._clbItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cmbEntityType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cmbHosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRabbitMQMngr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RabbitMQManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cmbHosts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmbEntityType;
        private System.Windows.Forms.CheckedListBox _clbItems;
        private System.Windows.Forms.Button _btnSelectAll;
        private System.Windows.Forms.Button _btnSelectNone;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnExit;
        private System.Windows.Forms.CheckBox _chbDeleteVirtualHost;
    }
}

