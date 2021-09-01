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
        public int turn { get; set; }
        public bool IsSettingMode;
        public Hashtable switchStateSet = new Hashtable();
        public List<Room> needRoom;

        public Hashtable rooms;
        public Hashtable roads;
        
        public Game(Hashtable rooms, Hashtable roads)
        {
            this.rooms = rooms;
            this.roads = roads;
            initSetting();
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

        //턴 증가 처리
        public void turnIncrease()
        {
            turn += 1;

            List<string> connected = getConnectedRoom();
            foreach(string nowKey in rooms.Keys)
            {
                Room nowRoom = (Room)rooms[nowKey];

                setRoomSwitchState(nowRoom); //스위치 온오프 처리
                setRoomConnectState(nowRoom, connected); //연결여부 처리

                nowRoom.isChecked = false;  //타임터너 bfs 체크 변수 리셋
            }

        }

        //타임터너와 이어져 있는지 판단 - connected 변경
        private List<string> getConnectedRoom()
        {
            List<string> connectedRoomId = new List<string>();
            //bfs
            Queue<Room> queue = new Queue<Room>();
            queue.Enqueue((Room)rooms["17"]); //타임터너 위치
            
            while(queue.Count != 0)
            {
                Room nowRoom = queue.Dequeue();
                nowRoom.isChecked = true;
                connectedRoomId.Add(nowRoom.Id);

                foreach (string nextId in nowRoom.Nexts)
                {
                    Room nextRoom = (Room)rooms[nextId];
                    
                    if (!nextRoom.isChecked && nextRoom.IsSwitchOn)
                    {
                        queue.Enqueue(nextRoom);
                    }
                }
            }
            return connectedRoomId;
        }

        //스위치 처리
        private void setRoomSwitchState(Room nowRoom)
        {

            //스위치 처리
            if (nowRoom.IsSwitchOn)
            {
                nowRoom.SwitchOn();
            }
            else
            {
                nowRoom.SwitchOff();
            }
        }

        //방 근처 길 list 반환
        private List<string> getNearRoad(Room room)
        {
            List<string> nextRoadsID = new List<string>();
            string roomId = room.Id;

            foreach (string nextID in room.Nexts)
            {
                string id1 = roomId + nextID;
                string id2 = nextID + roomId;

                if (roads.ContainsKey(id1)) nextRoadsID.Add(id1);
                else if (roads.ContainsKey(id2)) nextRoadsID.Add(id2);
            }

            return nextRoadsID;
        }

        //연결여부 처리
        private void setRoomConnectState(Room nowRoom, List<string> connected)
        {
            List<string> nearRoadId = getNearRoad(nowRoom);
            if (connected.Contains(nowRoom.Id))
            {
                nowRoom.connectOn(); 
                foreach (string k in nearRoadId)
                {
                    //반대쪽도 켜져 있으면
                    string nextRoomId = k.Replace(nowRoom.Id, "");
                    Room nextRoom = (Room)rooms[nextRoomId];

                    if (connected.Contains(nextRoom.Id))
                    {
                        Road tempRoad = (Road)roads[k];
                        tempRoad.setMagicOn();
                    }
                }
            }
            else
            {
                nowRoom.connectOff(); 
                foreach (string k in nearRoadId)
                {
                    Road tempRoad = (Road)roads[k];
                    tempRoad.setMagicOff();
                }
            }
        }

        #region setting

        public void reset()
        {
            //턴 초기화
            turn = 0;

            //세팅데이터 판에 적용
            foreach(string key in rooms.Keys)
            {
                Room nowRoom = (Room)rooms[key];
                nowRoom.connectOff();
                if ((bool)switchStateSet[key]) nowRoom.SwitchOn();
                else nowRoom.SwitchOff();
            }
            foreach(string key in roads.Keys)
            {
                Road nowRoad = (Road)roads[key];
                nowRoad.setMagicOff();
            }

            turnIncrease();

        }

        private void initSetting()
        {
            foreach(string key in rooms.Keys)
            {
                switchStateSet[key] = false;
            }

            needRoom = new List<Room>();
        }

        public void settingON()
        {
            reset();
        }

        public void settingOff()
        {
            //현재상태 initdata에 저장 
            foreach(string k in rooms.Keys)
            {
                Room r = (Room)rooms[k];
                switchStateSet[r.Id] = r.IsSwitchOn;
            }
            reset();
        }

        public bool setNeedroom(string roomId)
        {
            Room nowRoom = (Room)rooms[roomId];
            nowRoom.IsNeed = !nowRoom.IsNeed;

            if (nowRoom.IsNeed) needRoom.Add(nowRoom);
            else needRoom.Remove(nowRoom);

            return nowRoom.IsNeed;
        }
        public bool isStarConnected()
        {
            Room star = (Room)rooms["04"];
            return (star.IsConnect);
        }

        public bool isClear()
        {
            bool rst = true;

            foreach(Room r in needRoom)
            {
                if (!r.IsSwitchOn) return false;
            }

            if (!isStarConnected()) return false;

            return rst;

        }

        #endregion

    }
}
