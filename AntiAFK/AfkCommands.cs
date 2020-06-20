﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AutoAccept_CSGO4.AntiAFK
{
    public class AfkCommands
    {


        /// <summary>
        /// Declaration of external SendInput method
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);


        // Declare the INPUT struct
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type;
            public InputUnion U;

            public static int Size
            {
                get { return Marshal.SizeOf(typeof(INPUT)); }
            }
        }

        // Declare the InputUnion struct
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] internal MOUSEINPUT mi;
            [FieldOffset(0)] internal KEYBDINPUT ki;
            [FieldOffset(0)] internal HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            internal int dx;
            internal int dy;
            internal MouseEventDataXButtons mouseData;
            internal MOUSEEVENTF dwFlags;
            internal uint time;
            internal UIntPtr dwExtraInfo;
        }

        [Flags]
        public enum MouseEventDataXButtons : uint
        {
        }

        [Flags]
        public enum MOUSEEVENTF : uint
        {
            ABSOLUTE = 0x8000,
            HWHEEL = 0x01000,
            MOVE = 0x0001,
            MOVE_NOCOALESCE = 0x2000,
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            VIRTUALDESK = 0x4000,
            WHEEL = 0x0800,
            XDOWN = 0x0080,
            XUP = 0x0100
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            internal VirtualKeyShort wVk;
            internal ScanCodeShort wScan;
            internal KEYEVENTF dwFlags;
            internal int time;
            internal UIntPtr dwExtraInfo;
        }

        [Flags]
        public enum KEYEVENTF : uint
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            SCANCODE = 0x0008,
            UNICODE = 0x0004
        }

        public enum VirtualKeyShort : short
        {

        }

        public enum ScanCodeShort : short
        {
            RETURN = 28,
            ESCAPE = 1,
            KEY_K = 37,
        }

        /// <summary>
        /// Define HARDWAREINPUT struct
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            internal int uMsg;
            internal short wParamL;
            internal short wParamH;
        }
        
        
        
        public void Send(ScanCodeShort a)
        {
            INPUT[] Inputs = new INPUT[1];
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = a;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[0] = Input;
            SendInput(1, Inputs, INPUT.Size);
        }

        public void PlusLeft()
        {
            Send(ScanCodeShort.KEY_K);
            Thread.Sleep(90);
            SendKeys.SendWait("{+}");
            SendKeys.SendWait("{L}");
            SendKeys.SendWait("{E}");
            SendKeys.SendWait("{F}");
            SendKeys.SendWait("{T}");
            Thread.Sleep(40);
            Send(ScanCodeShort.RETURN);
            Thread.Sleep(40);
            Send(ScanCodeShort.ESCAPE);
        }
        
        public void MinusLeft()
        {
            Send(ScanCodeShort.KEY_K);
            Thread.Sleep(90);
            SendKeys.SendWait("{-}");
            SendKeys.SendWait("{L}");
            SendKeys.SendWait("{E}");
            SendKeys.SendWait("{F}");
            SendKeys.SendWait("{T}");
            Thread.Sleep(40);
            Send(ScanCodeShort.RETURN);
            Thread.Sleep(40);
            Send(ScanCodeShort.ESCAPE);
        }
        
        public void PlusForward()
        {
            Send(ScanCodeShort.KEY_K);
            Thread.Sleep(90);
            SendKeys.SendWait("{+}");
            SendKeys.SendWait("{F}");
            SendKeys.SendWait("{O}");
            SendKeys.SendWait("{R}");
            SendKeys.SendWait("{W}");
            SendKeys.SendWait("{A}");
            SendKeys.SendWait("{R}");
            SendKeys.SendWait("{D}");
            Thread.Sleep(40);
            Send(ScanCodeShort.RETURN);
            Thread.Sleep(40);
            Send(ScanCodeShort.ESCAPE);
        }
        
        public void MinusForward()
        {
            Send(ScanCodeShort.KEY_K);
            Thread.Sleep(90);
            SendKeys.SendWait("{-}");
            SendKeys.SendWait("{F}");
            SendKeys.SendWait("{O}");
            SendKeys.SendWait("{R}");
            SendKeys.SendWait("{W}");
            SendKeys.SendWait("{A}");
            SendKeys.SendWait("{R}");
            SendKeys.SendWait("{D}");
            Thread.Sleep(40);
            Send(ScanCodeShort.RETURN);
            Thread.Sleep(40);
            Send(ScanCodeShort.ESCAPE);
        }
    }
}