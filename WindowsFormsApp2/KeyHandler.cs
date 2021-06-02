using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PETT.Form1;

namespace PETT
{

    

    public class KeyHandler
    {
        
       

        //Hoykey initialisation and basic methods          
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public int key;
        public IntPtr hWnd;
        public int id;
        private uint fsModifiers;

        public KeyHandler(Keys key, System.Windows.Forms.Form form)
        {
            this.key  = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }
            

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
            
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, fsModifiers, key);  //fsModifiers 0x0001 voor alt
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }

        public static void RegisterSecondaryKeys()
        {
            ghk2.Register();
            ghk3.Register();
            ghk4.Register();
            ghk5.Register();
    
        }

        public static void UnregisterSecondaryKeys()
        {
            ghk2.Unregister();
            ghk3.Unregister();
            ghk4.Unregister();
            ghk5.Unregister();

        }


        //
        //Implementation
        public static bool BasisHotkeyGedrukt = false;

        public static void HandleHotkeys(ref Message m)
        {
            
            
            if (m.Msg == Variabels.WM_HOTKEY_MSG_ID && m.WParam.ToInt32() == ghk.GetHashCode())
                HotkeyStart();
            if (m.Msg == Variabels.WM_HOTKEY_MSG_ID && m.WParam.ToInt32() == ghk2.GetHashCode() && BasisHotkeyGedrukt == true)
                HotkeyMaakBSN();
            if (m.Msg == Variabels.WM_HOTKEY_MSG_ID && m.WParam.ToInt32() == ghk3.GetHashCode() && BasisHotkeyGedrukt == true)
                HotkeyMaakGeboorteDatum();
            if (m.Msg == Variabels.WM_HOTKEY_MSG_ID && m.WParam.ToInt32() == ghk4.GetHashCode() && BasisHotkeyGedrukt == true)
                HotkeyMaakIBAN();
            if (m.Msg == Variabels.WM_HOTKEY_MSG_ID && m.WParam.ToInt32() == ghk5.GetHashCode() && BasisHotkeyGedrukt == true)
                HotkeyMaakVandaag();
        }

        
        //Starthotkey
        public static void HotkeyStart()
        {
            //Register the second hotkey
            RegisterSecondaryKeys();
            BasisHotkeyGedrukt = true;
            //  MessageBox.Show("hoi");

        }

        //Algemene hotkeys 
        public static void HotkeyMaakVandaag()
        {
            BasisHotkeyGedrukt = false;
            UnregisterSecondaryKeys();
            Clipboard.SetText(Testdata.MaakVandaag());
            Form1.UpdateUnderPaste();
            // MessageBox.Show("Q");
        }

        public static void HotkeyMaakIBAN()
        {
            BasisHotkeyGedrukt = false;
            UnregisterSecondaryKeys();
            Clipboard.SetText(Testdata.MaakIBAN());
            Form1.UpdateUnderPaste();
            // MessageBox.Show("I");
        }

        public static void HotkeyMaakGeboorteDatum()
        {
            BasisHotkeyGedrukt = false;
            UnregisterSecondaryKeys();
            Clipboard.SetText(Testdata.MaakGeboortedatum());
            Form1.UpdateUnderPaste();
            //MessageBox.Show("G");
        }

        public static void HotkeyMaakBSN()
        {
            BasisHotkeyGedrukt = false;
            UnregisterSecondaryKeys();
            Clipboard.SetText(Testdata.MaakBsn());
            Form1.UpdateUnderPaste();
            // MessageBox.Show("B");
        }


     
        //Database
      
    }
}
