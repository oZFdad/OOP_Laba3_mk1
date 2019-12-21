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
            this.btOnOffEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.painBox)).BeginInit();
            this.SuspendLayout();
            // 
            // painBox
            // 
            this.painBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.painBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.painBox.Location = new System.Drawing.Point(267, 2);
            this.painBox.Name = "painBox";
            this.painBox.Size = new System.Drawing.Size(958, 816);
            this.painBox.TabIndex = 0;
            this.painBox.TabStop = false;
            this.painBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.painBox_MouseDown);
            // 
            // cbShapeChange
            // 
            this.cbShapeChange.FormattingEnabled = true;
            this.cbShapeChange.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Triangle"});
            this.cbShapeChange.Location = new System.Drawing.Point(13, 13);
            this.cbShapeChange.Name = "cbShapeChange";
            this.cbShapeChange.Size = new System.Drawing.Size(232, 28);
            this.cbShapeChange.TabIndex = 1;
            this.cbShapeChange.Text = "Выбрать фигуру";
            // 
            // btOnOffEdit
            // 
            this.btOnOffEdit.Location = new System.Drawing.Point(13, 61);
            this.btOnOffEdit.Name = "btOnOffEdit";
            this.btOnOffEdit.Size = new System.Drawing.Size(232, 55);
            this.btOnOffEdit.TabIndex = 2;
            this.btOnOffEdit.Text = "Выключить режим редактирования";
            this.btOnOffEdit.UseVisualStyleBackColor = true;
            this.btOnOffEdit.Click += new System.EventHandler(this.bt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 818);
            this.Controls.Add(this.btOnOffEdit);
            this.Controls.Add(this.cbShapeChange);
            this.Controls.Add(this.painBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.painBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox painBox;
        private System.Windows.Forms.ComboBox cbShapeChange;
        private System.Windows.Forms.Button btOnOffEdit;
    }
}

