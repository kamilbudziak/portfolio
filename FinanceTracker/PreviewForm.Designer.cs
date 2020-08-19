namespace FinanceTracker
{
    partial class PreviewForm
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
            this.Table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToResizeColumns = false;
            this.Table.AllowUserToResizeRows = false;
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(13, 12);
            this.Table.MultiSelect = false;
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RowHeadersVisible = false;
            this.Table.RowTemplate.Height = 24;
            this.Table.Size = new System.Drawing.Size(518, 233);
            this.Table.TabIndex = 0;
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 256);
            this.Controls.Add(this.Table);
            this.MaximumSize = new System.Drawing.Size(561, 303);
            this.MinimumSize = new System.Drawing.Size(561, 303);
            this.Name = "PreviewForm";
            this.Text = "PreviewForm";
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
    }
}