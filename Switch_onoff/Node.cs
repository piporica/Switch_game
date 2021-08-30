using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switch_onoff
{
    class Node
    {
        private List<Panel> panels; //노드를 구성하는 패널
        public string id; //양 옆 방 아이디 이어서 쓴 것
        public bool isOn;

        public Node(string id, List<Panel> pList)
        {
            this.id = id;
            this.panels = pList;
        }

        public void setMagicOn()
        {
            isOn = true;
            foreach (Panel p in panels)
            {
                p.ForeColor = Color.Yellow;
            }
        }
        public void setMagicOff()
        {
            isOn = false;
            foreach (Panel p in panels)
            {
                p.ForeColor = Color.Lime;
            }
        }
    }
}
