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
        public bool IsSwitchOn { get; set; }
        public bool IsConnect { get; set; }
        public int boomCount { get; set; }


        public Room(string id, Panel panel, List<string> nexts)
        {
            this.Id = id;
            this.Panel = panel;
            this.Nexts = nexts;
            this.boomCount = 5;
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
            IsConnect = true;
            Panel.ForeColor = Color.Yellow;
        }
        public void connectOff()
        {
            IsConnect = true;
            Panel.ForeColor = Color.White;
        }
    }
}
