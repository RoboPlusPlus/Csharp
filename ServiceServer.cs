using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.ServiceProcess;




namespace Service_monitor_server_r0_1
{



    class Service_monitoring
    {





        public enum SimpleServiceCustomCommands
        { StopWorker = 128, RestartWorker, CheckWorker };


        
        static void Main(string[] args)
        {

        String promptInput; 
        bool firstscan = true;
        bool v_run_service_loop = false;
            ConsoleKeyInfo cki;


            while (true) {
                Console.WriteLine("Type 'm' for start monitoring ");
                promptInput = Console.ReadLine();


               bool checif_m = String.ReferenceEquals(promptInput, promptInput);

                if (checif_m == true) {
                    v_run_service_loop = true; }

                else {
                    v_run_service_loop = false;

                }


        ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            int a = 0;
            string c = "";




                while ((v_run_service_loop == true)||(firstscan ==true))
                    //firstscan = false;        
                    foreach (ServiceController scTemp in scServices)
            {        Console.Clear();

                        {
                    if (scTemp.ServiceName == "TeamViewer")
                {
                            // Display properties for the Simple Service sample
                    //Console.Clear();
                    ServiceController sc = new ServiceController("TeamViewer");
                    Console.WriteLine("Status = " + sc.Status);
                    Console.WriteLine("Can Pause and Continue = " + sc.CanPauseAndContinue);
                    Console.WriteLine("Can ShutDown = " + sc.CanShutdown);
                    Console.WriteLine("Can Stop = " + sc.CanStop);
                    Console.WriteLine(a);



                     if (sc.Status == ServiceControllerStatus.Stopped)
                        {

                            sc.Refresh();
                            Console.WriteLine("Stopped");
                            Console.WriteLine("Press 'r' to start service");
                            Console.WriteLine(++a);
                                    Thread.Sleep(200);
                                }


                    if (sc.Status == ServiceControllerStatus.Paused)
                        {
                        
                        sc.Refresh();
                        Console.WriteLine("Paused");
                        Console.WriteLine("Press 'r' to start service");
                        Console.WriteLine(+a);
                        Thread.Sleep(200);
                                }

                    if (sc.Status == ServiceControllerStatus.Running)
                        {
                        
                        sc.Refresh();
                        Console.WriteLine("Running");
                        Console.WriteLine("Press 's' to stop service");
                        Console.WriteLine(++a);
                        Thread.Sleep(200);
                                }



                        //Console.WriteLine("\n'x' key to stop monitoring\n'r' key to start service\n's' key to stop service \n");

                        if (Console.KeyAvailable == true)
                          {
                                    Thread.Sleep(1000);
                                    cki = Console.ReadKey(true);

                        if (cki.Key == ConsoleKey.X)
                                {
                                    v_run_service_loop = false;
                                }

                        if ((sc.Status == ServiceControllerStatus.Stopped) & (cki.Key == ConsoleKey.R))
                        {
                            sc.Start();
                        }

                        if ((sc.Status == ServiceControllerStatus.Running) & (cki.Key == ConsoleKey.S) || (sc.Status == ServiceControllerStatus.Paused) & (cki.Key == ConsoleKey.S))
                        {
                            sc.Stop();
                        }

                                }
                            }
                }

            }

            }
        }
    }
}


// This sample displays the following output if the Simple Service
// sample is running:
//Status = Running
//Can Pause and Continue = True
//Can ShutDown = True
//Can Stop = True
//Status = Paused
//Status = Running
//Status = Stopped
//Status = Running
//4:14:49 PM - Custom command received: 128
//4:14:49 PM - Custom command received: 129
//ServiceController arg1
//ServiceController arg2




