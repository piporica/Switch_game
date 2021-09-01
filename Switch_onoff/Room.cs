using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switch_onoff
{
    class Room
    {
        public string Id { get; set; }
        private Panel Panel { get; set; }
        public List<string> Nexts { get; set; }

        //상태값들
        public bool IsNeed { get; set; }
        public bool IsSwitchOn{ get; set; }
        public bool IsConnect { get; set; }
        public int boomCount { get; set; }

        public bool isChecked;




        public Room(string id, Panel panel, List<string> nexts)
        {
            Id = id;
            Panel = panel;
            Nexts = nexts;
            boomCount = 5;

            IsNeed = false;
            IsSwitchOn = false;
            IsConnect = false; 
            isChecked = false;

        }

        public void SwitchOn()
        {
           IsSwitchOn = true;
           Panel.BackColor = Color.Red;
        }
        public void SwitchOff()
        {
            IsSwitchOn = false;
            Panel.BackColor = Color.RoyalBlue;
        }   
        public void connectOn()
        {
            boomCount = boomCount - 1;
            IsConnect = true;

            if (boomCount < 0) 
                boom();
        }
        public void connectOff()
        {
            boomCount = 5;
            IsConnect = false;
        }
        public void boom()
        {
            Panel.BackColor = Color.Aqua;
        }
    }
}
