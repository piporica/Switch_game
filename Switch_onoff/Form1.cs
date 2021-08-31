using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void InitSwitchNode()
        {


        }

        //방 초기 세팅
        private void initRoom()
        {
            string dataPath = "data.txt";


        }

        //길 초기 세팅
        private void initRoad()
        {

        }
    }

}
