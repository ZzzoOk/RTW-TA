namespace RTW_TA
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.effectsBox = new System.Windows.Forms.ListBox();
			this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
			this.ancillariesBox = new System.Windows.Forms.ListBox();
			this.descriptionBox = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.traitsBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// effectsBox
			// 
			this.effectsBox.FormattingEnabled = true;
			this.effectsBox.ItemHeight = 16;
			this.effectsBox.Location = new System.Drawing.Point(13, 13);
			this.effectsBox.Margin = new System.Windows.Forms.Padding(4);
			this.effectsBox.Name = "effectsBox";
			this.effectsBox.Size = new System.Drawing.Size(196, 404);
			this.effectsBox.Sorted = true;
			this.effectsBox.TabIndex = 0;
			this.toolTip1.SetToolTip(this.effectsBox, "Effects");
			this.effectsBox.SelectedValueChanged += new System.EventHandler(this.effects_SelectedValueChanged);
			// 
			// ancillariesBox
			// 
			this.ancillariesBox.FormattingEnabled = true;
			this.ancillariesBox.ItemHeight = 16;
			this.ancillariesBox.Location = new System.Drawing.Point(217, 13);
			this.ancillariesBox.Margin = new System.Windows.Forms.Padding(4);
			this.ancillariesBox.Name = "ancillariesBox";
			this.ancillariesBox.Size = new System.Drawing.Size(196, 196);
			this.ancillariesBox.Sorted = true;
			this.ancillariesBox.TabIndex = 1;
			this.toolTip1.SetToolTip(this.ancillariesBox, "Ancillaries");
			this.ancillariesBox.SelectedValueChanged += new System.EventHandler(this.ancillaries_SelectedValueChanged);
			// 
			// descriptionBox
			// 
			this.descriptionBox.Location = new System.Drawing.Point(421, 13);
			this.descriptionBox.Margin = new System.Windows.Forms.Padding(4);
			this.descriptionBox.Multiline = true;
			this.descriptionBox.Name = "descriptionBox";
			this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.descriptionBox.Size = new System.Drawing.Size(400, 404);
			this.descriptionBox.TabIndex = 2;
			this.toolTip1.SetToolTip(this.descriptionBox, "Description");
			// 
			// traitsBox
			// 
			this.traitsBox.FormattingEnabled = true;
			this.traitsBox.ItemHeight = 16;
			this.traitsBox.Location = new System.Drawing.Point(217, 221);
			this.traitsBox.Margin = new System.Windows.Forms.Padding(4);
			this.traitsBox.Name = "traitsBox";
			this.traitsBox.Size = new System.Drawing.Size(196, 196);
			this.traitsBox.Sorted = true;
			this.traitsBox.TabIndex = 3;
			this.toolTip1.SetToolTip(this.traitsBox, "Traits");
			this.traitsBox.SelectedValueChanged += new System.EventHandler(this.traits_SelectedValueChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 430);
			this.Controls.Add(this.traitsBox);
			this.Controls.Add(this.descriptionBox);
			this.Controls.Add(this.ancillariesBox);
			this.Controls.Add(this.effectsBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Main";
			this.Text = "Rome - Total War: Traits & Ancillaries";
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Main_HelpButtonClicked);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox effectsBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private System.Windows.Forms.ListBox ancillariesBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox traitsBox;
    }
}

