namespace OOP_Laba6_mk1
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.painBox = new System.Windows.Forms.PictureBox();
            this.cbShapeChange = new System.Windows.Forms.ComboBox();
            this.cbColorChange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btRUp = new System.Windows.Forms.Button();
            this.btRDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.painBox)).BeginInit();
            this.SuspendLayout();
            // 
            // painBox
            // 
            this.painBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.painBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.painBox.Location = new System.Drawing.Point(304, 34);
            this.painBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.painBox.Name = "painBox";
            this.painBox.Size = new System.Drawing.Size(875, 753);
            this.painBox.TabIndex = 0;
            this.painBox.TabStop = false;
            this.painBox.Paint += new System.Windows.Forms.PaintEventHandler(this.painBox_Paint);
            this.painBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.painBox_MouseDown);
            // 
            // cbShapeChange
            // 
            this.cbShapeChange.FormattingEnabled = true;
            this.cbShapeChange.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Triangle"});
            this.cbShapeChange.Location = new System.Drawing.Point(14, 12);
            this.cbShapeChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbShapeChange.Name = "cbShapeChange";
            this.cbShapeChange.Size = new System.Drawing.Size(232, 28);
            this.cbShapeChange.TabIndex = 1;
            this.cbShapeChange.Text = "Выбрать фигуру";
            // 
            // cbColorChange
            // 
            this.cbColorChange.FormattingEnabled = true;
            this.cbColorChange.Location = new System.Drawing.Point(15, 275);
            this.cbColorChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbColorChange.Name = "cbColorChange";
            this.cbColorChange.Size = new System.Drawing.Size(231, 28);
            this.cbColorChange.TabIndex = 3;
            this.cbColorChange.Text = "Выбери цвет";
            this.cbColorChange.SelectedIndexChanged += new System.EventHandler(this.cbColorChange_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Работа с выделеными объектами";
            // 
            // btRUp
            // 
            this.btRUp.Location = new System.Drawing.Point(15, 209);
            this.btRUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btRUp.Name = "btRUp";
            this.btRUp.Size = new System.Drawing.Size(97, 29);
            this.btRUp.TabIndex = 5;
            this.btRUp.Text = "Увеличить";
            this.btRUp.UseVisualStyleBackColor = true;
            this.btRUp.Click += new System.EventHandler(this.btRUp_Click);
            // 
            // btRDown
            // 
            this.btRDown.Location = new System.Drawing.Point(133, 209);
            this.btRDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btRDown.Name = "btRDown";
            this.btRDown.Size = new System.Drawing.Size(112, 29);
            this.btRDown.TabIndex = 6;
            this.btRDown.Text = "Уменьшить";
            this.btRDown.UseVisualStyleBackColor = true;
            this.btRDown.Click += new System.EventHandler(this.btRDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 818);
            this.Controls.Add(this.btRDown);
            this.Controls.Add(this.btRUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbColorChange);
            this.Controls.Add(this.cbShapeChange);
            this.Controls.Add(this.painBox);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.painBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox painBox;
        private System.Windows.Forms.ComboBox cbShapeChange;
        private System.Windows.Forms.ComboBox cbColorChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRUp;
        private System.Windows.Forms.Button btRDown;
    }
}

