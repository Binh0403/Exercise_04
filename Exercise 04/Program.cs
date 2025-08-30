internal class Program
{
    private static void Main(string[] args)
    {
        Ex01();
        Ex02();
    }
    static void Ex01()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int money = 100;   // vốn ban đầu
        int winCount = 0;  // đếm số trận thắng
        int loseCount = 0; // đếm số trận thua

        while (money > 0) // chơi đến khi hết tiền hoặc thoát
        {
            Console.WriteLine("\nChào mừng đến với trò chơi đoán số!");
            Console.WriteLine($"Hiện tại bạn còn {money}$");
            Console.WriteLine("Level:\n\t1 - Khó: 4 lần chơi\n\t2 - Trung bình: 7 lần chơi\n\t3 - Dễ: 10 lần chơi");
            Console.Write("Bạn chọn cấp độ nào? [1 - Khó; 2 - Trung bình; 3 - Dễ]: ");

            int level = Convert.ToInt32(Console.ReadLine());
            int solanchon = (level == 1) ? 4 : (level == 2 ? 7 : 10);
            int reward = (level == 1) ? 4 : (level == 2 ? 7 : 10);

            Random rnd = new Random();
            int comp_num = rnd.Next(1, 101); // số bí mật 1..100

            bool is_won = false;

            for (int i = 0; i < solanchon; i++)
            {
                Console.Write($"{i + 1}. Bạn đoán số [1-100]: ");
                int man_num = Convert.ToInt32(Console.ReadLine());

                if (man_num == comp_num)
                {
                    is_won = true;
                    Console.WriteLine(" You are Genius!");
                    break;
                }
                else if (man_num > comp_num)
                {
                    Console.WriteLine(" Số bạn đoán lớn hơn số máy nghĩ.");
                }
                else
                {
                    Console.WriteLine(" Số bạn đoán nhỏ hơn số máy nghĩ.");
                }
            }

            if (is_won)
            {
                money += reward;
                winCount++;
                Console.WriteLine($"Bạn thắng! Nhận thêm {reward}$. Tiền hiện tại: {money}$");
            }
            else
            {
                money -= reward;
                loseCount++;
                Console.WriteLine($"Bạn thua! Mất {reward}$. Số đúng là {comp_num}. Tiền hiện tại: {money}$");
            }

            if (money <= 0)
            {
                Console.WriteLine("Hết tiền rồi, game over!");
                break;
            }

            Console.Write("\nBạn có muốn chơi tiếp không? (y/n): ");
            string tl = Console.ReadLine();
            if (tl.ToLower().Equals("n"))
            {
                Console.WriteLine("Bye, hẹn gặp lại!");
                break;
            }
        }

        Console.WriteLine("\n=== Thống kê ===");
        Console.WriteLine($"Số ván thắng: {winCount}");
        Console.WriteLine($"Số ván thua: {loseCount}");
        Console.WriteLine($"Số tiền còn lại: {money}$");
    }
    static void Ex02()
    {
        {
            Random rnd = new Random();
            int money = 100;
            int win = 0, lose = 0;
            int round = 0;

            while (money > 0)
            {
                round++;
                Console.WriteLine($"\n===== Ván {round} =====");
                Console.WriteLine($"Số dư hiện tại: {money}$");

                // Người chơi đoán
                Console.Write("Bạn đoán (t = Tài / x = Xỉu / 5 = số 5 / k = thoát): ");
                string guess = Console.ReadLine().ToLower();

                if (guess == "k")
                {
                    Console.WriteLine("Bạn đã chọn dừng trò chơi.");
                    break;
                }

                // Máy tung xúc xắc
                int die1 = rnd.Next(6) + 1;
                int die2 = rnd.Next(6) + 1;
                int sum = die1 + die2;

                Console.WriteLine($"Máy gieo xúc xắc: {die1} + {die2} = {sum}");

                // Xử lý kết quả
                if (sum > 5)
                {
                    Console.WriteLine(" Kết quả: TÀI");
                    if (guess == "t") { money += 5; win++; Console.WriteLine("+5$"); }
                    else { money -= 5; lose++; Console.WriteLine("-5$"); }
                }
                else if (sum < 5)
                {
                    Console.WriteLine(" Kết quả: XỈU");
                    if (guess == "x") { money += 5; win++; Console.WriteLine("+5$"); }
                    else { money -= 5; lose++; Console.WriteLine("-5$"); }
                }
                else // sum == 5
                {
                    Console.WriteLine(" Kết quả: ĐẶC BIỆT (5)");
                    if (guess == "5") { money += 15; win++; Console.WriteLine("+15$"); }
                    else { money -= 5; lose++; Console.WriteLine("-5$"); }
                }

                if (money <= 0)
                {
                    Console.WriteLine("\n Bạn đã hết tiền! Trò chơi kết thúc.");
                    break;
                }

                // Hỏi chơi tiếp không
                Console.Write("\nBạn có muốn chơi tiếp không? (c = tiếp tục / k = kết thúc): ");
                string cont = Console.ReadLine().ToLower();
                if (cont == "k")
                {
                    Console.WriteLine(" Bạn đã chọn dừng trò chơi.");
                    break;
                }
            }

            // Báo cáo tổng hợp
            Console.WriteLine("\n===== BÁO CÁO =====");
            Console.WriteLine($"Tổng số ván đã chơi: {round}");
            Console.WriteLine($"Số lần thắng: {win}");
            Console.WriteLine($"Số lần thua: {lose}");
            Console.WriteLine($"Số dư cuối cùng: {money}$");
            Console.WriteLine(" Cảm ơn bạn đã chơi!");
        }
    }
}