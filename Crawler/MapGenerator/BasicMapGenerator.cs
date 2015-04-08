using System;
using System.Collections.Generic;
using System.Linq;

using Crawler.Utils.Random;
using Microsoft.Xna.Framework;

namespace Crawler.Utils.MapGenerator
{
    public class BasicMapGenerator
    {
        public Vector2 minRoomSize;
        public Vector2 maxRoomSize;

        public int RoomNumber;

        private SimplePathCalculator spc;
        public Vector2 MapSize;

        private RandomManager randomManager;

        public BasicMapGenerator()
        {
            randomManager = new RandomManager();
            spc = new SimplePathCalculator();
        }



        public List<Room> GenerateRooms()
        {
            var listResult = new List<Room>();
            for (int i = 0; i < RoomNumber; i++)
            {
                var cptRetry = 5;
                while (cptRetry > 0)
                {
                    var nextSize = new Vector2(minRoomSize.X + randomManager.GetInt((int)(maxRoomSize.X - minRoomSize.X)),
                        minRoomSize.Y + randomManager.GetInt((int)(maxRoomSize.Y - minRoomSize.Y)));
                    var nextPos = new Vector2(randomManager.GetInt((int)(MapSize.X - nextSize.X - 1)),
                        randomManager.GetInt((int)(MapSize.Y - nextSize.Y - 1)));

                    var tentativeRoom = new Room()
                    {
                        Setting =
                            new Rectangle((int)nextPos.X, (int)nextPos.Y, (int)(nextPos.X + nextSize.X),
                                (int)(nextPos.Y + nextSize.Y))
                    };

                    if (!listResult.Any(x => x.Setting.Intersects(tentativeRoom.Setting)))
                    {
                        Console.Write("Room placed");
                        listResult.Add(tentativeRoom);
                        break;
                    }
                    cptRetry--;
                }

            }

            return listResult;
        }

        public List<Room> GenerateIo(List<Room> lr )
        {
            int maxIo = 4;
            for(int i=0; i<lr.Count; i++)
            {
                var currentR = lr[i];
                var currentnumberOfIo = randomManager.GetInt(maxIo-1)+1;
                var listOfCell = Utilitaires.RectangleDelimitationCells(currentR.Setting);
                for (int j = 0; j < currentnumberOfIo; j++)
                {
                    var nextIo = listOfCell[randomManager.GetInt(listOfCell.Count)];
                    while(!currentR.IOs.Any(x=> (nextIo - x).Length()<=1))
                    {
                        nextIo = listOfCell[randomManager.GetInt(listOfCell.Count)];
                    }
                    currentR.IOs.Add(nextIo);
                }
            }

            return lr;
        }

        public List<Vector2> GenerateBasicPath(Vector2 origin, Vector2 destination)
        {
            return spc.FindPath(origin, destination);
        }


        public void GenerateBoard(Map mapGenerate)
        {
            
        }

    }
}
