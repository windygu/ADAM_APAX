﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Model;
using Service;
using iATester;

public partial class ADAM_AutoIO_AI_AlarmMode_Form : Form, iATester.iCom
{
    ADAM6KReqService ADAM6KReqService;
    ModbusTCPService APAX5070Service;
    DeviceModel Device;
    DeviceModel APAX5070;
    IOModel DevIO = new IOModel();
    ADAM_IO_Model Ref_IO_Mod;
    //
    CheckBox[] chkbox;
    TextBox[] setTxtbox;
    TextBox[] getTxtbox;
    TextBox[] apaxTxtbox;
    TextBox[] modbTxtbox;
    Label[] resLabel;
    private delegate void DataGridViewCtrlAddDataRow(DataGridViewRow i_Row);
    private DataGridViewCtrlAddDataRow m_DataGridViewCtrlAddDataRow;
    internal const int Max_Rows_Val = 65535;
    int num_item = 3; int ai_id_offset = 40;
    //
    bool ConnReadyFlg = false, FinishFlg = false;
    string[] RangeList;
    int mainTaskStp = 0, FailCnt = 0;
    int RngMod = 323;
    int VModNum = 10, AModNum = 3;//Voltage/Current Mode number
    //
    //iATester
    //Send Log data to iAtester
    public event EventHandler<LogEventArgs> eLog = delegate { };
    //Send test result to iAtester
    public event EventHandler<ResultEventArgs> eResult = delegate { };
    //Send execution status to iAtester
    public event EventHandler<StatusEventArgs> eStatus = delegate { };
    //
    public string ProcessStep
    {
        get { return ""; }
        set
        {
            tssLabel2.Text = value;
        }
    }
    //========================================================//
    #region Observable Properties
    int _reftypIdx = 0;
    public int RefTypSelIdx
    {
        get { return _reftypIdx; }
        set
        {
            _reftypIdx = value;
            //RefreshChTypeItem();
            //RaisePropertyChanged("RefTypSelIdx");
        }

    }
    int _refchtypIdx = 0;
    public int ChSelIdx
    {
        get { return _refchtypIdx; }
        set
        {
            _refchtypIdx = value;
            //RaisePropertyChanged("ChSelIdx");
        }

    }
    int _refvatypIdx = 0;
    public int VASelIdx
    {
        get { return _refvatypIdx; }
        set
        {
            _refvatypIdx = value;
            //RaisePropertyChanged("VASelIdx");
        }

    }
    int _refDevtypIdx = 0;
    public int CtrlDevSelIdx
    {
        get { return _refDevtypIdx; }
        set
        {
            _refDevtypIdx = value;
            //RaisePropertyChanged("CtrlDevSelIdx");
        }

    }
    int _apaxAOslot_idx = 1;//for modbus/apax5580
    public int OutAO_Slot_Idx
    {
        get { return _apaxAOslot_idx; }
        set
        {
            _apaxAOslot_idx = value;
            idxTxtbox.Text = _apaxAOslot_idx.ToString();
            //RaisePropertyChanged("OutAO_Slot_Idx");
        }

    }
    int _ref_ai_num = 0;
    public string OutAO_Ch_Len
    {
        get
        { return "0 ~ " + (_ref_ai_num - 1).ToString(); }
        set
        {
            //RaisePropertyChanged("OutAO_Ch_Len");
        }
    }
    string _runStr = "Run";
    public string RunBtnStr
    {
        get { return _runStr; }
        set
        {
            _runStr = value;
            //RaisePropertyChanged("RunBtnStr");
        }

    }
    string _testRes = "N/A";
    public string TestResult
    {
        get { return _testRes; }
        set
        {
            _testRes = value;
            labelRes.Text = _testRes;
            //RaisePropertyChanged("TestResult");
        }

    }
    //
    int[] setData = new int[10];
    public int SetData01
    {
        get { return setData[1]; }
        set
        {
            setTxtbox[0].Text = value.ToString();
            setData[1] = value;
        }
    }
    public int SetData02
    {
        get { return setData[2]; }
        set
        {
            setTxtbox[1].Text = value.ToString();
            setData[2] = value;
        }
    }
    public int SetData03
    {
        get { return setData[3]; }
        set
        {
            setTxtbox[2].Text = value.ToString();
            setData[3] = value;
        }
    }

    //
    string[] resStr = new string[10];
    public string ResStr01
    {
        get { return resStr[1]; }
        set
        {
            resLabel[0].Text = value.ToString();
            resStr[1] = value;
        }
    }
    public string ResStr02
    {
        get { return resStr[2]; }
        set
        {
            resLabel[1].Text = value.ToString();
            resStr[2] = value;
        }
    }
    public string ResStr03
    {
        get { return resStr[3]; }
        set
        {
            resLabel[2].Text = value.ToString();
            resStr[3] = value;
        }
    }
    
    //
    int[] outData = new int[10];
    public int OutData01
    {
        get { return outData[1]; }
        set
        {
            apaxTxtbox[0].Text = value.ToString();
            outData[1] = value;
        }
    }

    public int OutData02
    {
        get { return outData[2]; }
        set
        {
            apaxTxtbox[1].Text = value.ToString();
            outData[2] = value;
        }
    }

