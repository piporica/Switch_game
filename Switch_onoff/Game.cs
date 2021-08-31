using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_onoff
{
    class Game
    {
        private int turn { get; set; }
        private bool IsSettingMode;
        private Hashtable rooms;
        private Hashtable roads;
        private List<Room> needRoom;

        public void init()
        {
         
        }
        public void checkOnOff()
        {

        }
        public void RoomClicked(string RoomId)
        {
            Room clickedRoom = (Room)rooms[RoomId];
            if (clickedRoom.IsSwitchOn)
            {
                clickedRoom.SwitchOff();
            }
            else
            {
                clickedRoom.SwitchOn();
            }
        }

    }
}
