﻿partial class ADAM_AutoIO_LtoH_Latch_Form
{
    /// <summary>
    /// 設計工具所需的變數。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清除任何使用中的資源。
    /// </summary>
    /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form 設計工具產生的程式碼

    /// <summary>
    /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
    /// 這個方法的內容。
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.StartBtn = new System.Windows.Forms.Button();
        this.lenTxtbox = new System.Windows.Forms.TextBox();
        this.label14 = new System.Windows.Forms.Label();
        this.chiTxtbox = new System.Windows.Forms.TextBox();
        this.ModcomboBox = new System.Windows.Forms.ComboBox();
        this.label13 = new System.Windows.Forms.Label();
        this.ChcomboBox = new System.Windows.Forms.ComboBox();
        this.label12 = new System.Windows.Forms.Label();
        this.idxTxtbox = new System.Windows.Forms.TextBox();
        this.label11 = new System.Windows.Forms.Label();
        this.typTxtbox = new System.Windows.Forms.TextBox();
        this.label10 = new System.Windows.Forms.Label();
        this.CDipTxtbox = new System.Windows.Forms.TextBox();
        this.label9 = new System.Windows.Forms.Label();
        this.ipTxtbox = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        this.tssLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
        this.labelRes = new System.Windows.Forms.Label();
        this.label16 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.SelAllChkbox = new System.Windows.Forms.CheckBox();
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
        this.groupBox1.SuspendLayout();
        this.statusStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.SuspendLayout();
        // 
        // timer1
        // 
        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.StartBtn);
        this.groupBox1.Controls.Add(this.lenTxtbox);
        this.groupBox1.Controls.Add(this.label14);
        this.groupBox1.Controls.Add(this.chiTxtbox);
        this.groupBox1.Controls.Add(this.ModcomboBox);
        this.groupBox1.Controls.Add(this.label13);
        this.groupBox1.Controls.Add(this.ChcomboBox);
        this.groupBox1.Controls.Add(this.label12);
        this.groupBox1.Controls.Add(this.idxTxtbox);
        this.groupBox1.Controls.Add(this.label11);
        this.groupBox1.Controls.Add(this.typTxtbox);
        this.groupBox1.Controls.Add(this.label10);
        this.groupBox1.Controls.Add(this.CDipTxtbox);
        this.groupBox1.Controls.Add(this.label9);
        this.groupBox1.Controls.Add(this.ipTxtbox);
        this.groupBox1.Controls.Add(this.label8);
        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox1.Location = new System.Drawing.Point(0, 0);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(864, 78);
        this.groupBox1.TabIndex = 1;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "%";
        // 
        // StartBtn
        // 
        this.StartBtn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.StartBtn.Location = new System.Drawing.Point(665, 14);
        this.StartBtn.Name = "StartBtn";
        this.StartBtn.Size = new System.Drawing.Size(103, 58);
        this.StartBtn.TabIndex = 26;
        this.StartBtn.Text = "Run";
        this.StartBtn.UseVisualStyleBackColor = true;
        this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
        // 
        // lenTxtbox
        // 
        this.lenTxtbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.lenTxtbox.Location = new System.Drawing.Point(614, 45);
        this.lenTxtbox.Name = "lenTxtbox";
        this.lenTxtbox.Size = new System.Drawing.Size(45, 27);
        this.lenTxtbox.TabIndex = 25;
        // 
        // label14
        // 
        this.label14.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label14.Location = new System.Drawing.Point(539, 48);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(69, 25);
        this.label14.TabIndex = 24;
        this.label14.Text = " Chs/Len";
        // 
        // chiTxtbox
        // 
        this.chiTxtbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.chiTxtbox.Location = new System.Drawing.Point(362, 15);
        this.chiTxtbox.Name = "chiTxtbox";
        this.chiTxtbox.ReadOnly = true;
        this.chiTxtbox.Size = new System.Drawing.Size(45, 27);
        this.chiTxtbox.TabIndex = 23;
        this.chiTxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // ModcomboBox
        // 
        this.ModcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ModcomboBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.ModcomboBox.FormattingEnabled = true;
        this.ModcomboBox.Location = new System.Drawing.Point(277, 45);
        this.ModcomboBox.Name = "ModcomboBox";
        this.ModcomboBox.Size = new System.Drawing.Size(130, 24);
        this.ModcomboBox.TabIndex = 22;
        // 
        // label13
        // 
        this.label13.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label13.Location = new System.Drawing.Point(207, 48);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(64, 25);
        this.label13.TabIndex = 21;
        this.label13.Text = "Mode";
        // 
        // ChcomboBox
        // 
        this.ChcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ChcomboBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.ChcomboBox.FormattingEnabled = true;
        this.ChcomboBox.Items.AddRange(new object[] {
            "All",
            "0",
            "1",
            "2",
            "3"});
        this.ChcomboBox.Location = new System.Drawing.Point(277, 15);
        this.ChcomboBox.Name = "ChcomboBox";
        this.ChcomboBox.Size = new System.Drawing.Size(79, 24);
        this.ChcomboBox.TabIndex = 20;
        // 
        // label12
        // 
        this.label12.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label12.Location = new System.Drawing.Point(207, 17);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(64, 25);
        this.label12.TabIndex = 19;
        this.label12.Text = "Channel";
        // 
        // idxTxtbox
        // 
        this.idxTxtbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.idxTxtbox.Location = new System.Drawing.Point(488, 45);
        this.idxTxtbox.Name = "idxTxtbox";
        this.idxTxtbox.Size = new System.Drawing.Size(45, 27);
        this.idxTxtbox.TabIndex = 18;
        // 
        // label11
        // 
        this.label11.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label11.Location = new System.Drawing.Point(413, 48);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(69, 25);
        this.label11.TabIndex = 17;
        this.label11.Text = " Slot/Idx";
        // 
        // typTxtbox
        // 
        this.typTxtbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.typTxtbox.Location = new System.Drawing.Point(52, 45);
        this.typTxtbox.Name = "typTxtbox";
        this.typTxtbox.Size = new System.Drawing.Size(149, 27);
        this.typTxtbox.TabIndex = 16;
        // 
        // label10
        // 
        this.label10.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label10.Location = new System.Drawing.Point(9, 48);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(46, 25);
        this.label10.TabIndex = 15;
        this.label10.Text = "Type";
        // 
        // CDipTxtbox
        // 
        this.CDipTxtbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.CDipTxtbox.Location = new System.Drawing.Point(529, 14);
        this.CDipTxtbox.Name = "CDipTxtbox";
        this.CDipTxtbox.Size = new System.Drawing.Size(130, 27);
        this.CDipTxtbox.TabIndex = 14;
        this.CDipTxtbox.Text = "172.18.3.202";
        // 
        // label9
        // 
        this.label9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label9.Location = new System.Drawing.Point(413, 17);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(110, 25);
        this.label9.TabIndex = 13;
        this.label9.Text = "Control Device";
        // 
        // ipTxtbox
        // 
        this.ipTxtbox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.ipTxtbox.Location = new System.Drawing.Point(52, 15);
        this.ipTxtbox.Name = "ipTxtbox";
        this.ipTxtbox.Size = new System.Drawing.Size(149, 27);
        this.ipTxtbox.TabIndex = 12;
        this.ipTxtbox.Text = "172.18.3.188";
        // 
        // label8
        // 
        this.label8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label8.Location = new System.Drawing.Point(9, 18);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(37, 25);
        this.label8.TabIndex = 11;
        this.label8.Text = "IP";
        // 
        // statusStrip1
        // 
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.toolStripStatusLabel1,
            this.tssLabel2});
        this.statusStrip1.Location = new System.Drawing.Point(0, 404);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(864, 22);
        this.statusStrip1.TabIndex = 2;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // tssLabel1
        // 
        this.tssLabel1.Name = "tssLabel1";
        this.tssLabel1.Size = new System.Drawing.Size(13, 17);
        this.tssLabel1.Text = "-";
        // 
        // toolStripStatusLabel1
        // 
        this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
        this.toolStripStatusLabel1.Text = "-";
        // 
        // tssLabel2
        // 
        this.tssLabel2.Name = "tssLabel2";
        this.tssLabel2.Size = new System.Drawing.Size(13, 17);
        this.tssLabel2.Text = "-";
        // 
        // labelRes
        // 
        this.labelRes.Font = new System.Drawing.Font("新細明體", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.labelRes.Location = new System.Drawing.Point(120, 366);
        this.labelRes.Name = "labelRes";
        this.labelRes.Size = new System.Drawing.Size(90, 25);
        this.labelRes.TabIndex = 32;
        this.labelRes.Text = "NA";
        this.labelRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label16
        // 
        this.label16.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label16.Location = new System.Drawing.Point(31, 119);
        this.label16.Name = "label16";
        this.label16.Size = new System.Drawing.Size(130, 24);
        this.label16.TabIndex = 31;
        this.label16.Text = "DI-L to H latch";
        // 
        // label7
        // 
        this.label7.Font = new System.Drawing.Font("新細明體", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                        | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label7.Location = new System.Drawing.Point(9, 370);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(105, 25);
        this.label7.TabIndex = 29;
        this.label7.Text = "Test Result :";
        // 
        // label6
        // 
        this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label6.Location = new System.Drawing.Point(438, 83);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(60, 25);
        this.label6.TabIndex = 28;
        this.label6.Text = "Result";
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label5.Location = new System.Drawing.Point(372, 83);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(60, 25);
        this.label5.TabIndex = 27;
        this.label5.Text = "Modbus";
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label4.Location = new System.Drawing.Point(306, 83);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(60, 25);
        this.label4.TabIndex = 26;
        this.label4.Text = "APAX";
        // 
        // label3
        // 
        this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label3.Location = new System.Drawing.Point(240, 83);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(60, 25);
        this.label3.TabIndex = 25;
        this.label3.Text = "Get";
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label2.Location = new System.Drawing.Point(174, 83);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(60, 25);
        this.label2.TabIndex = 24;
        this.label2.Text = "Set";
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        this.label1.Location = new System.Drawing.Point(31, 83);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(137, 25);
        this.label1.TabIndex = 23;
        this.label1.Text = "Description";
        // 
        // SelAllChkbox
        // 
        this.SelAllChkbox.AutoSize = true;
        this.SelAllChkbox.Location = new System.Drawing.Point(10, 86);
        this.SelAllChkbox.Name = "SelAllChkbox";
        this.SelAllChkbox.Size = new System.Drawing.Size(15, 14);
        this.SelAllChkbox.TabIndex = 22;
        this.SelAllChkbox.UseVisualStyleBackColor = true;
        // 
        // dataGridView1
        // 
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
        this.dataGridView1.Location = new System.Drawing.Point(508, 78);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.RowTemplate.Height = 24;
        this.dataGridView1.Size = new System.Drawing.Size(356, 326);
        this.dataGridView1.TabIndex = 21;
        // 
        // ADAM_AutoIO_LtoH_Latch_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(864, 426);
        this.Controls.Add(this.labelRes);
        this.Controls.Add(this.label16);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.SelAllChkbox);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.groupBox1);
        this.Name = "ADAM_AutoIO_LtoH_Latch_Form";
        this.Text = "ADAM_AutoIO_LtoH_Latch";
        this.Load += new System.EventHandler(this.ADAM_AutoIO_LtoH_Latch_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button StartBtn;
    private System.Windows.Forms.TextBox lenTxtbox;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox chiTxtbox;
    private System.Windows.Forms.ComboBox ModcomboBox;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.ComboBox ChcomboBox;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox idxTxtbox;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox typTxtbox;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox CDipTxtbox;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox ipTxtbox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Label labelRes;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox SelAllChkbox;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.ToolStripStatusLabel tssLabel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel tssLabel2;
}

