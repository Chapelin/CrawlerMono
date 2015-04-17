namespace Crawler.MapGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cells;
    using Engine;
    using Utils;
    using Utils.PathCalculator;
    using Utils.Random;

    using Microsoft.Xna.Framework;

    public class BasicMapGenerator
    {
        public Vector2 minRoomSize;
        public Vector2 maxRoomSize;

        public int RoomNumber;

        private SimplePathCalculator spc;
        public Vector2 MapSize;

        private RandomManager randomManager;

        public BasicMapGenerator(int roomNumber, Vector2 mapSize, Vector2 minRoomSize, Vector2 maxRoomSize)
        {
            RoomNumber = roomNumber;
            MapSize = mapSize;
            this.minRoomSize = minRoomSize;
            this.maxRoomSize = maxRoomSize;
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
                            new Rectangle((int)nextPos.X, (int)nextPos.Y, (int)(nextSize.X),
                                (int)(nextSize.Y))
                    };

                    if (!listResult.Any(x => x.Setting.Intersects(tentativeRoom.Setting)))
                    {
                        listResult.Add(tentativeRoom);
                        break;
                    }
                    cptRetry--;
                }

            }

            return listResult;
        }

        public List<Room> GenerateIo(List<Room> lr)
        {
            int maxIo = 4;
            for (int i = 0; i < lr.Count; i++)
            {
                var currentR = lr[i];
                var currentnumberOfIo = randomManager.GetInt(maxIo - 1) + 1;
                var listOfCell = Utilitaires.RectangleDelimitationCells(currentR.Setting);
                for (int j = 0; j < currentnumberOfIo; j++)
                {
                    var nextIo = listOfCell[randomManager.GetInt(listOfCell.Count)];
                    var cpt = 10;
                    while (currentR.IOs.Any(x => Math.Abs((nextIo - x.Position).Length()) <= 1) || cpt == 0)
                    {
                        cpt--;
                        nextIo = listOfCell[randomManager.GetInt(listOfCell.Count)];
                    }
                    currentR.IOs.Add(new Exit() { Position = nextIo });
                }
            }

            return lr;
        }

        public Tuple<Vector2, List<Vector2>> GenerateBasicPath(Vector2 origin, Vector2 destination)
        {
            return new Tuple<Vector2, List<Vector2>>(origin, spc.FindPath(origin, destination));
        }


        public List<Tuple<Vector2, List<Vector2>>> GeneratePaths(List<Room> lr)
        {
            var availableIo = lr.SelectMany(x => x.IOs.Select(y => y.Position)).ToList();
            var listPath = new List<Tuple<Vector2, List<Vector2>>>();
            while (availableIo.Count > 1)
            {
                var io1 = availableIo[randomManager.GetInt(availableIo.Count)];
                availableIo.Remove(io1);
                var io2 = availableIo[randomManager.GetInt(availableIo.Count)];
                availableIo.Remove(io2);
                listPath.Add(GenerateBasicPath(io1, io2));
            }

            return listPath;
        }

        public void GenerateBoard(Map mapGenerate, Camera camera)
        {
            var lr = GenerateRooms();
            lr = GenerateIo(lr);
            List<Tuple<Vector2, List<Vector2>>> paths = GeneratePaths(lr);
            for (int x = 0; x < mapGenerate.SizeOfMap.X; x++)
            {
                for (int y = 0; y < mapGenerate.SizeOfMap.Y; y++)
                {
                    var vec = new Vector2(x, y);
                    var isFloor = lr.Any(z => z.Setting.Contains(vec));
                    Cell c;
                    if (isFloor)
                    {
                        c = new Floor(mapGenerate.Game, vec, camera, mapGenerate.sb);
                    }
                    else
                    {
                        c = new Wall(mapGenerate.Game, vec, camera, mapGenerate.sb);
                    }
                    mapGenerate.board.Add(c);
                }
            }
            // now : the corridors
            foreach (var path in paths)
            {
                var current = path.Item1;
                for (int i = 0; i < path.Item2.Count; i++)
                {
                    current += path.Item2[i];
                    mapGenerate.board.RemoveAll(x => x.positionCell == current);
                    mapGenerate.board.Add(new Floor(mapGenerate.Game, current, camera, mapGenerate.sb));
                }
            }

            PlaceStairs(mapGenerate, camera);
        }

        private void PlaceStairs(Map mapGenerate, Camera camera)
        {
            var firstPoss = mapGenerate.board.Where(x => x.GetType() == typeof(Floor)).Take(2);

            var ds = new Downstair(mapGenerate.Game, firstPoss.First().positionCell, camera, mapGenerate.sb);
            var us = new Upstair(mapGenerate.Game, firstPoss.Last().positionCell, camera, mapGenerate.sb);
            mapGenerate.board.RemoveList(firstPoss.ToList());
            mapGenerate.board.Add(ds);
            mapGenerate.board.Add(us);
        }
    }
}
