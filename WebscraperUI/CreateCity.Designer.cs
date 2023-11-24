namespace WebscraperUI
{
    partial class CreateCity
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
            textBoxCityName = new TextBox();
            textBoxURL = new TextBox();
            TextboxId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            CreateCityLabelHeader = new Label();
            CreateCityButton = new Button();
            SuspendLayout();
            // 
            // textBoxCityName
            // 
            textBoxCityName.Location = new Point(255, 210);
            textBoxCityName.Name = "textBoxCityName";
            textBoxCityName.Size = new Size(297, 23);
            textBoxCityName.TabIndex = 0;
            // 
            // textBoxURL
            // 
            textBoxURL.Location = new Point(255, 250);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(297, 23);
            textBoxURL.TabIndex = 1;
            // 
            // TextboxId
            // 
            TextboxId.Location = new Point(255, 172);
            TextboxId.Name = "TextboxId";
            TextboxId.Size = new Size(297, 23);
            TextboxId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 172);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 4;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 210);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 5;
            label2.Text = "Byens navn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 250);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 6;
            label3.Text = "Url";
            // 
            // CreateCityLabelHeader
            // 
            CreateCityLabelHeader.AutoSize = true;
            CreateCityLabelHeader.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            CreateCityLabelHeader.Location = new Point(305, 90);
            CreateCityLabelHeader.Name = "CreateCityLabelHeader";
            CreateCityLabelHeader.Size = new Size(179, 54);
            CreateCityLabelHeader.TabIndex = 7;
            CreateCityLabelHeader.Text = "Opret By";
            // 
            // CreateCityButton
            // 
            CreateCityButton.Location = new Point(331, 310);
            CreateCityButton.Name = "CreateCityButton";
            CreateCityButton.Size = new Size(130, 43);
            CreateCityButton.TabIndex = 8;
            CreateCityButton.Text = "button1";
            CreateCityButton.UseVisualStyleBackColor = true;
            CreateCityButton.Click += CreateCityButton_Click;
            // 
            // CreateCity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateCityButton);
            Controls.Add(CreateCityLabelHeader);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TextboxId);
            Controls.Add(textBoxURL);
            Controls.Add(textBoxCityName);
            Name = "CreateCity";
            Text = "CreateCity";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCityName;
        private TextBox textBoxURL;
        private TextBox TextboxId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label CreateCityLabelHeader;
        private Button CreateCityButton;
    }
}