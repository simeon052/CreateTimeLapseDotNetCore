﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CreateTimeLapse
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length >= 3)
            {
                string url = args[0];
                string outputPath = args[1];
                int recordingMinutes = int.Parse(args[2]);
                int interval = 1;
                int fps = 30;
                string username = null;
                string password = string.Empty;
                if(args.Length >= 7)
                {
                    interval = int.Parse(args[3]);
                    fps = int.Parse(args[4]);
                    username = args[5];
                    password = args[6];
                }

                var result = await TimeLapse.GetAsync(url, outputPath, recordingMinutes * 60, interval, fps, username, password);
                System.Console.WriteLine($"result : {result ?? "convert failed"}");
            }
            else
            {
                Console.WriteLine($"usage : <url> <output_avi_path> <Recording minute> [interval = 1] [fps = 30] [Username] [Password]");
            }
        }
    }
}
