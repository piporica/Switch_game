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
        private Hashtable rooms = new Hashtable();
        private Hashtable roads = new Hashtable();

        public Switch_game()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            rooms = makeRoomhash();
            roads = makeRoadhash();

            game = new Game(rooms, roads);
            setneedSwitchText();
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
                dataline = dataline.Replace("\r", "");
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
        private Hashtable makeRoadhash()
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
                    roadHash.Add(id, newRoad);
                }
            }

            return roadHash;
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

        public void RoomClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                string roomName = ((Control)sender).Tag.ToString();
                game.RoomClicked(roomName);
            }
            else if(e.Button == MouseButtons.Right && game.IsSettingMode)
            {
                string roomName = ((Control)sender).Tag.ToString();
                bool isneed = game.setNeedroom(roomName);

                Label label = findLabel(roomName);
                if (isneed) label.Text = "★" + label.Text;
                else label.Text = label.Text.Substring(1);
            }
        }

        public void settingClick(object sender, EventArgs e)
        {
            game.IsSettingMode = !game.IsSettingMode;
            checkClear();
            if (game.IsSettingMode)
            {
                game.settingON();
                turns.Text = "1";
                setting_btn.Text = "세팅모드 OFF";
                turn_comp.Enabled = false;
                label18.Visible = true;
                label19.Visible = true;
            }
            else
            {
                turns.Text = "1";
                setting_btn.Text = "세팅모드 ON";
                turn_comp.Enabled = true;
                label18.Visible = false;
                label19.Visible = false;

                game.settingOff();
                setneedSwitchText();
            }
        }

        public void setneedSwitchText()
        {
            string t = "";
            foreach(Room r in game.needRoom)
            {
                Label l = findLabel(r.Id);
                t += l.Text;
                if (r.IsSwitchOn) t = t + ": ON";
                else t = t + ": OFF";
                t += "  ";
            }
            sw_state.Text = t;

            if (game.isStarConnected()) tt_state.Text = "OK";
            else tt_state.Text = "NO";
        }
        
        public void checkClear()
        {
            if (game.isClear())
            {
                label20.Visible = true;
                turn_comp.Enabled = false;
            }
            else
            {
                label20.Visible = false;
                turn_comp.Enabled = true;
            }
        }



        public void turnPlus(object sender, EventArgs e)
        {
            game.turnIncrease();
            setneedSwitchText();
            turns.Text = game.turn.ToString();
            checkClear();
        }

        public Label findLabel(string tag)
        {
            var controls = this.Controls;


            Label label = new Label();
            Panel p = new Panel();
            foreach (Control control in controls)
            {
                if(control.Tag != null)
                {
                    if (control.Tag.ToString() == tag)
                    {
                        p = (Panel)control;
                        break;

                    }
                }
            }
            foreach(Control control in p.Controls)
            {
                if(control.Name.ToString().Substring(0, 5) == "label")
                {
                    label = (Label)control;
                }

            }
            return label;
        }

        #endregion

        private void reset_btn_Click(object sender, EventArgs e)
        {
            game.reset();
            turns.Text = game.turn.ToString();
            checkClear();
        }
    }

}
