using System;
using System.Diagnostics;
using System.IO;

namespace ImageResizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            var destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            var imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            var sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            var beforeTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"修改前花費時間: {beforeTime} ms");

            var imageProcessTask = new ImageProcessTask();

            imageProcessTask.Clean(destinationPath);

            sw.Restart();
            imageProcessTask.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            var afterTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"修改後花費時間: {afterTime} ms");

            Console.WriteLine($"提升約: {100 - (double)afterTime / beforeTime * 100} %");
        }
    }
}