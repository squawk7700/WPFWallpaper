using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace WPFWallpaper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //why did i even put this here
        int iBackground = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBox1.Text = dialog.FileName;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            // i fucking hate this project so much, honestly. it's too much work, for too little. 
            iBackground++;

            if (iBackground > 4) iBackground = 1;

            string sFile_FullPath = textBox1.Text;




            set_Desktop_Background(sFile_FullPath);

        }

        private void set_Desktop_Background(string sFile_FullPath)

        {
            //don't fuck with the spacing otherwise it'll break absolutely everything
     

            const int SET_DESKTOP_BACKGROUND = 20;

            const int UPDATE_INI_FILE = 1;

            const int SEND_WINDOWS_INI_CHANGE = 2;




            win32.SystemParametersInfo(SET_DESKTOP_BACKGROUND, 0, sFile_FullPath, UPDATE_INI_FILE | SEND_WINDOWS_INI_CHANGE);



        }



        internal sealed class win32

        {
            //dll import shittery

            [DllImport("user32.dll", CharSet = CharSet.Auto)]

            internal static extern int SystemParametersInfo(

                int uAction,

                int uParam,

                String lpvParam,

                int fuWinIni);


        }
    }
}
