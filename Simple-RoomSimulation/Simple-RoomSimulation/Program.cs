using System;

namespace Simple_RoomSimulation
{
    class RoomSimulation
    {
        private static void Main()
        {
            // Oda boyutları
            int roomWidth = 20;
            int roomHeight = 20;

            // Oda haritası oluşturma
            bool[,] roomMap = new bool[roomWidth, roomHeight];

            // Duvarları ve mobilyaları tanımlama
            roomMap[1, 1] = true;
            roomMap[1, 2] = true;
            roomMap[1, 3] = true;
            roomMap[1, 4] = true;
            roomMap[1, 5] = true;
            roomMap[1, 6] = true;
            roomMap[1, 7] = true;
            roomMap[1, 8] = true;
            roomMap[1, 9] = true;
            roomMap[1, 10] = true;
            roomMap[1, 11] = true;
            roomMap[1, 12] = true;
            roomMap[1, 13] = true;

            // Başlangıç ve hedef konumları
            int startX = 5;
            int startY = 5;
            int targetX = 0;
            int targetY = 0;

            // Robotun başlangıç konumu
            int robotX = startX;
            int robotY = startY;

            // Oda haritasını görselleştirme
            Console.WriteLine("Oda Haritası:");
            for (int y = 0; y < roomHeight; y++)
            {
                for (int x = 0; x < roomWidth; x++)
                {
                    if (x == robotX && y == robotY)
                        Console.Write("R "); // Robot
                    else if (roomMap[x, y])
                        Console.Write("# "); // Duvar veya mobilya
                    else if (x == targetX && y == targetY)
                        Console.Write("X "); // Hedef
                    else
                        Console.Write(". "); // Boş alan
                }
                Console.WriteLine();
            }

            // Hedefe ulaşana kadar robotu hareket ettirme
            while (robotX != targetX || robotY != targetY)
            {
                // Karar mekanizması: Hedefe doğru hareket etme
                if (robotX < targetX)
                    MoveRobot(roomMap, ref robotX, ref robotY, roomWidth, roomHeight, 1, 0); // Sağa git
                else if (robotX > targetX)
                    MoveRobot(roomMap, ref robotX, ref robotY, roomWidth, roomHeight, -1, 0); // Sola git

                if (robotY < targetY)
                    MoveRobot(roomMap, ref robotX, ref robotY, roomWidth, roomHeight, 0, 1); // İleri git
                else if (robotY > targetY)
                    MoveRobot(roomMap, ref robotX, ref robotY, roomWidth, roomHeight, 0, -1); // Geri git

                // Her adımdan sonra odanın durumunu gösterme
                Console.WriteLine("\nRobot hareket ettirildi:");
                for (int y = 0; y < roomHeight; y++)
                {
                    for (int x = 0; x < roomWidth; x++)
                    {
                        if (x == robotX && y == robotY)
                            Console.Write("R "); // Robot
                        else if (roomMap[x, y])
                            Console.Write("# "); // Duvar veya mobilya
                        else if (x == targetX && y == targetY)
                            Console.Write("X "); // Hedef
                        else
                            Console.Write(". "); // Boş alan
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                // Robot hedefe ulaştığında döngüden çık
                if (robotX == targetX && robotY == targetY)
                    break;
            }

            Console.ReadKey();
        }

        static void MoveRobot(bool[,] roomMap, ref int robotX, ref int robotY, int roomWidth, int roomHeight, int moveX, int moveY)
        {
            // Yeni konumu kontrol etme
            int newX = robotX + moveX;
            int newY = robotY + moveY;

            // Yeni konumun odada olup olmadığını ve engel olup olmadığını kontrol etme
            if (newX >= 0 && newX < roomWidth && newY >= 0 && newY < roomHeight && !roomMap[newX, newY])
            {
                // Yeni konuma hareket etme
                robotX = newX;
                robotY = newY;
            }
        }
    }
}