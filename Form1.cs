using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerToPokeOne
{
    public partial class Form_XboxToPokeOne : Form
    {
        public Form_XboxToPokeOne()
        {
            InitializeComponent();
        }

        private void Form_XboxToPokeOne_Load(object sender, EventArgs e)
        {

        }

        Classes.XboxController mycontroller;
        Classes.ConvertInput myConverter;
        private void btn_startwork_Click(object sender, EventArgs e)
        {
            mycontroller = new Classes.XboxController();
            if(mycontroller.IsConnected == true)
            {
                lbl_cntconn.Text = "Controller ist mit dem Computer verbunden und wurde erkannt";
            }
            myConverter = new Classes.ConvertInput();
            clk_updatecontroller.Start();
            
        }

        private void clk_updatecontroller_Tick(object sender, EventArgs e)
        {
            mycontroller.Update();
            myConverter.ConvertAllInput(mycontroller);

        }
    }
}
