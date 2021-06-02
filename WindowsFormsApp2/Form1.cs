using System;
using System.Drawing;
using System.Windows.Forms;
using static PETT.KeyHandler;

namespace PETT
{
    public partial class Form1 : Form
    {
        //Program Variables     
        public static KeyHandler ghk;
        public static KeyHandler ghk2;
        public static KeyHandler ghk3;
        public static KeyHandler ghk4;
        public static KeyHandler ghk5;
 
        public static bool ProgrammaAan = false;
   


        //Handle Hotkeys en invoke methodes
        //See Keyhandler --> implementation 
        protected override void WndProc(ref Message m)
        {
            if (ProgrammaAan == true)
            {
                HandleHotkeys(ref m);
            }
            base.WndProc(ref m);
        }


        public Form1()
        {
            //Initialize 
            InitializeComponent();
            ghk = new KeyHandler(Keys.Oem3, this);
            ghk2 = new KeyHandler(Keys.B, this);
            ghk3 = new KeyHandler(Keys.G, this);
            ghk4 = new KeyHandler(Keys.I, this);
            ghk5 = new KeyHandler(Keys.Q, this);
     
            UpdateButton();
            button9.BackColor = Color.Gray;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        //Aan en uit
        private void button1_Click(object sender, EventArgs e)
        {
            ProgrammaAan = true;
            ghk.Register();
            UpdateButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProgrammaAan = false;
            ghk.Unregister();
            UpdateButton();
        }


        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }


        private void UpdateButton()
        {
            if (ProgrammaAan)
            {
                button3.BackColor = Color.Green;
            }
            else
            {
                button3.BackColor = Color.Gray;
            }

        }

    
 
        public static void UpdateUnderPaste()
        {
            
             //label20.Text = Clipboard.GetText();
        }


        //binnenhalen gegevens
        private void button4_Click(object sender, EventArgs e)
        {
        

        }
                   

        //test
        private void button5_Click(object sender, EventArgs e)
        {
            string test = "Test";
            Clipboard.SetText(test);
        }

        

        private void label20_Click(object sender, EventArgs e)
        {
                       
        }
                
        private void label11_Click(object sender, EventArgs e)
        {

        }
                        
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
