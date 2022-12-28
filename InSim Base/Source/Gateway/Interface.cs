using InSim_Base.Source.Output;
using InSimDotNet;
using InSimDotNet.Packets;

namespace InSim_Base.Source.Gateway
{
    public class Interface
    {
        public struct Message
        {
            /// <summary>
            /// Send a global message, to all users connected in server.
            /// </summary>
            /// <param name="Message">Message to be sended.</param>
            public static void Send(string Message)
            {
                try
                {
                    Program.insim.Send(new IS_MTC
                    {
                        Msg = Message,
                        UCID = 255,
                        PLID = 255,
                        Sound = MessageSound.SND_MESSAGE,
                        ReqI = 2
                    });
                }
                catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.MTC); }
            }

            /// <summary>
            /// Send a private message to specific user, by unique id.
            /// </summary>
            /// <param name="Message">Message to be sended.</param>
            /// <param name="UCID">Unique ID of user.</param>
            public static void Send(string Message, byte UCID)
            {
                try
                {
                    Program.insim.Send(new IS_MTC
                    {
                        Msg = Message,
                        UCID = UCID,
                        PLID = 0,
                        Sound = MessageSound.SND_SYSMESSAGE,
                        ReqI = 2
                    });
                }
                catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.MTC); }
            }
        }

        public struct Button
        {
            /// <summary>
            /// Send a interface user button, with selected parameters.
            /// </summary>
            /// <param name="Text">Text that will show on button.</param>
            /// <param name="Style">Button style.</param>
            /// <param name="Height">Height of button.</param>
            /// <param name="Width">Width of button.</param>
            /// <param name="Top">Top screen position of button.</param>
            /// <param name="Left">Left screen position of button.</param>
            /// <param name="Button">Button ID.</param>
            /// <param name="UCID">Unique ID of user to be sended.</param>
            public static void Send(string Text, ButtonStyles Style, byte Height, byte Width, byte Top, byte Left, byte Button, byte UCID)
            {
                try
                {
                    Program.insim.Send(new IS_BTN
                    {
                        Text = Text,
                        BStyle = Style,
                        H = Height,
                        W = Width,
                        T = Top,
                        L = Left,
                        ClickID = Button,
                        UCID = UCID,
                        ReqI = 2
                    });
                }
                catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.BTN); }
            }

            /// <summary>
            /// Send a interface user button textbox, with selected parameters.
            /// </summary>
            /// <param name="Text">Text that will show on button.</param>
            /// <param name="Caption">Button textbox title, when clicked.</param>
            /// <param name="Style">Button style.</param>
            /// <param name="Height">Height of button.</param>
            /// <param name="Width">Width of button.</param>
            /// <param name="Top">Top screen position of button.</param>
            /// <param name="Left">Left screen position of button.</param>
            /// <param name="Button">Button ID.</param>
            /// <param name="Size">Size of textbox field.</param>
            /// <param name="UCID">Unique ID of user to be sended.</param>
            public static void Send(string Text, string Caption, ButtonStyles Style, byte Height, byte Width, byte Top, byte Left, byte Button, byte Size, byte UCID)
            {
                try
                {
                    Program.insim.Send(new IS_BTN
                    {
                        Text = Text,
                        Caption = Caption,
                        BStyle = Style,
                        H = Height,
                        W = Width,
                        T = Top,
                        L = Left,
                        ClickID = Button,
                        TypeIn = Size,
                        UCID = UCID,
                        ReqI = 2
                    });
                }
                catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.BTN); }
            }

            /// <summary>
            /// Remove a button by id.
            /// </summary>
            /// <param name="Button">Button id.</param>
            /// <param name="UCID">Unique id of user to remove button.</param>
            public static void Remove(byte Button, byte UCID)
            {
                try
                {
                    Program.insim.Send(new IS_BFN
                    {
                        ClickID = Button,
                        UCID = UCID,
                        ReqI = 2
                    });
                }
                catch (InSimException IEx) { Logger.Error(IEx.Message, Logger.Types.BFN); }
            }
            
            /// <summary>
            /// Remove all buttons of screen.
            /// </summary>
            /// <param name="UCID">Unique id of user to remove button.</param>
            public static void Remove(byte UCID)
            {
                for (byte i = 0; i < 235; i++)
                {
                    Program.insim.Send(new IS_BFN
                    {
                        ClickID = i,
                        UCID = UCID,
                        ReqI = 2
                    });
                }
            }
        }
    }
}