    public int OutData03
    {
        get { return outData[3]; }
        set
        {
            apaxTxtbox[2].Text = value.ToString();
            outData[3] = value;
        }
    }

    
    //20151106 for modbus
    string[] mbData = new string[10];
    public string MBData01
    {
        get { return mbData[0]; }
        set
        {
            modbTxtbox[0].Text = value.ToString();
            mbData[0] = value;
        }
    }
    public string MBData02
    {
        get { return mbData[1]; }
        set
        {
            modbTxtbox[1].Text = value.ToString();
            mbData[1] = value;
        }
    }
    public string MBData03
    {
        get { return mbData[2]; }
        set
        {
            modbTxtbox[2].Text = value.ToString();
            mbData[2] = value;
        }
    }

    //
    bool[] stpchk = new bool[10];
    public bool StpChkIdx0
    {
        get { return stpchk[0]; }
        set
        {
            stpchk[0] = value;
            if (value)
            {
                StpChkIdx1 = StpChkIdx2 = StpChkIdx3 = StpChkIdx4 = StpChkIdx5
                    = StpChkIdx6 = StpChkIdx7 = StpChkIdx8 = StpChkIdx9 = true;
            }
            else
            {
                StpChkIdx1 = StpChkIdx2 = StpChkIdx3 = StpChkIdx4 = StpChkIdx5
                    = StpChkIdx6 = StpChkIdx7 = StpChkIdx8 = StpChkIdx9 = false;
            }
        }
    }
    public bool StpChkIdx1
    {
        get { return stpchk[1]; }
        set { stpchk[1] = value; }
    }
    public bool StpChkIdx2
    {
        get { return stpchk[2]; }
        set { stpchk[2] = value; }
    }
    public bool StpChkIdx3
    {
        get { return stpchk[3]; }
        set { stpchk[3] = value; }
    }
    public bool StpChkIdx4
    {
        get { return stpchk[4]; }
        set { stpchk[4] = value; }
    }
    public bool StpChkIdx5
    {
        get { return stpchk[5]; }
        set { stpchk[5] = value; }
    }
    public bool StpChkIdx6
    {
        get { return stpchk[6]; }
        set { stpchk[6] = value; }
    }
    public bool StpChkIdx7
    {
        get { return stpchk[7]; }
        set { stpchk[7] = value; }
    }
    public bool StpChkIdx8
    {
        get { return stpchk[8]; }
        set { stpchk[8] = value; }
    }
    public bool StpChkIdx9
    {
        get { return stpchk[9]; }
        set { stpchk[9] = value; }
    }
    #endregion
    /// <summary>
    /// main
    /// </summary>
    public ADAM_AutoIO_AI_AlarmMode_Form()
    {
        InitializeComponent();
    }

