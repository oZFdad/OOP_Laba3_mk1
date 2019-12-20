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
            this.btPaint = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
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
            this.painBox.Location = new System.Drawing.Point(296, 1);
            this.painBox.Name = "painBox";
            this.painBox.Size = new System.Drawing.Size(971, 781);
            this.painBox.TabIndex = 0;
            this.painBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.painBox_MouseDown);
            // 
            // painter
            // 
            this.painter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.painter.Name = "painter";
            this.painter.Size = new System.Drawing.Size(61, 4);
            // 
            // btPaint
            // 
            this.btPaint.Location = new System.Drawing.Point(12, 12);
            this.btPaint.Name = "btPaint";
            this.btPaint.Size = new System.Drawing.Size(260, 87);
            this.btPaint.TabIndex = 1;
            this.btPaint.Text = "Отрисовать объекты";
            this.btPaint.UseVisualStyleBackColor = true;
            this.btPaint.Click += new System.EventHandler(this.btPaint_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(12, 125);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(260, 94);
            this.btDelete.TabIndex = 2;
            this.btDelete.Text = "Удалить объекты";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(8, 234);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(136, 20);
            this.labelNumber.TabIndex = 3;
            this.labelNumber.Text = "кол-во объектов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 781);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btPaint);
            this.Controls.Add(this.painBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel painBox;
        private System.Windows.Forms.ContextMenuStrip painter;
        private System.Windows.Forms.Button btPaint;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label labelNumber;
    }
}

