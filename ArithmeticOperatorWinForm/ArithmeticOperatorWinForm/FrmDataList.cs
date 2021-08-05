using ArithmeticOperatorBLL;
using ArithmeticOperatorDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArithmeticOperatorWUI
{
    public partial class FrmDataList : Form
    {
        public string OperativeType;

        public FrmDataList(string pOperativeType)
        {
            InitializeComponent();
            OperativeType = pOperativeType;
        }

        private void FrmDataList_Load(object sender, EventArgs e)
        {            
            List<DTO> ListItemsSaved = FileOperationBLL.ReadSavedFileBLL(OperativeType);

            if(ListItemsSaved.Count != 0)
            {
                LvData.Columns.Add(ListItemsSaved[0].Date, 154);
                LvData.Columns.Add(ListItemsSaved[0].Fraction1, 154);
                LvData.Columns.Add(ListItemsSaved[0].Operative, 154);
                LvData.Columns.Add(ListItemsSaved[0].Fraction2, 154);
                LvData.Columns.Add(ListItemsSaved[0].Result, 154);

                ListItemsSaved.RemoveAt(0);

                foreach (var item in ListItemsSaved)
                {
                    ListViewItem lvi = LvData.Items.Add(item.Date);
                    lvi.SubItems.Add(item.Fraction1);
                    lvi.SubItems.Add(item.Operative);
                    lvi.SubItems.Add(item.Fraction2);
                    lvi.SubItems.Add(item.Result);
                }
            }
            else
            {
                LvData.Columns.Add("Vous n'avez encore rien sauvergarder !",770, HorizontalAlignment.Center);
            } 
        }
    }
}
