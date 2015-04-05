using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Crawler.Utils.Random;
using Microsoft.Xna.Framework;

namespace Crawler.Utils.MapGenerator
{
    public class BasicMapGenerator
    {
        public Vector2 minRoomSize;
        public Vector2 maxRoomSize;

        public int RoomNumber;

        public Vector2 MapSize;

        public List<Room> GenerateRooms()
        {
            var rng = new RandomManager();
            var listResult = new List<Room>();
            for (int i = 0; i < RoomNumber; i++)
            {
                var cptRetry = 5;
                while (cptRetry > 0)
                {
                    var nextSize = new Vector2(minRoomSize.X + rng.GetInt((int)(maxRoomSize.X - minRoomSize.X)),
                        minRoomSize.Y + rng.GetInt((int)(maxRoomSize.Y - minRoomSize.Y)));
                    var nextPos = new Vector2(rng.GetInt((int)(MapSize.X - nextSize.X - 1)),
                        rng.GetInt((int)(MapSize.Y - nextSize.Y - 1)));

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
            for(int i=0; i<lr.Count; i++)
            {
                var currentR = lr[i];
            }

            return lr;
        }

    }
}
