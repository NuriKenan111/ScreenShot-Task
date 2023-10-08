
using System.Drawing;
using System.IO;



while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey();

    if (keyInfo.Key == ConsoleKey.Enter)
    {
        Rectangle screenBounds = new Rectangle(0, 0, (int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight);

        
        using (Bitmap bitmap = new Bitmap(screenBounds.Width, screenBounds.Height))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(screenBounds.Location, Point.Empty, screenBounds.Size);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string filePath = Path.Combine(desktopPath, fileName);

            bitmap.Save(filePath, ImageFormat.Png);
        }
    }
}
               
