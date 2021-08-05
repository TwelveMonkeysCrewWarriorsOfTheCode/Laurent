
namespace ArithmeticOperatorWUI
{
    partial class FrmDataList
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
            this.LvData = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LvData
            // 
            this.LvData.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LvData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LvData.HideSelection = false;
            this.LvData.Location = new System.Drawing.Point(15, 12);
            this.LvData.Name = "LvData";
            this.LvData.Size = new System.Drawing.Size(770, 426);
            this.LvData.TabIndex = 0;
            this.LvData.UseCompatibleStateImageBehavior = false;
            this.LvData.View = System.Windows.Forms.View.Details;
            // 
            // FrmDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LvData);
            this.Name = "FrmDataList";
            this.Text = "Liste des données";
            this.Load += new System.EventHandler(this.FrmDataList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvData;
    }
}