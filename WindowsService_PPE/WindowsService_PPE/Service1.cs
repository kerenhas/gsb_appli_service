using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Timers;

namespace WindowsService_PPE
{
    public partial class Service1 : ServiceBase
    {
        /*

        private static System.Timers.Timer aTimer;
       [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };



        public Service1()
        {

            InitializeComponent();

            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";

        }



        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            SetTimer();

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
            Console.WriteLine("coucou");
            //Connexion à la bdd et création du curseur:
            connexionbdd crs = new connexionbdd("SERVER=127.0.0.1; DATABASE=test; UID=root; PASSWORD=");

            //On vérifie qu'on est bien entre le 1 et le 10 du mois:
            if (Gestion_Dates.Entre(1, 15) == true)
            {

                //Récupération des fiches du mois précédent et maj de celles-ci:
                //Récupération du mois précédent et son année
                String moisPrecedent = Gestion_Dates.GetMoisPrecedent();
                Console.WriteLine(moisPrecedent);
                //  String annee = Gestion_Date.getAnnee(DateTime.Today);
                string annee = DateTime.Today.AddMonths(-1).ToString("yyyy");
                string mois = annee + moisPrecedent;
                crs.reqUpdate("update fichefrais set idetat='CL' where mois =" + mois + " and idetat='CR'");
            }
            //Si on est après le 20 du mois:
            if (Gestion_Dates.Entre(20, 31) == true)
            {
                ;
                //Récupération des fiches du mois précédent et maj de celles-ci:
                String moisPrecedent = Gestion_Dates.GetMoisPrecedent();
                //String annee = Gestion_Date.getAnnee(DateTime.Today);
                string annee = DateTime.Today.AddMonths(-1).ToString("yyyy");
                string mois = annee + moisPrecedent;

                //   crs.reqUpdate("update fichefrais set idetat='RB' where mois = " + mois + " and idetat='VA'");
                crs.reqUpdate("update contact set id='04' where name='keren'");
            }
        }




        protected override void OnStop()
        {
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
        */

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };

        private int eventId = 1;

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            //Connexion à la bdd et création du curseur:
            connexionbdd crs = new connexionbdd("SERVER=127.0.0.1; DATABASE=gsb_frais; UID=root; PASSWORD=");

            //On vérifie qu'on est bien entre le 1 et le 10 du mois:
            if (Gestion_Dates.Entre(1, 10) == true)
            {
                //Récupération des fiches du mois précédent et maj de celles-ci:
                //Récupération du mois précédent et son année
                String moisPrecedent = Gestion_Dates.GetMoisPrecedent();
                String annee = Gestion_Dates.getAnnee(DateTime.Today);
                string mois = annee + moisPrecedent;

               crs.reqUpdate("update fichefrais set idetat='CL' where mois = " + mois + " and idetat='CR'");

            }
            //Si on est après le 20 du mois:
            if (Gestion_Dates.Entre(20, 31) == true)
            {
                //Récupération des fiches du mois précédent et maj de celles-ci:
                String moisPrecedent = Gestion_Dates.GetMoisPrecedent();
                String annee = Gestion_Dates.getAnnee(DateTime.Today);
                string mois = annee + moisPrecedent;

                  crs.reqUpdate("update fichefrais set idetat='RB' where mois = " + mois + " and idetat='VA'");
           
            }

        }

        public Service1()
        {

            InitializeComponent();

            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";

        }

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            eventLog1.WriteEntry("In OnStart");
            // Set up a timer that triggers every minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();


            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }
        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}