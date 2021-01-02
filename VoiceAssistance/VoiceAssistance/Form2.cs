using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceAssistance
{
    public enum month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }
    public partial class VoiceForm : Form
    {
        //Properties
        CultureInfo cultureInfo;
        SpeechSynthesizer speech;
        SpeechRecognitionEngine recEngine;
        Choices choices;
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        bool Lock;
        ///DllImport files
        [DllImport("user32")]
        public static extern void LockWorkStation();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRec,
            int nTopRec,
            int nRightRec,
            int nBottomRec,
            int nWidthEllipse,
            int nHeightEllipse
            );

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        static string[] text = { "Hello madan", "How are you","What is the Current Time","Open Youtube","Open Chrome","Minimize chrome","Maximize chrome","close chrome",
            "Thank You","close","fine","i am fine","Youtube","What is the current Date","Play tamil songs","songs","open taskmanager","close taskmanager",
            "Play Kannada songs","Play English songs","open hotstar","play radhakrishna","open outlook","open sunnxt","open pad","Minimize pad","Maximize pad","close pad",
            "open notepad","Minimize notepad","Maximize notepad","close notepad","open excel","Minimize excel","Maximize excel","close excel","open calculator","close calculator","open visual studio","Minimize visual studio","Maximize visual studio","close visual studio",
            "Lock Screen","Open M O","Open v d i","open facebook","Open github","Open whatsup","open hangouts","open zoom","minimize zoom","maximize zoom","close zoom","open camera","open c m d","Minimize c m d","Maximize c m d",
            "close c m d","close camera","Minimize","Maximize","Lock 9 6 8 6","Unlock 9 6 8 6","Close all 9 6 8 6"};
        public VoiceForm()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
            CName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, CName.Width, CName.Height, 10, 10));
            pictureBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox1.Width, pictureBox1.Height, 20, 20));
            btnWel.Region = Region.FromHrgn(CreateRoundRectRgn(5, 10, btnWel.Width - 5, btnWel.Height - 5, 40, 40));
            btnimg.Region = Region.FromHrgn(CreateRoundRectRgn(4, 0, btnimg.Width - 4, btnimg.Height - 3, 0, 0));
            cultureInfo = new CultureInfo("en-US");
            recEngine = new SpeechRecognitionEngine(cultureInfo);
            speech = new SpeechSynthesizer();
            choices = new Choices();
            CheckForIllegalCrossThreadCalls = false;
            Lock = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string welcometext = "Welcome! This is Madan. How can I Help you sir";
            speech.SpeakAsync(welcometext);
            btnWel.Text = welcometext;
            speech.SpeakAsync("??Please use , Headphone ?, or bluetooth microphone, for better performance of this application");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            try
            {
                recEngine.RequestRecognizerUpdate();
                recEngine.LoadGrammarAsync(grammar);
                recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Alternates.Count==1)
            {
                string link = lnktext.Text;
                string decision = e.Result.Text.ToString().ToLower();
                if (decision == "unlock 9 6 8 6" && Lock == false)
                {
                    speech.SpeakAsync("Ok sir , UnLocking Voice recognation?");
                    Lock = true;
                }
                if (Lock)
                {
                    if (ChangeGender.SelectedItem.ToString() == "Female")
                        speech.SelectVoiceByHints((VoiceGender)2);
                    else
                        speech.SelectVoiceByHints((VoiceGender)1);
                    try
                    {
                        switch (decision)
                        {
                            case "hello madan":
                                speech.SpeakAsync("Hello waste body ,I am madan How Can I Help you ");
                                break;
                            case "how are you":
                                speech.SpeakAsync("I am doing good waste body, How are you");
                                break;
                            case "fine":
                                speech.SpeakAsync("Then go and sleep ,why are you torchring me");
                                break;
                            case "i am fine":
                                speech.SpeakAsync("Then go and sleep ,why are you torchring me");
                                break;
                            case "what is the current time":
                                var time = string.Format("{0:hh:mm:ss tt}", DateTime.Now).Split('.');
                                var t = time[2].Split(' ');
                                if (time[0].StartsWith("0"))
                                    time[0] = time[0].Substring(1);
                                speech.SpeakAsync("You don't have watch! stupid?,Then Why are you living in this world," +
                                "my era i need to follow you are command the current time is :" + time[0] + "hour" + time[1] + "minutes" + t[1]);
                                break;
                            case "what is the current date":
                                var monName = DateTime.Now.Month - 1;
                                speech.SpeakAsync("The Current date is:" + DateTime.Now.Day + (month)monName);
                                break;
                            case "thank you":
                                speech.SpeakAsync("You know what ? ,i am a machine!,don't say thanks or sorry to me You stupid waste body");
                                break;
                            case "lock screen":
                                speech.SpeakAsync("okk sir ,please wait while Locking screen");
                                LockWorkStation();
                                break;
                            case "close":
                                speech.Speak("Okkkk sir Love you, Miss yoU  sir ? bye bye!");
                                Application.Exit();
                                break;
                            ////chrome
                            case "open chrome":
                                speech.Speak("Lazy idiot....you have hands right ? then open your self ? ooohh wait!" +
                                    "you dont know how to open chrome right, ok i will help you");
                                Process.Start("chrome", "https://www.google.com/");
                                break;
                            case "minimize chrome":
                                speech.Speak("Ok sir , please wait while Minimizing chrome window");
                                foreach (var process in Process.GetProcessesByName("chrome"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize chrome":
                                speech.Speak("Ok sir , please wait while Maximize chrome window");
                                foreach (var process in Process.GetProcessesByName("chrome"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close chrome":
                                speech.SpeakAsync("Okkk Sir, closing chrome");
                                foreach (var process in Process.GetProcessesByName("chrome"))
                                {
                                    process.Kill();
                                }
                                break;
                            ////youtube
                            case "open youtube":
                                speech.Speak("Ok wait,i will open youtube");
                                Process.Start("chrome", "https://www.youtube.com/");
                                break;
                            case "youtube":
                                speech.Speak("Ok wait,i will open youtube");
                                Process.Start("chrome", "https://www.youtube.com/");
                                break;
                            ////songs
                            case "songs":
                                speech.Speak("Okkkk sir please wait opening telugu songs");
                                Process.Start("chrome", "https://www.youtube.com/watch?v=8-fFgb7UYjI/");
                                break;
                            case "play tamil songs":
                                speech.Speak("Okkk sir Please wait opening tamil songs");
                                Process.Start("chrome", "https://www.youtube.com/watch?v=2ZaVwIhqXm0&list=RD2ZaVwIhqXm0&start_radio=1/");
                                break;
                            case "play kannada songs":
                                speech.Speak("Okkkk sir please wait opening Kannda songs ");
                                Process.Start("chrome", "https://www.youtube.com/watch?v=01uRBlLAjFg");
                                break;
                            case "play english songs":
                                speech.Speak("Okkkk sir please wait opening english songs");
                                Process.Start("chrome", "https://www.youtube.com/watch?v=RUQl6YcMalg");
                                break;
                            //hotstar
                            case "open hotstar":
                                speech.Speak("Okkkk sir please wait while opening Hotstar");
                                Process.Start("chrome", "https://www.hotstar.com/in");
                                break;
                            case "play radhakrishna":
                                speech.Speak("Okkk sir Please wait while playing Radhakrishna");
                                Process.Start("chrome", "https://www.hotstar.com/in/tv/radha-krishna/1260026801/radha-meets-rukmini/1100046091");
                                break;
                            ////open outlook
                            case "open outlook":
                                speech.Speak("Okkkk sir Please wait while opening outlook ");
                                Process.Start("chrome", "https://webserver.motilaloswal.com/owa/#path=/mail");
                                break;
                            //open sunnxt
                            case "open sunnxt":
                                speech.Speak("Okkk sir Please wait while opening sunnxt ");
                                Process.Start("chrome", "https://www.sunnxt.com/");
                                break;
                            ////word pad
                            case "open pad":
                                speech.Speak("Okkk sir Please wait while opening pad");
                                Process.Start("winword");
                                break;
                            case "minimize pad":
                                speech.Speak("Ok sir , please wait while Minimizing pad window");
                                foreach (var process in Process.GetProcessesByName("winword"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize pad":
                                speech.Speak("Ok sir , please wait while Maximize pad");
                                foreach (var process in Process.GetProcessesByName("winword"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close pad":
                                speech.Speak("Okkk sir Please wait while closing pad");
                                foreach (var process in Process.GetProcessesByName("winword"))
                                {
                                    process.Kill();
                                }
                                break;
                            // Notepad
                            case "open notepad":
                                speech.Speak("Okkk sir Please wait while opening notepad");
                                Process.Start("notepad");
                                break;
                            case "minimize notepad":
                                speech.Speak("Ok sir , please wait while Minimizing notepad window");
                                foreach (var process in Process.GetProcessesByName("notepad"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize notepad":
                                speech.Speak("Ok sir , please wait while Maximize Notepad ");
                                foreach (var process in Process.GetProcessesByName("notepad"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close notepad":
                                speech.Speak("Okkk sir Please wait while closing notepad");
                                foreach (var process in Process.GetProcessesByName("notepad"))
                                {
                                    process.Kill();
                                }
                                break;
                            //Excel
                            case "open excel":
                                speech.Speak("Okkk sir Please wait while opening excel");
                                Process.Start("excel");
                                break;
                            case "minimize excel":
                                speech.Speak("Ok sir , please wait while Minimizing excel window");
                                foreach (var process in Process.GetProcessesByName("excel"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize excel":
                                speech.Speak("Ok sir , please wait while Maximize excel ");
                                foreach (var process in Process.GetProcessesByName("excel"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close excel":
                                speech.Speak("Okkk sir Please wait while closing excel");
                                foreach (var process in Process.GetProcessesByName("excel"))
                                {
                                    process.Kill();
                                }
                                break;
                            // calculaor
                            case "open calculator":
                                speech.Speak("Okkk sir please wait while opening calculator");
                                Process.Start("calc.exe");
                                break;
                            case "minimize calculator":
                                speech.Speak("Ok sir , please wait while Minimizing calculator window");
                                foreach (var process in Process.GetProcessesByName("CalCulator"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            ////visual studio
                            case "open visual studio":
                                speech.Speak("Okkkk sir please wait while opening visual studio code");
                                Process.Start("devenv.exe");
                                break;
                            case "minimize visual studio":
                                speech.Speak("Ok sir , please wait while Minimizing visual studio window");
                                foreach (var process in Process.GetProcessesByName("devenv"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize visual studio":
                                speech.Speak("Ok sir , please wait while Maximize visual studio ");
                                foreach (var process in Process.GetProcessesByName("devenv"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close visual studio":
                                speech.Speak("Okkkk sir please wait while closing visual studio code");
                                foreach (var process in Process.GetProcessesByName("devenv"))
                                {
                                    process.Kill();
                                    break;
                                }
                                speech.Speak("Hey ! Stupid! First open You are visual studio ,Then say close");
                                break;
                            ///MO attendence and VDI
                            case "open m o":
                                speech.Speak("Okkk sir ,please wait while opening mo");
                                Process.Start("chrome", "https://myzonehr.motilaloswal.com/self/dashboard/self-dashboard");
                                break;
                            case "open v d i":
                                speech.Speak("Okkk sir ,Please wait while opening  v d i");
                                Process.Start("chrome", "https://my.motilaloswal.com/");
                                break;
                            ///facebook
                            case "open facebook":
                                speech.Speak("Okkk darling,please wait while opening facebook");
                                Process.Start("chrome", "https://www.facebook.com/");
                                break;
                            ///github
                            case "open github":
                                speech.Speak("Okkk darling,please wait while opening github");
                                Process.Start("chrome", "https://www.github.com/");
                                break;
                            ///whatsup
                            case "open whatsup":
                                speech.Speak("Okkk darling,please wait while opening whatsup");
                                Process.Start("chrome", "https://web.whatsapp.com/");
                                break;
                            case "open zoom":
                                speech.Speak("Okkk please wait while opening zoom app");
                                string zoomDirectory = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Zoom\bin");
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = $@"{zoomDirectory}\Zoom.exe",
                                    WorkingDirectory = zoomDirectory
                                };
                                if (link != ".......Paste Link Here.......")
                                    startInfo.Arguments = $"--url={link}";
                                Process.Start(startInfo);
                                break;
                            case "minimize zoom":
                                speech.Speak("Ok sir , please wait while Minimizing Zoom window");
                                foreach (var process in Process.GetProcessesByName("zoom"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize zoom":
                                speech.Speak("Ok sir , please wait while Maximize Zoom window");
                                foreach (var process in Process.GetProcessesByName("zoom"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close zoom":
                                speech.Speak("Okkk please wait while closing zoom app");
                                foreach (var process in Process.GetProcessesByName("Zoom"))
                                {
                                    if (process.MainWindowHandle == IntPtr.Zero)
                                        continue;
                                    process.Kill();
                                }
                                break;
                            ///hangout
                            case "open hangouts":
                                speech.Speak("Okkkk darling,please wait while opening hangout");
                                Process.Start("chrome", "https://hangouts.google.com/");
                                break;
                            ///Task Manager
                            case "open taskmanager":
                                speech.Speak("Okkk darling,please wait while opening taskmanager");
                                Process.Start("taskmgr");
                                break;
                            case "close taskmanager":
                                speech.Speak("Okkk darling,please wait while closing taskmanager");
                                foreach (var process in Process.GetProcessesByName("taskmgr"))
                                {
                                    process.Kill();
                                }
                                break;
                            ///open camera
                            case "open camera":
                                speech.Speak("Okkk darling,please wait while opening camera");
                                Process.Start(@"microsoft.windows.camera:");
                                break;

                            case "close camera":
                                speech.Speak("Okkk darling,please wait while Closing camera");
                                foreach (var process in Process.GetProcesses())
                                {
                                    if (process.MainWindowHandle == IntPtr.Zero)
                                        continue;
                                    var WindowsCamera = process.ProcessName;
                                    if (WindowsCamera == "WindowsCamera")
                                    {
                                        IntPtr hWnd = process.MainWindowHandle;
                                        if (!hWnd.Equals(IntPtr.Zero))
                                        {
                                            ShowWindowAsync(hWnd, 0);
                                        }
                                    }
                                }
                                speech.Speak("Camera closed");
                                break;
                            ///open Run
                            case "open c m d":
                                speech.Speak("Please wait while opening command prompt");
                                Process.Start("cmd.exe");
                                break;
                            case "minimize c m d":
                                speech.Speak("Ok sir , please wait while Minimizing command prompt");
                                foreach (var process in Process.GetProcessesByName("cmd"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 2);
                                    }
                                }
                                break;
                            case "maximize c m d":
                                speech.Speak("Ok sir , please wait while Maximize command prompt");
                                foreach (var process in Process.GetProcessesByName("cmd"))
                                {
                                    IntPtr hWnd = process.MainWindowHandle;
                                    if (!hWnd.Equals(IntPtr.Zero))
                                    {
                                        ShowWindowAsync(hWnd, 1);
                                    }
                                }
                                break;
                            case "close c m d":
                                speech.Speak("Please wait while Closing command prompt");
                                foreach (var process in Process.GetProcessesByName("cmd"))
                                {
                                    process.Kill();
                                }
                                break;
                            case "minimize":
                                speech.SpeakAsync("Ok sir,Minimizing madan voice recognation");
                                this.WindowState = FormWindowState.Minimized;
                                break;
                            case "maximize":
                                speech.SpeakAsync("Ok sir,Maximize madan voice recognation");
                                this.WindowState = FormWindowState.Normal;
                                break;
                            case "lock 9 6 8 6":
                                speech.SpeakAsync("Ok sir , Locking Voice recognation? ,to unlock?, say, unlock ,9, 6, 8, 6");
                                Lock = false;
                                break;
                            case "close all 9 6 8 6":
                                speech.SpeakAsync("Okkk sir");
                                foreach (var process in Process.GetProcesses())
                                {
                                    if (process.MainWindowHandle == IntPtr.Zero)
                                        continue;
                                    if (process.ProcessName == "VoiceAssistancce")
                                    {

                                    }
                                    else
                                    {
                                        process.Kill();
                                    }
                                }
                                break;
                        }
                        btnWel.Text = decision;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                } 
            }
        }

        private void VoiceForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 590;
                mouseY = MousePosition.Y;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void VoiceForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void VoiceForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}
