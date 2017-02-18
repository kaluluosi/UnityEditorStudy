using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System;

namespace TestTool.Common
{
    public static class GMUtility
    {

        /// <summary>
        /// 清空背包
        /// </summary>
        public static void ClearPackage()
        {
            SendGM("clp");
            Player.instance.reqPackageInfo();
        }

        /// <summary>
        /// 填充背包
        /// </summary>
        public static void FillPackage(int id = 1011)
        {
            int emptyCount = PackageGlobalInfo.Inx + 1 - PackageGlobalInfo.UsedGrids;
            for (int i = 0; i < emptyCount; i++)
            {
                SendGM("additem", id, 1);
            }
        }
        public static void SendGM(string code)
        {
            try
            {
                Player.instance.receiveGmMsg(code);
                Debug.Log(code);
            }
            catch (Exception e)
            {
                Debug.Log("游戏没启动！" + e.Message);
            }
        }

        public static void SendGM(string code, params int[] args)
        {
            var commands = args.Select(arg => arg.ToString()).ToList();
            commands.Insert(0, code);

            string commandStr = string.Join(" ", commands.ToArray());
            SendGM(commandStr);
        }

        public static void SendGM(string code, params long[] args)
        {
            var commands = args.Select(arg => arg.ToString()).ToList();
            commands.Insert(0, code);

            string commandStr = string.Join(" ", commands.ToArray());
            SendGM(commandStr);
        }

        public static void SendGM(string code, params object[] args)
        {
            var commands = args.Select(arg => arg.ToString()).ToList();
            commands.Insert(0, code);

            string commandStr = string.Join(" ", commands.ToArray());
            SendGM(commandStr);
        }

        public static void SendGMFormat(string formatCode, params object[] args)
        {
            var argstrs = args.Select(arg => arg.ToString()).ToArray();
            SendGM(string.Format(formatCode, argstrs));
        }

    }
}
