using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Switch_onoff.Properties;

namespace Switch_onoff
{
    public partial class Switch_game : Form
    {
        private Game game;
        private Hashtable rooms;
        private Hashtable roads;

        public Switch_game()
        {
            InitializeComponent();
            makeRoomhash();
        }

        private void InitSwitchNode()
        {


        }

        //방 초기 세팅
        private Hashtable makeRoomhash()
        {
            List<Panel> panelList = makeRoomPanelList();
            Hashtable Roomhash = new Hashtable();

            string data = Resources.data;
            string[] datalines = data.Split('\n');
            for(int i = 0 ; i < datalines.Length ; i++)
            {
                string dataline = datalines[i];
                string[] roomData = dataline.Split(' ');

                List <string> nexts = new List<string>();
                for(int j = 1 ; j < roomData.Length ; j++) nexts.Add(roomData[j]);
                Room newRoom = new Room(roomData[0], panelList[i], nexts);
                Roomhash.Add(roomData[0], newRoom);
                panelList[i].Tag = roomData[0];
            }

            return Roomhash;

        }
        private List<Panel> makeRoomPanelList()
        {
            List<Panel> list = new List<Panel>();
            list.Add(panel1);
            list.Add(panel2);
            list.Add(panel3);
            list.Add(panel4);
            list.Add(panel5);
            list.Add(panel6);
            list.Add(panel7);
            list.Add(panel8);
            list.Add(panel9);
            list.Add(panel10);
            list.Add(panel11);
            list.Add(panel12);
            list.Add(panel13);
            list.Add(panel14);
            list.Add(panel15);
            list.Add(panel16);
            list.Add(panel17);

            return list;
        }
        //길 초기 세팅
        private void initRoad()
        {
            Hashtable roadHash = new Hashtable();
            List<Panel> roadPanels = makeRoadPanelList();
            foreach (Panel p in roadPanels)
            {
                string id = p.Tag.ToString();
                if (roadHash.ContainsKey(id))
                {
                    Road temproad = (Road)roadHash[id];
                    temproad.panels.Add(p);
                }
                else
                {
                    List<Panel> newList = new List<Panel>();
                    newList.Add(p);
                    Road newRoad = new Road(id, newList);
                }
                p.Click += new EventHandler(test_road);
            }
         }

        private List<Panel> makeRoadPanelList()
        {
            List<Panel> roadPanels = new List<Panel>();
            roadPanels.Add(panel18);
            roadPanels.Add(panel19);
            roadPanels.Add(panel20);
            roadPanels.Add(panel21);
            roadPanels.Add(panel22);
            roadPanels.Add(panel23);
            roadPanels.Add(panel24);
            roadPanels.Add(panel25);
            roadPanels.Add(panel26);
            roadPanels.Add(panel27);
            roadPanels.Add(panel28);
            roadPanels.Add(panel29);
            roadPanels.Add(panel30);
            roadPanels.Add(panel31);
            roadPanels.Add(panel32);
            roadPanels.Add(panel33);
            roadPanels.Add(panel34);
            roadPanels.Add(panel35);
            roadPanels.Add(panel36);
            roadPanels.Add(panel37);
            roadPanels.Add(panel38);
            roadPanels.Add(panel39);
            roadPanels.Add(panel40);
            roadPanels.Add(panel41);
            roadPanels.Add(panel42);
            roadPanels.Add(panel43);
            roadPanels.Add(panel44);
            roadPanels.Add(panel45);

            return roadPanels;
        }

        #region events

        public void test(object sender, EventArgs e)
        {
            string strControlName = ((Control)sender).Tag.ToString();
            MessageBox.Show(strControlName);
        }


        public void test_road(object sender, EventArgs e)
        {
            string strControlName = ((Control)sender).Tag.ToString();
            MessageBox.Show(strControlName);
        }

        #endregion
    }

}
