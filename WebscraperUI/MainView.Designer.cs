﻿namespace WebscraperUI;

partial class MainView
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        splitContainer1 = new SplitContainer();
        Websites_List = new ListBox();
        panel1 = new Panel();
        ButtonCreate = new Button();
        Weather_label = new Label();
        CityInfo = new Label();
        CityLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.IsSplitterFixed = true;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Margin = new Padding(2);
        splitContainer1.MinimumSize = new Size(30, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.AutoScroll = true;
        splitContainer1.Panel1.Controls.Add(Websites_List);
        splitContainer1.Panel1MinSize = 15;
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(panel1);
        splitContainer1.Panel2MinSize = 15;
        splitContainer1.Size = new Size(1179, 461);
        splitContainer1.SplitterDistance = 175;
        splitContainer1.SplitterWidth = 3;
        splitContainer1.TabIndex = 0;
        // 
        // Websites_List
        // 
        Websites_List.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        Websites_List.BackColor = SystemColors.HotTrack;
        Websites_List.FormattingEnabled = true;
        Websites_List.ItemHeight = 30;
        Websites_List.Location = new Point(0, 0);
        Websites_List.Name = "Websites_List";
        Websites_List.Size = new Size(175, 484);
        Websites_List.TabIndex = 0;
        Websites_List.SelectedIndexChanged += ListBox_websites_SelectedIndexChanged;
        // 
        // panel1
        // 
        panel1.BackColor = SystemColors.ActiveCaption;
        panel1.Controls.Add(ButtonCreate);
        panel1.Controls.Add(Weather_label);
        panel1.Controls.Add(CityInfo);
        panel1.Controls.Add(CityLabel);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(1001, 461);
        panel1.TabIndex = 0;
        // 
        // ButtonCreate
        // 
        ButtonCreate.Anchor = AnchorStyles.Bottom;
        ButtonCreate.BackColor = SystemColors.ActiveBorder;
        ButtonCreate.BackgroundImageLayout = ImageLayout.Center;
        ButtonCreate.Location = new Point(406, 420);
        ButtonCreate.Name = "ButtonCreate";
        ButtonCreate.Size = new Size(184, 38);
        ButtonCreate.TabIndex = 4;
        ButtonCreate.Text = "Opret by";
        ButtonCreate.UseVisualStyleBackColor = false;
        ButtonCreate.Click += ButtonCreate_Click;
        // 
        // Weather_label
        // 
        Weather_label.AccessibleName = "";
        Weather_label.Anchor = AnchorStyles.None;
        Weather_label.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        Weather_label.Location = new Point(9, 74);
        Weather_label.Name = "Weather_label";
        Weather_label.Size = new Size(989, 345);
        Weather_label.TabIndex = 3;
        Weather_label.Text = "Vejret ";
        // 
        // CityInfo
        // 
        CityInfo.AccessibleName = "";
        CityInfo.Anchor = AnchorStyles.Top;
        CityInfo.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        CityInfo.Location = new Point(279, 30);
        CityInfo.Name = "CityInfo";
        CityInfo.Size = new Size(469, 44);
        CityInfo.TabIndex = 2;
        // 
        // CityLabel
        // 
        CityLabel.AccessibleName = "";
        CityLabel.Anchor = AnchorStyles.Top;
        CityLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        CityLabel.Location = new Point(6, 30);
        CityLabel.Name = "CityLabel";
        CityLabel.Size = new Size(169, 44);
        CityLabel.TabIndex = 0;
        CityLabel.Text = "By";
        // 
        // MainView
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        BackgroundImageLayout = ImageLayout.Center;
        ClientSize = new Size(1179, 461);
        Controls.Add(splitContainer1);
        Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
        Margin = new Padding(5, 6, 5, 6);
        MaximumSize = new Size(1195, 500);
        MinimumSize = new Size(1195, 500);
        Name = "MainView";
        Text = "WeatherApp";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private ListBox Websites_List;
    private Panel panel1;
    private Label CityLabel;
    private Label CityInfo;
    private Label Weather_label;
    private Button ButtonCreate;
}