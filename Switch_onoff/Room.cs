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
        public bool IsOn { get; set; }

        public Room(string id, Panel panel, List<string> nexts)
        {
            this.Id = id;
            this.Panel = panel;
            this.Nexts = nexts;
        }

        public void SwitchOn()
        {
            this.IsOn = true;
            this.Panel.ForeColor = Color.Red;
        }
        public void SwitchOff()
        {
            this.IsOn = false;
            this.Panel.ForeColor = Color.RoyalBlue;
        }

    }
}
