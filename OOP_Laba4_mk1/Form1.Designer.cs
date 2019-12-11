namespace OOP_Laba4_mk1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.painBox = new System.Windows.Forms.Panel();
            this.painter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // painBox
            // 
            this.painBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.painBox.Location = new System.Drawing.Point(352, 3);
            this.painBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.painBox.Name = "painBox";
            this.painBox.Size = new System.Drawing.Size(622, 575);
            this.painBox.TabIndex = 0;
            this.painBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.painBox_MouseDown);
            this.painBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.painBox_MouseUp);
            // 
            // painter
            // 
            this.painter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.painter.Name = "painter";
            this.painter.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 586);
            this.Controls.Add(this.painBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel painBox;
        private System.Windows.Forms.ContextMenuStrip painter;
    }
}

