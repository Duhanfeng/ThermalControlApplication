using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThermalControlApplication
{
    public partial class MultiStepSettingForm : Form
    {
        public List<TempStepData> StepDatas { get; set; } = new List<TempStepData>();

        public McuControl McuControl { get; set; }

        public MultiStepSettingForm()
        {
            InitializeComponent();
        }

        public MultiStepSettingForm(McuControl mcuControl) : this()
        {
            McuControl = mcuControl;
        }

        private void UpdateTempStepData()
        {
            ConfigListView.Items.Clear();

            for (int i = 0; i < StepDatas.Count; i++)
            {
                ListViewItem LvItem = new ListViewItem();

                LvItem.Text = (i + 1).ToString();
                LvItem.SubItems.Add(StepDatas[i].Temp.ToString("F3"));
                LvItem.SubItems.Add(StepDatas[i].KeepTime.ToString());

                ConfigListView.Items.Add(LvItem);
            }

            foreach (var item in StepDatas)
            {
                
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            double temp = 0;
            if (!double.TryParse(TempTextBox.Text, out temp))
            {
                TempTextBox.Text = "60.000";
                MessageBox.Show("输入框数据异常!");
                return;
            }

            int time = 0;
            if (!int.TryParse(KeepTextBox.Text, out time))
            {
                KeepTextBox.Text = "30";
                MessageBox.Show("输入框数据异常!");
                return;
            }

            StepDatas.Add(new TempStepData(temp, time));

            //更新列表
            UpdateTempStepData();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            //获取输入值
            double temp = 0;
            if (!double.TryParse(TempTextBox.Text, out temp))
            {
                TempTextBox.Text = "60.000";
                MessageBox.Show("输入框数据异常!");
                return;
            }

            int time = 0;
            if (!int.TryParse(KeepTextBox.Text, out time))
            {
                KeepTextBox.Text = "30";
                MessageBox.Show("输入框数据异常!");
                return;
            }

            //获取插入位置
            if (ConfigListView.SelectedIndices.Count != 1)
            {
                MessageBox.Show("插入的位置无效");
                return;
            }

            if (ConfigListView.SelectedIndices[0] < 0)
            {
                MessageBox.Show("插入的位置无效");
                return;
            }

            int index = ConfigListView.SelectedIndices[0];
            if (index >= StepDatas.Count)
            {
                index = StepDatas.Count - 1;
            }

            //插入数据
            StepDatas.Insert(index + 1, new TempStepData(temp, time));

            //更新列表
            UpdateTempStepData();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //获取删除位置
            if (ConfigListView.SelectedIndices.Count != 1)
            {
                MessageBox.Show("插入的位置无效");
                return;
            }

            if (ConfigListView.SelectedIndices[0] < 0)
            {
                MessageBox.Show("插入的位置无效");
                return;
            }

            int index = ConfigListView.SelectedIndices[0];
            if (index >= StepDatas.Count)
            {
                index = StepDatas.Count - 1;
            }
            StepDatas.RemoveAt(index);

            //更新列表
            UpdateTempStepData();

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            StepDatas.Clear();

            //更新列表
            UpdateTempStepData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (McuControl == null)
            {
                MessageBox.Show("单片机无效");
                return;
            }

            try
            {
                McuControl?.SetMultiStep(StepDatas);
            }
            catch (Exception)
            {
                MessageBox.Show("写入失败(通信异常?)");
                return;
            }
            MessageBox.Show("写入成功");

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            StepDatas.Clear();
            Close();
        }
    }
}
