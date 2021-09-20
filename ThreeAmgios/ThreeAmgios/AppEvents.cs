using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace ThreeAmgios
{
    public sealed class AppEvents
    {
        private static readonly AppEvents instance = new AppEvents();

        bool AllowAppEventTracking = true;
        private System.Timers.Timer _flush;
        private object _lock = new object();
        Dictionary<string, string> props = new Dictionary<string, string>();

        private AppEvents()
        {
            //TestAppCenterEventLimits();

            //_flush = new System.Timers.Timer(60000); //Flush once a minute
            //_flush.Elapsed += _flush_Elapsed;
            //_flush.Start();

            //AppDomain.CurrentDomain.UnhandledException += this.MyUnhandledExceptionEventHandler;
        }

        public static AppEvents Instance
        {
            get
            {
                return instance;
            }
        }

        public void TestAppCenterEventLimits()
        {
            var custom_event = GetStaticPropertyBag(typeof(EventName));
            foreach (KeyValuePair<string, object> obj in custom_event)
            {
                string temp = obj.Key;
            }
        }

        public void StopAppEvent_Tracking()
        {
            AllowAppEventTracking = false;

            if (_flush != null)
            {
                _flush.Stop();
            }
        }

        private void _flush_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (props.Count > 0)
            {
                AddEvent(EventName.Event_000);
            }
        }

        public void AddEvent(EventName eventName, string eventProperty = "empty")
        {
            lock (_lock)
            {
                bool flush = false;

                if (AllowAppEventTracking)
                {
                    if (props.Count >= 20) 
                    {
                        flush = true;                        
                    }
                    string FlushMe;

                    if (props.TryGetValue(eventName.ToString(), out FlushMe))
                    {
                        flush = true;
                    }
                }

                if (flush)
                {
                    try
                    {
                        Flush();
                        props = new Dictionary<string, string>();
                    }
                    catch (Exception ex)
                    {
                        Analytics.TrackEvent(EventName.Event_001.ToString());
                        Crashes.TrackError(ex);
                    }
                }

                props.Add(eventName.ToString(), eventProperty);
            }
        }

        private void Flush()
        {
            if (AllowAppEventTracking)
            {
                try
                {
                    Analytics.TrackEvent(EventName.Event_000.ToString(), props);
                }
                catch (Exception ex)
                {
                    Analytics.TrackEvent(EventName.Event_001.ToString());
                    Crashes.TrackError(ex);
                }
            }
        }

        private void MyUnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Analytics.TrackEvent(EventName.Event_002.ToString(), GetExceptionProperties(e));
        }

        private static Dictionary<string, string> GetExceptionProperties(Exception exception)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("Message", exception.Message);
            if (exception.InnerException != null)
            {
                props.Add("InnerException", exception.InnerException.Message);
            }
            if (exception.StackTrace != null)
            {
                props.Add("StackTrace", exception.StackTrace);
            }
            return props;
        }

        private static Dictionary<string, object> GetStaticPropertyBag(Type t)
        {
            const BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            var map = new Dictionary<string, object>();
            foreach (var prop in t.GetProperties(flags))
            {
                map[prop.Name] = prop.GetValue(null, null);
            }
            return map;
        }

    }

    public enum EventName
    {
        //Maximum number of distinct custom events that can be tracked daily is 200
        //This count resets at 12 AM UTC.
        //No limit on the maximum number of events instances sent per device.

        Event_000, //Flush
        Event_001, //Exception
        Event_002, //MyUnhandledExceptionEventHandler
        Event_003, //Logon Events
        Event_004, //Data Access Events
        Event_005, //Account Access Events
        Event_006, //Messaging Events
        Event_007, //AppCenter.Configured
        Event_008,
        Event_009,
        Event_010, //Method Start
        Event_011, //Method End
        Event_012,
        Event_013,
        Event_014,
        Event_015,
        Event_016,
        Event_017,
        Event_018,
        Event_019,
        Event_020,
        Event_021,
        Event_022,
        Event_023,
        Event_024,
        Event_025,
        Event_026,
        Event_027,
        Event_028,
        Event_029,
        Event_030,
        Event_031,
        Event_032,
        Event_033,
        Event_034,
        Event_035,
        Event_036,
        Event_037,
        Event_038,
        Event_039,
        Event_040,
        Event_041,
        Event_042,
        Event_043,
        Event_044,
        Event_045,
        Event_046,
        Event_047,
        Event_048,
        Event_049,
        Event_050,
        Event_051,
        Event_052,
        Event_053,
        Event_054,
        Event_055,
        Event_056,
        Event_057,
        Event_058,
        Event_059,
        Event_060,
        Event_061,
        Event_062,
        Event_063,
        Event_064,
        Event_065,
        Event_066,
        Event_067,
        Event_068,
        Event_069,
        Event_070,
        Event_071,
        Event_072,
        Event_073,
        Event_074,
        Event_075,
        Event_076,
        Event_077,
        Event_078,
        Event_079,
        Event_080,
        Event_081,
        Event_082,
        Event_083,
        Event_084,
        Event_085,
        Event_086,
        Event_087,
        Event_088,
        Event_089,
        Event_090,
        Event_091,
        Event_092,
        Event_093,
        Event_094,
        Event_095,
        Event_096,
        Event_097,
        Event_098,
        Event_099,
        Event_100,
        Event_101,
        Event_102,
        Event_103,
        Event_104,
        Event_105,
        Event_106,
        Event_107,
        Event_108,
        Event_109,
        Event_110,
        Event_111,
        Event_112,
        Event_113,
        Event_114,
        Event_115,
        Event_116,
        Event_117,
        Event_118,
        Event_119,
        Event_120,
        Event_121,
        Event_122,
        Event_123,
        Event_124,
        Event_125,
        Event_126,
        Event_127,
        Event_128,
        Event_129,
        Event_130,
        Event_131,
        Event_132,
        Event_133,
        Event_134,
        Event_135,
        Event_136,
        Event_137,
        Event_138,
        Event_139,
        Event_140,
        Event_141,
        Event_142,
        Event_143,
        Event_144,
        Event_145,
        Event_146,
        Event_147,
        Event_148,
        Event_149,
        Event_150,
        Event_151,
        Event_152,
        Event_153,
        Event_154,
        Event_155,
        Event_156,
        Event_157,
        Event_158,
        Event_159,
        Event_160,
        Event_161,
        Event_162,
        Event_163,
        Event_164,
        Event_165,
        Event_166,
        Event_167,
        Event_168,
        Event_169,
        Event_170,
        Event_171,
        Event_172,
        Event_173,
        Event_174,
        Event_175,
        Event_176,
        Event_177,
        Event_178,
        Event_179,
        Event_180,
        Event_181,
        Event_182,
        Event_183,
        Event_184,
        Event_185,
        Event_186,
        Event_187,
        Event_188,
        Event_189,
        Event_190,
        Event_191,
        Event_192,
        Event_193,
        Event_194,
        Event_195,
        Event_196,
        Event_197,
        Event_198,
        Event_199
    }

}