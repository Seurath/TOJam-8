using UnityEngine;     
using System.Collections;     
using System.Runtime.InteropServices;
using System.Text;
     
     
     
    public class RazerHydraPlugin {
     

        public const int SIXENSE_BUTTON_BUMPER    = 128; //(0x01<<7)
     
        public const int SIXENSE_BUTTON_JOYSTICK  = 256; //(0x01<<8)
     
        public const int SIXENSE_BUTTON_1         = 32;  //(0x01<<5)
     
        public const int SIXENSE_BUTTON_2         = 64;  //(0x01<<6)
     
        public const int SIXENSE_BUTTON_3         = 8;   //(0x01<<3)
     
        public const int SIXENSE_BUTTON_4         = 16;  //(0x01<<4)
     
        public const int SIXENSE_BUTTON_START     = 1;   //(0x01<<0)
     
       
     
        //dllFile = "sixensed_x64" or "sixensed"
     
        //[DllImport ("sixensed_x64")]
     
        public struct _sixenseControllerData{
     
            public Vector3 pos;
     
            public Vector3 rot_mat_x;
     
            public Vector3 rot_mat_y;
     
            public Vector3 rot_mat_z;
     
            public byte joystick_x;
     
            public byte joystick_y;
     
            public byte trigger;
     
            public int buttons;
     
            public byte sequence_number;
     
            public Quaternion rotQuat;
     
            public short firmware_revision;
     
            public short hardware_revision;
     
            public short packet_type;
     
            public short magnetic_frequency;
     
            public int enabled;
     
            public int controller_index;
     
            public byte is_docked;
     
            public byte which_hand; 
     
        };
     
       
     
        public _sixenseControllerData data;
     
        public _sixenseAllControllerData all_data;
     
       
     
       //[DllImport ("sixensed_x64")]
     
    	public struct _sixenseAllControllerData {
    	
		public _sixenseControllerData[] controllers;
    
		}; 

       
     
        [DllImport ("sixense")]
     
        private static extern int sixenseInit( );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseExit( );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetMaxBases( );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseSetActiveBase( int base_num);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseIsBaseConnected(int base_num );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetMaxControllers( );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetNumActiveControllers( );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseIsControllerEnabled(int which);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetAllNewestData(out _sixenseAllControllerData all_data);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetAllData(int index_back,out _sixenseAllControllerData all_data);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetNewestData(int which,out _sixenseControllerData data);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetData(int which, int index_data,out _sixenseControllerData data);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetHistorySize( );
     
        [DllImport ("sixense")]
     
        private static extern int sixenseSetFilterEnabled(int on_or_off);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetFilterEnabled(out int on_or_off);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseSetFilterParams(float near_range, float near_val, float far_range, float far_val);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetFilterParams(out float near_range,out float near_val,out float far_range,out float far_val);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseTriggerVibration(int controller_id, int duration_100ms, int pattern_id);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseAutoEnableHemisphereTracking(int which_controller);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseSetHighPriorityBindingEnabled(int on_or_off);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetHighPriorityBindingEnabled(out int on_or_off);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseSetbaseColor( char red, char green, char blue);
     
        [DllImport ("sixense")]
     
        private static extern int sixenseGetBaseColor(out char red,out char green,out char blue);
     
     
     
        public int _sixenseInit(){
     
            return sixenseInit();
     
        }
     
        public int _sixenseExit(){
     
            return sixenseExit();
     
        }
     
        public int _sixenseGetMaxBases(){
     
            return sixenseGetMaxBases();
     
        }
     
        public int _sixenseSetActiveBase(int base_num){
     
            return sixenseSetActiveBase(base_num);
     
        }
     
        public int _sixenseIsBaseConnected(int base_num){
     
            return sixenseIsBaseConnected(base_num);
     
        }
     
        public int _sixenseGetMaxControllers(){
     
            return sixenseGetMaxControllers();
     
        }
     
        public int _sixenseGetNumActiveControllers(){
     
            return sixenseGetNumActiveControllers();
     
        }
     
        public int _sixenseIsControllerEnabled(int which){
     
            return sixenseIsControllerEnabled(which);
     
        }
     
        public int _sixenseGetAllNewestData(){
     
            return sixenseGetAllNewestData(out all_data);
     
        }
     
        public int _sixenseGetAllData(int indexBack){
     
            return sixenseGetAllData(indexBack,out all_data);   
     
        }
     
        public int _sixenseGetNewestData(int which){
     
            return sixenseGetNewestData(which,out data);
     
        }
     
        public int _sixenseGetData(int which, int indexData){
     
            return sixenseGetData(which, indexData,out data);
     
        }
     
        public int _sixenseGetHistorySize(){
     
            return sixenseGetHistorySize();
     
        }
     
        public int _sixenseSetFilterEnabled(int on_or_off){
     
            sixenseSetFilterEnabled(on_or_off);
     
            return 0;
     
        }
     
        public int _sixenseGetFilterEnabled(int on_or_off){
     
            return sixenseGetFilterEnabled(out on_or_off);
     
        }
     
        public int _sixenseSetFilterParams(float near_range, float near_val, float far_range, float far_val){
     
            return sixenseSetFilterParams(near_range, near_val, far_range, far_val);
     
        }
     
        public int _sixenseGetFilterParams(float near_range,float near_val,float far_range,float far_val ){
     
            return sixenseGetFilterParams(out near_range,out near_val,out far_range,out far_val);
     
        }
     
        /*public int _sixenseTriggerVibration(int controllerId, int duration100ms, int patternId){
     
            return sixenseTriggerVibration(controllerId, duration100ms, patternId);
     
        }*/
     
        public int _sixenseAutoEnableHemisphereTracking(int which_controller){
     
            return sixenseAutoEnableHemisphereTracking(which_controller);
     
        }
     
        public int _sixenseSetHighPriorityBindingEnabled(int on_or_off){
     
            return sixenseSetHighPriorityBindingEnabled(on_or_off);
     
        }
     
        public int _sixenseGetHighPriorityBindingEnabled(int on_or_off){
     
            return sixenseGetHighPriorityBindingEnabled(out on_or_off);
     
        }
     
        /*public int _sixenseSetbaseColor(char red, char green, char blue){
     
            return sixenseSetbaseColor( red, green, blue);
     
        }
     
        public int _sixenseGetBaseColor(char red, char green, char blue){
     
            return sixenseGetBaseColor( out red,out green,out blue);
     
        }*/
     
    }