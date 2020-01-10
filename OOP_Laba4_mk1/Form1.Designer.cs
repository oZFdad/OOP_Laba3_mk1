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
            this.btDelMarked = new System.Windows.Forms.Button();
            this.btDelAll = new System.Windows.Forms.Button();
            this.labelNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // painBox
            // 
            this.painBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.painBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.painBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.painBox.Location = new System.Drawing.Point(197, 1);
            this.painBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.painBox.Name = "painBox";
            this.painBox.Size = new System.Drawing.Size(647, 508);
            this.painBox.TabIndex = 0;
            this.painBox.Paint += new System.Windows.Forms.PaintEventHandler(this.painBox_Paint);
            this.painBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.painBox_MouseDown);
            // 
            // painter
            // 
            this.painter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.painter.Name = "painter";
            this.painter.Size = new System.Drawing.Size(61, 4);
            // 
            // btDelMarked
            // 
            this.btDelMarked.Location = new System.Drawing.Point(8, 8);
            this.btDelMarked.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btDelMarked.Name = "btDelMarked";
            this.btDelMarked.Size = new System.Drawing.Size(173, 57);
            this.btDelMarked.TabIndex = 1;
            this.btDelMarked.Text = "Удалить выделеные объекты клавиша delete";
            this.btDelMarked.UseVisualStyleBackColor = true;
            this.btDelMarked.Click += new System.EventHandler(this.btDelMarked_Click);
            // 
            // btDelAll
            // 
            this.btDelAll.Location = new System.Drawing.Point(8, 81);
            this.btDelAll.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btDelAll.Name = "btDelAll";
            this.btDelAll.Size = new System.Drawing.Size(173, 61);
            this.btDelAll.TabIndex = 2;
            this.btDelAll.Text = "Удалить все объекты";
            this.btDelAll.UseVisualStyleBackColor = true;
            this.btDelAll.Click += new System.EventHandler(this.btDelAll_Click);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(5, 152);
            this.labelNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(91, 13);
            this.labelNumber.TabIndex = 3;
            this.labelNumber.Text = "кол-во объектов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 508);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.btDelAll);
            this.Controls.Add(this.btDelMarked);
            this.Controls.Add(this.painBox);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel painBox;
        private System.Windows.Forms.ContextMenuStrip painter;
        private System.Windows.Forms.Button btDelMarked;
        private System.Windows.Forms.Button btDelAll;
        private System.Windows.Forms.Label labelNumber;
    }
}