    private void ADAM_AutoIO_AI_RangeCode_Load(object sender, EventArgs e)
    {
        #region -- Item --
        chkbox = new CheckBox[num_item];
        setTxtbox = new TextBox[num_item];
        getTxtbox = new TextBox[num_item];
        apaxTxtbox = new TextBox[num_item];
        modbTxtbox = new TextBox[num_item];
        resLabel = new Label[num_item];
        chkbox.Initialize(); setTxtbox.Initialize();
        getTxtbox.Initialize(); apaxTxtbox.Initialize();
        modbTxtbox.Initialize(); resLabel.Initialize();
        var text_style = new FontFamily("Times New Roman");
        for (int i = 0; i < num_item; i++)
        {
            chkbox[i] = new CheckBox();
            chkbox[i].Name = "StpChkIdx" + (i + 1).ToString();
            chkbox[i].Location = new Point(10, 83 + 35 * (i + 1));
            chkbox[i].Text = "";
            chkbox[i].Parent = this;
            chkbox[i].CheckedChanged += new EventHandler(SubChkBoxChanged);

            setTxtbox[i] = new TextBox();
            setTxtbox[i].Size = new Size(60, 25);
            setTxtbox[i].Location = new Point(174, 83 + 35 * (i + 1));
            setTxtbox[i].Font = new Font(text_style, 12, FontStyle.Regular);
            setTxtbox[i].TextAlign = HorizontalAlignment.Center;
            setTxtbox[i].Parent = this;

            getTxtbox[i] = new TextBox();
            getTxtbox[i].Size = new Size(60, 25);
            getTxtbox[i].Location = new Point(240, 83 + 35 * (i + 1));
            getTxtbox[i].Font = new Font(text_style, 12, FontStyle.Regular);
            getTxtbox[i].TextAlign = HorizontalAlignment.Center;
            getTxtbox[i].Parent = this;

            apaxTxtbox[i] = new TextBox();
            apaxTxtbox[i].Size = new Size(60, 25);
            apaxTxtbox[i].Location = new Point(306, 83 + 35 * (i + 1));
            apaxTxtbox[i].Font = new Font(text_style, 12, FontStyle.Regular);
            apaxTxtbox[i].TextAlign = HorizontalAlignment.Center;
            apaxTxtbox[i].Parent = this;

            modbTxtbox[i] = new TextBox();
            modbTxtbox[i].Size = new Size(60, 25);
            modbTxtbox[i].Location = new Point(372, 83 + 35 * (i + 1));
            modbTxtbox[i].Font = new Font(text_style, 12, FontStyle.Regular);
            modbTxtbox[i].TextAlign = HorizontalAlignment.Center;
            modbTxtbox[i].Parent = this;

            resLabel[i] = new Label();
            resLabel[i].Size = new Size(60, 25);
            resLabel[i].Location = new Point(438, 83 + 35 * (i + 1));
            resLabel[i].Font = new Font(text_style, 12, FontStyle.Regular);
            resLabel[i].Text = "";
            resLabel[i].Parent = this;
        }
        for (int i = 0; i < num_item; i++)
        {
            chkbox[i].Checked = true;
        }

        //
        dataGridView1.ColumnHeadersVisible = true;
        DataGridViewTextBoxColumn newCol = new DataGridViewTextBoxColumn(); // add a column to the grid
        newCol.HeaderText = "Time";
        newCol.Name = "clmTs";
        newCol.Visible = true;
        newCol.Width = 20;
        dataGridView1.Columns.Add(newCol);
        //
        newCol = new DataGridViewTextBoxColumn();
        newCol.HeaderText = "Ch";
        newCol.Name = "clmStp";
        newCol.Visible = true;
        newCol.Width = 30;
        dataGridView1.Columns.Add(newCol);
        //
        newCol = new DataGridViewTextBoxColumn();
        newCol.HeaderText = "Step";
        newCol.Name = "clmIns";
        newCol.Visible = true;
        newCol.Width = 100;
        dataGridView1.Columns.Add(newCol);
        //
        newCol = new DataGridViewTextBoxColumn();
        newCol.HeaderText = "Result";
        newCol.Name = "clmDes";
        newCol.Visible = true;
        newCol.Width = 50;
        dataGridView1.Columns.Add(newCol);
        //
        newCol = new DataGridViewTextBoxColumn();
        newCol.HeaderText = "Rowdata";
        newCol.Name = "clmRes";
        newCol.Visible = true;
        newCol.Width = 200;
        dataGridView1.Columns.Add(newCol);

        for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
        {
            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
        }
        dataGridView1.Rows.Clear();
        try
        {
            m_DataGridViewCtrlAddDataRow = new DataGridViewCtrlAddDataRow(DataGridViewCtrlAddNewRow);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        #endregion

        ADAM6KReqService = new ADAM6KReqService();
        APAX5070Service = new ModbusTCPService();
        //debug
        ADAMConnection();
    }
    public void StartTest()//iATester
    {
        //if (WISEConnection())
        //{
        //    eStatus(this, new StatusEventArgs(iStatus.Running));
        //    while (timer.Enabled)
        //    {
        //        Application.DoEvents();
        //        label23.Text = "iA running....";
        //    }

        //    if (FailCnt > 0 || !FinishFlg)
        //        eResult(this, new ResultEventArgs(iResult.Fail));
        //    else
        //        eResult(this, new ResultEventArgs(iResult.Pass));
        //    //20161109 add
        //    if (!FinishFlg)
        //        eLog(this, new LogEventArgs("WISE_AutoIO_AI_FunTest.exe", "Process is not finish."));
        //}
        //else
        //    eResult(this, new ResultEventArgs(iResult.Fail));
        ////
        //eStatus(this, new StatusEventArgs(iStatus.Completion));
        //Application.DoEvents(); label23.Text = "iA finished....";
    }
    private void DataGridViewCtrlAddNewRow(DataGridViewRow i_Row)
    {
        if (this.dataGridView1.InvokeRequired)
        {
            this.dataGridView1.Invoke(new DataGridViewCtrlAddDataRow(DataGridViewCtrlAddNewRow), new object[] { i_Row });
            return;
        }

        this.dataGridView1.Rows.Insert(0, i_Row);
        if (dataGridView1.Rows.Count > Max_Rows_Val)
        {
            dataGridView1.Rows.RemoveAt((dataGridView1.Rows.Count - 1));
        }
        this.dataGridView1.Update();
    }
    void ProcessView(ListViewData _obj)
    {
        DataGridViewRow dgvRow;
        DataGridViewCell dgvCell;
        dgvRow = new DataGridViewRow();
        //dgvRow.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Regular);
        if (_obj.Result == "Failed") dgvRow.DefaultCellStyle.ForeColor = Color.Red;
        dgvCell = new DataGridViewTextBoxCell(); //Column Time
        var dataTimeInfo = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
        dgvCell.Value = dataTimeInfo;
        dgvRow.Cells.Add(dgvCell);
        //
        dgvCell = new DataGridViewTextBoxCell();
        dgvCell.Value = _obj.Ch;
        dgvRow.Cells.Add(dgvCell);
        //
        dgvCell = new DataGridViewTextBoxCell();
        dgvCell.Value = _obj.Step;
        dgvRow.Cells.Add(dgvCell);
        //
        dgvCell = new DataGridViewTextBoxCell();
        dgvCell.Value = _obj.Result;
        dgvRow.Cells.Add(dgvCell);
        //
        dgvCell = new DataGridViewTextBoxCell();
        dgvCell.Value = _obj.RowData;
        dgvRow.Cells.Add(dgvCell);

        m_DataGridViewCtrlAddDataRow(dgvRow);
    }
    private void StartBtn_Click(object sender, EventArgs e)
    {
        if (!timer1.Enabled)
        {
            //SetParaToFile();
            ADAMConnection();
        }
        else
        {
            timer1.Stop(); StartBtn.Text = "Run";
        }
    }
    private void SubChkBoxChanged(object sender, EventArgs e)
    {
        var obj = (CheckBox)sender;
        for (int i = 1; i < num_item; i++)
        {
            string _name = "StpChkIdx" + i.ToString();
            if (obj.Name == _name)
                stpchk[i] = obj.Checked;
        }
    }
    private void SelAllChkbox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (SelAllChkbox.Checked)
            {
                for (int i = 0; i < num_item; i++) chkbox[i].Checked = true;
            }
            else
            {
                for (int i = 0; i < num_item; i++) chkbox[i].Checked = false;
            }
        }
        catch
        { }
    }
    private void ChcomboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChSelIdx = ChcomboBox.SelectedIndex;
    }
    private bool ADAMConnection()
    {
        ConnReadyFlg = false;
        if (ipTxtbox.Text == "") return false;

        Device = new DeviceModel()
        { IPAddress = ipTxtbox.Text };
        if (ADAM6KReqService.OpenCOM(Device.IPAddress))
        {
            ConnReadyFlg = true;
            Device = ADAM6KReqService.GetDevice();
            ADAM6KReqService.GetDevRng(Device.ModuleType);
            typTxtbox.Text = Device.ModuleType;
            tssLabel1.Text = "";//error msg
        }
        else
        { tssLabel1.Text = "ADAM Disconnected...."; }
        //
        APAX5070 = new DeviceModel() { IPAddress = CDipTxtbox.Text };
        if (APAX5070.IPAddress != "")
        {
            if (!APAX5070Service.ModbusConnection(APAX5070))
                tssLabel1.Text += "APAX-5070 Disconnected....";
        }
        //
        System.Threading.Thread.Sleep(1000);
        if (!timer1.Enabled && ConnReadyFlg)
        {
            if (ProcessInitial())
            {
                timer1.Start(); StartBtn.Text = "Starting";
            }
            else ProcessStep += "Setting Error!";
        }
        else
        {
            timer1.Stop(); StartBtn.Text = "Run";
        }
        return ConnReadyFlg;
    }
    private bool ProcessInitial()
    {
        FailCnt = 0; FinishFlg = false;
        if (Device.ModuleType == "Adam6017")
        {
            Ref_IO_Mod = new ADAM_IO_Model(Device.ModuleType);
            OutAO_Slot_Idx = 1;
        }
        else
        {
            eLog(this, new LogEventArgs("ADAM_AutoIO_AI_RangeCode.exe", "Module is not support."));
            ProcessStep = "Module is not support.";
            return false;
        }

        _ref_ai_num = Ref_IO_Mod.AI_num;
        lenTxtbox.Text = OutAO_Ch_Len = _ref_ai_num.ToString();
        //var rng = RangeLoad();//get AI range code
        //
        if (ChSelIdx > 0)
            Ref_IO_Mod.Ch = ChSelIdx - 1;
        else Ref_IO_Mod.Ch = 0;
        //
        VerInit();
        return true;
    }
    private int GetMbAIRng_RegVal(int id)
    {
        int res = 0;
        try
        {   //Get modbus reg value.
            //var par = CustomController.ReadModbusRegs(DevInfo.DevModbus.AICd, DevInfo.DevModbus.LenAICd);
            var par = (int[])ADAM6KReqService.GetRngCodeFromModbus();//ModbusTCPService.ReadHoldingRegs(Device.MbRegs.AICd, Device.MbRegs.lenAICd);
            for (int i = 0; i < par.Length; i++)
            {
                if (i == id - ai_id_offset)
                {
                    ProcessView(new ListViewData()
                    {
                        Step = "GetMbAIRng_RegVal",
                        RowData = "Modbus = 4x" + (201 + i).ToString("000")
                            + " ; Val: " + par[i].ToString()
                    });
                    return par[i];
                }
            }
        }
        catch { }
        return res;
    }
    private int GetMbAI_RegVal(int id)
    {
        int res = 0;
        try
        {   //Get modbus reg value.
            //var par = CustomController.ReadModbusRegs(DevInfo.DevModbus.AI, DevInfo.DevModbus.LenAI);
            var par = (int[])ADAM6KReqService.GetValueFromModbus();//var par = ModbusTCPService.ReadHoldingRegs(st_idx, Device.AiTotal);
            for (int i = 0; i < par.Length; i++)
            {
                if (i == id - ai_id_offset)
                {
                    ProcessView(new ListViewData()
                    {
                        Step = "GetMbAI_RegVal",
                        RowData = "Modbus = 4x" + (1 + i).ToString("000")
                            + " ; Val: " + par[i].ToString()
                    });
                    return par[i];
                }
            }
        }
        catch { }
        return res;
    }

    //=============== Process ===================//
    private void timer1_Tick(object sender, EventArgs e)
    {
        switch (mainTaskStp)
        {
            case (int)ADAM_AT_AIRng_Task.wCh_Init:
                ProcessView(new ListViewData() { Ch = Ref_IO_Mod.Ch, Step = "Initialized", Result = "" });
                GetDeviceItems(ai_id_offset + Ref_IO_Mod.Ch);
                ResetDefault();
                mainTaskStp++;
                break;
            //case (int)ADAM_AT_AIRng_Task.wCh_Disable:
            //    //開始做disable功能

            //    mainTaskStp++;
            //    break;
            //case (int)ADAM_AT_AIRng_Task.wCh_Disable_res:
            //    //列出上個步驟的結果

            //    mainTaskStp++;
            //    break;
            //case (int)ADAM_AT_AIRng_Task.wCh_Enable:
            //    //開始做Enable功能

            //    mainTaskStp++;
            //    break;
            //case (int)ADAM_AT_AIRng_Task.wCh_Enable_res:
            //    //列出上個步驟的結果

            //    mainTaskStp++;
            //    break;
            case (int)ADAM_AT_AIRng_Task.wCh_Rng:
                if (StpChkIdx1)
                {
                    ProcessStep = ADAM_AT_AIRng_Task.wCh_Rng.ToString();
                    ChannelRangeTest(ai_id_offset + Ref_IO_Mod.Ch);//進入副程式
                }
                else mainTaskStp++;
                break;
            case (int)ADAM_AT_AIRng_Task.wCh_Rng_res:
                //列出上個步驟的結果
                ProcessView(new ListViewData() { Ch = Ref_IO_Mod.Ch, Step = ProcessStep, Result = ResStr01 });
                mainTaskStp++;
                break;
            


            case (int)ADAM_AT_AIRng_Task.wCh_ChangRng:
                ProcessStep = ADAM_AT_AIRng_Task.wCh_ChangRng.ToString();
                ChangeRng();//執行下一個range code
                break;



                //
            case (int)ADAM_AT_AIRng_Task.wFinished:
                //全部range code做完後執行下一個channel的判斷
                ProcessStep = ADAM_AT_AIRng_Task.wFinished.ToString();
                ProcessView(new ListViewData() { Ch = Ref_IO_Mod.Ch, Step = "Finished", Result = "" });
                if (ChSelIdx == 0 && Ref_IO_Mod.Ch < (Device.AiTotal - 1))
                {
                    ProcessView(new ListViewData() { Ch = Ref_IO_Mod.Ch, Step = "Change next channel", Result = "" });
                    Ref_IO_Mod.Ch++; GetDeviceItems(ai_id_offset + Ref_IO_Mod.Ch); VerInit();
                }
                else
                {
                    //全部channel做完,結束流程
                    timer1.Stop(); RunBtnStr = "Run";
                    FinishFlg = true;
                    if (FailCnt > 0) TestResult = "Fail";
                    else TestResult = "Pass";
                }
                break;
            default:

                mainTaskStp++;
                break;
        }
    }
    void ResetDefault()
    {

    }
    void VerInit()
    {
        mainTaskStp = 0;
        /*ResultIni();*/ resCnt = 0;
        temp_rng = new int[20]; temp_rng.Initialize();
    }
    //
    IOModel IOitem = new IOModel();
    int resCnt = 0;
    int RngChgStp = 0, Ref_rng = 0;
    int[] temp_rng; //ai range change used
    private void ChannelRangeTest(int id)
    {
        //20151112 change program to follow step.
        if (RngChgStp >= 99)
        {
            ResStr01 = "Failed"; mainTaskStp++;
            FailCnt++;
        }
        else if (RngChgStp > 5 && RngChgStp < 99)
        {
            ResStr01 = "Passed"; mainTaskStp++;
        }
        else if (RngChgStp == 5)
        {
            //Check modbus AI value would correspond with reading.
            //再判斷modbus的address數值是否為最大數值
            int mb_AIval = GetMbAI_RegVal(id);
            GetDeviceItems(id);//get current value
                                        //
            ProcessView(new ListViewData()
            {
                Step = RngChgStp.ToString(),
                RowData = "mb_AIval = " + mb_AIval.ToString() +
                          ", IOitem.Val = " + IOitem.Val.ToString()
            });
            //
            if (mb_AIval == IOitem.Val
                 || mb_AIval > (IOitem.Val - 100))
                RngChgStp++;
            else RngChgStp = 99;
        }
        else if (RngChgStp == 4)
        {
            //Check input value would correspond with reading.
            //判斷輸入的數值是否為最大數值
            if (DoValDetect(id, Ref_rng))
                RngChgStp++;
            else RngChgStp = 99;
        }
        else if (RngChgStp == 3)
        {
            //Check modbus rng code would correspond with reading.
            //再判斷modbus的address數值是否切換成設定的range code
            int mb_rng = GetMbAIRng_RegVal(id);
            MBData01 = mb_rng.ToString();

            if (mb_rng == IOitem.Rng) RngChgStp++;
            else RngChgStp = 99;
        }
        else if (RngChgStp == 2)
        {
            //Detect Rng code would correspond with setting.
            //先判斷range code是否切換成設定的range code
            if (DoRngDetect(id, Ref_rng))
                RngChgStp++;
            else RngChgStp = 99;

            temp_rng[resCnt] = Ref_rng;
            resCnt++;
        }
        else if (RngChgStp == 1)//start to change the next range code.
        {
            //偵測range code是否為設定值, 若否就切換成設定的range code
            GetDeviceItems(id);
            foreach (var ref_rng in Ref_IO_Mod.AIRng)
            {
                bool flg = false;

                foreach (var t_rng in temp_rng)
                {
                    if (ref_rng == t_rng)
                    {
                        flg = true; break;
                    }
                }

                if (flg) continue;

                //還沒切換過的Rng做切換
                if (DoChangeRange(ref_rng))
                {
                    RngMod = ref_rng;
                    //需要控制PAC端AO輸出
                    //控制APAX5070的AO輸出
                    OutData01 = OutputAO(IntToRowData(ref_rng, Ref_IO_Mod.APAX_AO_HiVal));
                    //Thread.Sleep(DelayT);
                    Ref_rng = ref_rng;
                }
                break;
            }

            RngChgStp++;
        }
        else if (RngChgStp == 0)//initial
        {
            ResStr01 
                = MBData01 = "";
            RngChgStp = 0;
            Ref_rng = 0;
            RngChgStp++;
        }
    }


    //============================================//
    bool RangeLoad()
    {
        System.Collections.ArrayList ListOfItems = new System.Collections.ArrayList();
        int count = 0;
        var Range = ADAM6KReqService.GetDevRng(Device.ModuleType);
        
        string[] tmp = new string[20];
        for (int i = 0; i < Range.Length; i++)
        {
            if (Range[i].ToString() != "\n")
                tmp[count] += Range[i];
            else
                count++;
        }
        //RangeList = new string[20];
        foreach (var item in tmp)
        {
            if (item != null)
                ListOfItems.Add(item);
        }
        RangeList = new string[ListOfItems.Count];
        ModcomboBox.Items.Clear();
        for (int i = 0; i < ListOfItems.Count; i++)
        {
            string _stItem = (string)ListOfItems[i];
            RangeList[i] = _stItem;
            ModcomboBox.Items.Add(_stItem);
        }
        ModcomboBox.SelectedIndex = 0;
        return true;
    }
    double AIRead()//unit: V
    {
        IOModel DevIO = new IOModel();
        foreach (var item in ADAM6KReqService.GetListOfIOItems(""))
        {
            var readInfo = (IOModel)item;
            if (readInfo.Id.Equals(ai_id_offset + Ref_IO_Mod.Ch))
            {
                DevIO = readInfo;
                break;
            }
        }
        double rData = 0.0;
        //判斷輸出的數值單位
        if (//Uni-polar
            DevIO.Rng == (int)ValueRange.mV_0To150 || DevIO.Rng == (int)ValueRange.mV_0To500
            //Bi-polar
            || DevIO.Rng == (int)ValueRange.mV_Neg15To15 || DevIO.Rng == (int)ValueRange.mV_Neg50To50
            || DevIO.Rng == (int)ValueRange.mV_Neg100To100 || DevIO.Rng == (int)ValueRange.mV_Neg150To150
            || DevIO.Rng == (int)ValueRange.mV_Neg500To500)
            rData = (double)DevIO.Val / 1000000;
        else if (DevIO.Rng == (int)ValueRange.Jtype_0To760C || DevIO.Rng == (int)ValueRange.Ktype_0To1370C
            || DevIO.Rng == (int)ValueRange.Ttype_Neg100To400C || DevIO.Rng == (int)ValueRange.Etype_0To1000C
            || DevIO.Rng == (int)ValueRange.Rtype_500To1750C || DevIO.Rng == (int)ValueRange.Stype_500To1750C
            || DevIO.Rng == (int)ValueRange.Btype_500To1800C)
            rData = (double)DevIO.Val;
        else rData = (double)DevIO.Val / 1000;

        return rData;
    }
    void GetDeviceItems(int id)
    {
        //var obj = ADAM6KReqService.GetListOfIOItems("");
        bool flg = false;
        List<IOModel> IO_Data = (List<IOModel>)ADAM6KReqService.GetListOfIOItems("");
        if (id >= ai_id_offset)
        {
            foreach (var item in IO_Data)
            {
                if (item.Id == id && item.Ch == id - ai_id_offset)
                {
                    IOitem = new IOModel()
                    {
                        Id = item.Id,
                        Ch = item.Ch,
                        Tag = item.Tag,
                        Val = item.Val,
                        //AI
                        En = item.En,
                        Rng = item.Rng,
                        Evt = item.Evt,
                        LoA = item.LoA,
                        HiA = item.HiA,
                        Eg = item.Eg,
                        EgF = item.EgF,
                        Val_Eg = item.Val_Eg,
                        cEn = item.cEn,
                        cRng = item.cRng,
                        EnLA = item.EnLA,
                        EnHA = item.EnHA,
                        LAMd = item.LAMd,
                        HAMd = item.HAMd,
                        cLoA = item.cLoA,
                        cHiA = item.cHiA,
                        LoS = item.LoS,
                        HiS = item.HiS,
                        // add basic
                        Res = item.Res,
                        EnB = item.EnB,
                        BMd = item.BMd,
                        AiT = item.AiT,
                        Smp = item.Smp,
                        AvgM = item.AvgM,
                        //DI
                        Md = item.Md,
                        Inv = item.Inv,
                        Fltr = item.Fltr,
                        FtLo = item.FtLo,
                        FtHi = item.FtHi,
                        FqT = item.FqT,
                        FqP = item.FqP,
                        CntIV = item.CntIV,
                        CntKp = item.CntKp,
                        OvLch = item.OvLch,
                        //DO
                        FSV = item.FSV,
                        PsLo = item.PsLo,
                        PsHi = item.PsHi,
                        HDT = item.HDT,
                        LDT = item.LDT,
                        ACh = item.ACh,
                        AMd = item.AMd,
                    };
                }
            }
        }
        //if (id >= ai_id_offset)
        {
            //ViewData = IOitem;
            chiTxtbox.Text = (id - ai_id_offset).ToString();
            //return true;
        }
        //else if (id >= do_id_offset) { mod = DOitem; }

        flg = true;
    }
    void ChangeRng()
    {
        if (resCnt < Ref_IO_Mod.AIRng.Length)
        {
            //if (StpChkIdx8 || StpChkIdx9) ResetDO();

            if (StpChkIdx1)
            {
                //20151112 needs to check V/A mode number.
                //if (VASelIdx == 0 && resCnt < (Ref_IO_Mod.AIRng.Length - AModNum)
                //     || VASelIdx == 1 && resCnt < Ref_IO_Mod.AIRng.Length)
                if (resCnt < Ref_IO_Mod.AIRng.Length)
                {
                    mainTaskStp = (int)ADAM_AT_AIRng_Task.wCh_Rng;
                }
                else
                    mainTaskStp = (int)ADAM_AT_AIRng_Task.wFinished;
            }
            else mainTaskStp = (int)ADAM_AT_AIRng_Task.wFinished;

            RngChgStp = 0;//20151112 reset step
        }
        else
        {
            mainTaskStp++;
        }
    }
    private bool DoValDetect(int _id, int _rng)
    {
        GetDeviceItems(_id);
        //
        #region -- Range --
        ProcessView(new ListViewData()
        {
            Step = RngChgStp.ToString(),
            RowData = "Val = " + IOitem.Val.ToString() +
                      ", AO_HiVal = " + Ref_IO_Mod.APAX_AO_HiVal.ToString()
        });
        //用AI輸入的最大值作為判斷
        if (_rng == (int)ValueRange.mA_4To20 || _rng == (int)ValueRange.mA_0To20
             || _rng == (int)ValueRange.mA_Neg20To20)
        {
            if (IOitem.Rng == Ref_IO_Mod.cRng &&
                IOitem.EgF > Ref_IO_Mod.APAX_AO_HiVal / 1000 - 5) return true;
        }
        else if (_rng == (int)ValueRange.mV_0To150 || _rng == (int)ValueRange.mV_Neg150To150)
        {
            if (IOitem.Rng == Ref_IO_Mod.cRng &&
                IOitem.EgF > Ref_IO_Mod.APAX_AO_HiVal - 10) return true;
        }
        else if (_rng == (int)ValueRange.mV_0To500 || _rng == (int)ValueRange.mV_Neg500To500)
        {
            if (IOitem.Rng == Ref_IO_Mod.cRng &&
                IOitem.EgF > Ref_IO_Mod.APAX_AO_HiVal - 100) return true;
        }
        else if (_rng == (int)ValueRange.V_0To10
                 || _rng == (int)ValueRange.V_0To5 || _rng == (int)ValueRange.V_Neg10To10
                 || _rng == (int)ValueRange.V_Neg5To5
                 || _rng == (int)ValueRange.V_Neg2pt5To2pt5)
        {
            if (IOitem.Rng == Ref_IO_Mod.cRng &&
                IOitem.EgF * 1000 > Ref_IO_Mod.APAX_AO_HiVal - 1000) return true;
        }
        else if (_rng == (int)ValueRange.V_0To1 || _rng == (int)ValueRange.V_Neg1To1)
        {
            if (IOitem.Rng == Ref_IO_Mod.cRng &&
                IOitem.EgF * 1000 > Ref_IO_Mod.APAX_AO_HiVal - 100) return true;
        }
        #endregion

        return false;
    }
    private bool DoChangeRange(int _rng)
    {
        SetData01 = Ref_IO_Mod.cRng = _rng;
        //Set Initial HA/LA Value and AO output value.
        #region -- Range --
        if (_rng == (int)ValueRange.mA_4To20 || _rng == (int)ValueRange.mA_0To20)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "15.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "6.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 20000;
            Ref_IO_Mod.APAX_AO_MdVal = 10000;
            Ref_IO_Mod.APAX_AO_LoVal = 4000;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = mA_4To20 || mA_0To20"
            });
        }
        else if (_rng == (int)ValueRange.mA_Neg20To20)
        {
            //Note : APAX-5028 only support 0~20mA.
            IOitem.cHiA = Ref_IO_Mod.cHiA = "15.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "2.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 20000;
            Ref_IO_Mod.APAX_AO_MdVal = 10000;
            Ref_IO_Mod.APAX_AO_LoVal = 0;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.mA_Neg20To20.ToString()
            });
        }
        else if (_rng == (int)ValueRange.mV_0To150)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "130.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "50.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 150;
            Ref_IO_Mod.APAX_AO_MdVal = 100;
            Ref_IO_Mod.APAX_AO_LoVal = 0;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.mV_0To150.ToString()
            });
        }
        else if (_rng == (int)ValueRange.mV_0To500)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "400.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "100.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 500;
            Ref_IO_Mod.APAX_AO_MdVal = 300;
            Ref_IO_Mod.APAX_AO_LoVal = 0;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.mV_0To500.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_0To1)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "0.700";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "0.300";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 1000;
            Ref_IO_Mod.APAX_AO_MdVal = 500;
            Ref_IO_Mod.APAX_AO_LoVal = 0;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_0To1.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_0To5)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "4.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "2.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 5000;
            Ref_IO_Mod.APAX_AO_MdVal = 3000;
            Ref_IO_Mod.APAX_AO_LoVal = 0;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_0To5.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_0To10)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "7.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "3.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 10000;
            Ref_IO_Mod.APAX_AO_MdVal = 5000;
            Ref_IO_Mod.APAX_AO_LoVal = 1000;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_0To10.ToString()
            });
        }
        else if (_rng == (int)ValueRange.mV_Neg150To150)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "130.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "-130.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 150;
            Ref_IO_Mod.APAX_AO_MdVal = 100;
            Ref_IO_Mod.APAX_AO_LoVal = -150;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.mV_Neg150To150.ToString()
            });
        }
        else if (_rng == (int)ValueRange.mV_Neg500To500)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "400.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "-400.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 500;
            Ref_IO_Mod.APAX_AO_MdVal = 100;
            Ref_IO_Mod.APAX_AO_LoVal = -500;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.mV_Neg500To500.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_Neg1To1)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "0.700";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "-0.700";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 1000;
            Ref_IO_Mod.APAX_AO_MdVal = 500;
            Ref_IO_Mod.APAX_AO_LoVal = -1000;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_Neg1To1.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_Neg2pt5To2pt5)
        {
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_Neg2pt5To2pt5.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_Neg5To5)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "3.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "-3.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 5000;
            Ref_IO_Mod.APAX_AO_MdVal = 1000;
            Ref_IO_Mod.APAX_AO_LoVal = -5000;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_Neg5To5.ToString()
            });
        }
        else if (_rng == (int)ValueRange.V_Neg10To10)
        {
            IOitem.cHiA = Ref_IO_Mod.cHiA = "9.000";
            IOitem.cLoA = Ref_IO_Mod.cLoA = "-9.000";
            //
            Ref_IO_Mod.APAX_AO_HiVal = 10000;
            Ref_IO_Mod.APAX_AO_MdVal = 1;
            Ref_IO_Mod.APAX_AO_LoVal = -10000;
            ProcessView(new ListViewData()
            {
                RowData = "Change IO_Rng = "
                    + ValueRange.V_Neg10To10.ToString()
            });
        }
        #endregion

        //if (IOitem.Rng != _rng)
        {
            
            IOitem.cRng = Ref_IO_Mod.cRng = _rng;
            ADAM6KReqService.UpdateIOConfig(IOitem);
            //HttpReqService.UpdateIOConfig(TransferIOModel());
            //CustomController.UpdateIOConfig(IOitem);
        }
        return true;
    }
    private bool DoRngDetect(int _id, int _rng)
    {
        GetDeviceItems(_id);
        ProcessView(new ListViewData()
        {
            Step = RngChgStp.ToString(),
            RowData = "IO_Rng = " + IOitem.Rng.ToString() +
                      ", cRng = " + Ref_IO_Mod.cRng.ToString()
        });
        getTxtbox[0].Text = IOitem.Rng.ToString();
        if (IOitem.Rng == Ref_IO_Mod.cRng) return true;


        return false;
    }
    private int OutputAO(uint row)
    {
        OutputAPAX5070(row);
        return (int)row;
    }
    private void OutputAPAX5070(uint row)
    {
        //int val = TF ? (int)1 : 0;
        int idx = OutAO_Slot_Idx + Ref_IO_Mod.Ch;
        APAX5070Service.ForceSigReg(idx, (int)row);
        //CustomController.OutputModbusSingleRegs(idx, (int)row);
        Thread.Sleep(100);
    }
    private uint IntToRowData(int mod, int val)//20151111 new
    {
        uint res = 0;
        float var = (float)val / 1000;
        if (mod == (int)ValueRange.mA_4To20
                            || mod == (int)ValueRange.mA_0To20
                            || mod == (int)ValueRange.mA_Neg20To20)
        {
            res = (uint)(var * 65535 / 20);
        }
        else
            res = (uint)((var + 10) * 65535 / 20);
        return res;
    }
}
public class ListViewData
{
    public int Ch { get; set; }
    public string Step { get; set; }
    public string Result { get; set; }
    public string RowData { get; set; }
}

public enum ADAM_AT_AIRng_Task
{
    wCh_Init = 1,
    wCh_Rng = 2, //channel range function test
    wCh_Rng_res = 3,

    wCh_ChangRng = 10,



    wFinished = 20,
}